using Godrej_Korber_Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_DAL
{
    public class ConfigurationDL
    {
        DataTable dtResult = new DataTable();
        OracleHelper  objOracle = new OracleHelper();

        public DataTable InsertConfigurationMasterOracle(ConfigurationMaster  configuration)
        {
            try {

                OracleParameter[] param = new OracleParameter[10];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.Int32;
                param[0].ParameterName = "CLIENT_ID";
                param[0].Value = configuration.CLIENT_ID;
                param[0].Direction = ParameterDirection.Input;

                param[1] = new OracleParameter();
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].ParameterName = "PAGE_ID";
                param[1].Value = configuration.PAGE_ID;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Int32;
                param[2].ParameterName = "TABLE_ID";
                param[2].Value = configuration.TABLE_ID;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].OracleDbType = OracleDbType.Int32;
                param[3].ParameterName = "COLUMN_ID";
                param[3].Value = configuration.COLUMN_ID;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].OracleDbType = OracleDbType.Varchar2;
                param[4].ParameterName = "DISPLAY_TEXT";
                param[4].Value = configuration.DISPLAY_TEXT;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].OracleDbType = OracleDbType.Int32;
                param[5].ParameterName = "DISPLAY_TYPE_ID";
                param[5].Value = configuration.DISPLAY_TYPE_ID;
                param[5].Direction = ParameterDirection.Input;

                param[6] = new OracleParameter();
                param[6].OracleDbType = OracleDbType.Char;
                param[6].ParameterName = "IS_REQUIRED";
                param[6].Value = configuration.IS_REQUIRED;
                param[6].Direction = ParameterDirection.Input;

                param[7] = new OracleParameter();
                param[7].OracleDbType = OracleDbType.Char;
                param[7].ParameterName = "IS_READONLY";
                param[7].Value = configuration.IS_READONLY;
                param[7].Direction = ParameterDirection.Input;

                param[8] = new OracleParameter();
                param[8].OracleDbType = OracleDbType.Varchar2;
                param[8].ParameterName = "CREATED_BY";
                param[8].Value = configuration.CREATED_BY;
                param[8].Direction = ParameterDirection.Input;

                param[9] = new OracleParameter();
                param[9].OracleDbType = OracleDbType.Varchar2;
                param[9].ParameterName = "UPDATED_BY";
                param[9].Value = configuration.UPDATED_BY;
                param[9].Direction = ParameterDirection.Input;

           

                dtResult = objOracle.ExecuteDataTable(objOracle.GetConnection(), CommandType.StoredProcedure, "INSERT_INTO_CONFIGURE_MASTER", param);
            }

            catch(Exception ex){

                throw  ex;
            
            }

            finally
            {
                objOracle.CloseConnection();
            }

            return dtResult;
        }


        public DataTable getConfigurationMaster()
        {
            dtResult = objOracle.ExecuteDataTable(objOracle.GetConnection(), CommandType.Text, "Select * from CONFIGURE_MASTER");

            return dtResult;
        }
  

    }
}
