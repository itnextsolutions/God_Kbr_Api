using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Godrej_Korber_DAL
{
    public class OracleHelper
    {

        private Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        public OracleParameter[] cmdParameter;

        private OracleConnection conn;
        //public readonly string CON_STRING = Convert.ToString(ConfigurationManager.ConnectionStrings["ConnectionString"]);

        public readonly string CON_STRING = "(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-44Q6036)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = WMS19))); User Id = MRFWMS; Password=SYSEFA;";

        //public static string GetConnectionString()
        //{
        //    return Convert.ToString(ConfigurationManager.ConnectionStrings["ConnectionString"]);
        //}
        public OracleConnection GetConnection()
        {
            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection();
                    conn.ConnectionString = CON_STRING;
                    // conn.ConnectionString = DLLStringEncrypt.DecryptString(CON_STRING, "ART");
                    conn.Open();
                    return conn;
                }
                else
                {
                    if (conn.State == 0)
                    {
                        conn.Open();
                        return conn;
                    }
                    else
                    {
                        return conn;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CloseConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, null);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataSet ExecuteDataset(OracleConnection conn, CommandType cmdType, string cmdText, OracleParameter[] cmdParms, bool AssignDataTableName = true)
        {
            DataSet ds;

            try
            {
                ds = ExecuteDataset(conn, cmdType, cmdText, cmdParms);

                if (AssignDataTableName == true)
                {
                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        int ds_i = 0;
                        foreach (var parms in cmdParms)
                        {
                            if (parms.OracleType == OracleType.Cursor)
                            {
                                ds.Tables[ds_i].TableName = parms.ParameterName;
                                ds_i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds;
        }
        public int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
            catch
            {
                throw;
            }
        }
        public int ExecuteNonQuery(OracleConnection conn, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmdParameter = cmdParms;
                cmd.Parameters.Clear();
                return val;
            }
            catch
            {
                throw;
            }
        }
        public int ExecuteNonQueryOut(OracleConnection conn, CommandType cmdType, string cmdText, string ParamName, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

                int val = cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters[ParamName].Value);
            }
            catch
            {
                throw;
            }
        }
        //added by priya on 1 dec 2012
        public object[] ExecuteNonQueryOutMultiple(OracleConnection conn, CommandType cmdType, string cmdText, string ParamName, string ParamName1, string ParamName2, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                cmd.ExecuteNonQuery();
                return (new object[] { cmd.Parameters[ParamName].Value, cmd.Parameters[ParamName1].Value, cmd.Parameters[ParamName2].Value });
            }
            catch
            {
                throw;
            }
        }

        public long ExecuteNonQueryOutLong(OracleConnection conn, CommandType cmdType, string cmdText, string ParamName, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                return Convert.ToInt64(cmd.Parameters[ParamName].Value);
            }
            catch
            {
                throw;
            }
        }

        public string ExecuteNonQueryOutString(OracleConnection conn, CommandType cmdType, string cmdText, string ParamName, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                return cmd.Parameters[ParamName].Value.ToString();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute a OracleCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-Oracle command</param>
        /// <param name="commandParameters">an array of OracleParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>


        /// <summary>
        /// Execute a OracleCommand (that returns no resultset) using an existing Oracle Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing Oracle transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-Oracle command</param>
        /// <param name="commandParameters">an array of OracleParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute a OracleCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  OracleDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OracleConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-Oracle command</param>
        /// <param name="commandParameters">an array of OracleParamters used to execute the command</param>
        /// <returns>A OracleDataReader containing the results</returns>
        /*public static OracleDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms) {
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }catch {
                conn.Close();
                throw;
            }
        }*/
        public OracleDataReader ExecuteReader(OracleConnection conn, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {

            OracleCommand cmd = new OracleCommand();

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }

        }
        /// <summary>
        /// Execute a OracleCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OracleConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-Oracle command</param>
        /// <param name="commandParameters">an array of OracleParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                using (OracleConnection conn = new OracleConnection(connString))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Execute a OracleCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-Oracle command</param>
        /// <param name="commandParameters">an array of OracleParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public object ExecuteScalar(OracleConnection conn, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();

                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();

                cmd.Parameters.Clear();
                return val;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>



        public DataTable ExecuteDataTable(OracleConnection conn, CommandType cmdType, string cmdText, OracleParameter[] cmdParms)
        {

            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da;

            DataTable dt;

            try
            {

                //PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

                dt = new DataTable();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;

                if (cmdParms != null)
                {
                    foreach (OracleParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }

                //create the DataAdapter & DataSet
                da = new OracleDataAdapter(cmd);

                //fill the DataSet using default values for DataTable names, etc.
                try
                {
                    da.Fill(dt);
                }

                catch (Exception ex)
                {
                    throw;
                }
                cmd.Parameters.Clear();

                //return the dataset
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public DataTable ExecuteDataTable(OracleConnection conn, CommandType cmdType, string cmdText)
        {
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da;

            DataTable dt;

            try
            {

                //PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

                dt = new DataTable();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;
                //create the DataAdapter & DataSet
                da = new OracleDataAdapter(cmd);
                //fill the DataSet using default values for DataTable names, etc.
                try
                {
                    da.Fill(dt);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                cmd.Parameters.Clear();

                //return the dataset
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public DataSet ExecuteDataset(OracleConnection conn, CommandType cmdType, string cmdText, OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da;
            //cmd.CommandTimeout = 600;
            DataSet ds;

            try
            {

                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

                ds = new DataSet();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;

                //create the DataAdapter & DataSet
                da = new OracleDataAdapter(cmd);
                //fill the DataSet using default values for DataTable names, etc.
                da.Fill(ds);

                cmd.Parameters.Clear();

                //return the dataset
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }
        public DataTable ExecuteDataTable(OracleConnection conn, CommandType cmdType, string cmdText, OracleParameter[] cmdParms, bool AssignDataTableName = true)
        {
            DataTable dt;

            try
            {

                dt = ExecuteDataTable(conn, cmdType, cmdText, cmdParms);

                if (AssignDataTableName == true)
                {
                    if (dt != null)
                    {
                        int ds_i = 0;
                        foreach (var parms in cmdParms)
                        {
                            if (parms.OracleType == OracleType.Cursor)
                            {
                                dt.TableName = parms.ParameterName;
                                ds_i++;
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of OracleParamters to be cached</param>
        public void CacheParameters(string cacheKey, params OracleParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached OracleParamters array</returns>
        public OracleParameter[] GetCachedParameters(string cacheKey)
        {
            OracleParameter[] cachedParms = (OracleParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OracleParameter[] clonedParms = new OracleParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OracleParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">OracleCommand object</param>
        /// <param name="conn">OracleConnection object</param>
        /// <param name="trans">OracleTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">OracleParameters to use in the command</param>
        private void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] cmdParms)
        {
            try
            {


                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = cmdText;

                if (trans != null)
                    cmd.Transaction = trans;

                cmd.CommandType = cmdType;

                if (cmdParms != null)
                {
                    foreach (OracleParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }
            }
            catch
            {
                throw;
            }

        }
    }
}
