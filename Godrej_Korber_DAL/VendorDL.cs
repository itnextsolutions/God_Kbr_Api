using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godrej_Korber_Shared.Models;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;


namespace Godrej_Korber_DAL
{
    public class VendorDL
    {
        DataTable dtResult = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        OracleHelper objOracle = new OracleHelper();        


        public DataTable getVendorMaster()
        {

            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";

                param[0].Direction = ParameterDirection.Output;

                dtResult = objOracle.ExecuteDataTable(objOracle.GetConnection(), CommandType.StoredProcedure, "WMS_VENDOR.GET_VENDOR_MASTER", param);

                
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
            finally { 
                objOracle.CloseConnection(); 
            }
            return dtResult;
        }




    }
}
