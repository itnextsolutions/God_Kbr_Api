using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Godrej_Korber_Shared.Models;

namespace Godrej_Korber_DAL
{
	public  class OrderINViewDL
	{
		DataTable dt = new DataTable();
		OracleHelper oracle = new OracleHelper();
		SqlHelper objsqlHelper = new SqlHelper();
		List<SqlParameter> SqlParameters = new List<SqlParameter>();
		List<OracleParameter> OracleParameters = new List<OracleParameter>();

		public DataTable GetOrder_IN_View()
		{
			DataTable dt = new DataTable();
			OracleParameter[] param = new OracleParameter[1];
			param[0] = new OracleParameter();
			param[0].OracleDbType = OracleDbType.RefCursor;
			param[0].ParameterName = "order_cursor";
			param[0].Direction = ParameterDirection.Output;

             dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.ORDERVIEW.ORDVIEW", param);
            
            return dt;
		}

        public DataTable UpdateInOrderItm(HostToWmsModel wmsModel, int Hr)
        {

            OracleParameter[] param = new OracleParameter[3];

            try
            {                

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].ParameterName = "O_ORD_ID";
                param[1].Value = wmsModel.MSG_ORD_ID;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Int32;
                param[2].ParameterName = "O_ORD_DT_REQUEST_Hr";
                param[2].Value = Hr;
                param[2].Direction = ParameterDirection.Input;

                dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.ORDERVIEW.UpdateOrdTime", param);
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


    }	
}


