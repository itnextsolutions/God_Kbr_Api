using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
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
			param[0].OracleType = OracleType.Cursor;
			param[0].ParameterName = "orde_rcursor";
			param[0].Direction = ParameterDirection.Output;

			dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.ORDERVIEW.ORDVIEW", param);// packagename.spname
			return dt;
		}

		public DataTable UpdateInOrderItm(HostToWmsModel wmsModel, int Hr)
		{

			OracleParameter[] param = new OracleParameter[3];

			try
			{
				param[0] = new OracleParameter();
				param[0].OracleType = OracleType.Int32;
				param[0].ParameterName = "O_ORD_ID ";
				param[0].Value = wmsModel.MSG_ORD_ID;
				param[0].Direction = ParameterDirection.Input;

				param[1] = new OracleParameter();
				param[1].OracleType = OracleType.Int32;
				param[1].ParameterName = "O_ORD_DT_REQUEST_Hr";
				param[1].Value = Hr;
				param[1].Direction = ParameterDirection.Input;

				param[2] = new OracleParameter();
				param[2].OracleType = OracleType.Cursor;
				param[2].ParameterName = "OCCUR";
				param[2].Direction = ParameterDirection.Output;

				//dt=oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.ORDERVIEW.UpdateOrdTimE", param);
				dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.UPDATE_ORDER_TIME", param);
				
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return dt;
		}
	}	
}


