using Godrej_Korber_Shared.Models.TataCummins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_DAL.TataCummins
{
    public class StoreRequestCancellationDL
    {

        OracleHelper objOracleHelper = new OracleHelper();
        DataTable dtResult = new DataTable();

        public DataTable GetStoreOutRequestCancellation()
        {
            OracleParameter[] param = new OracleParameter[1];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            
            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "STORE_REQUEST_CANCELLATION.GET_STORE_OUT_REQUEST_CANCELLATION", param);
            return dtResult;
        }

        public DataTable UpdateOrderItem(StoreRequestCancellationModel items)
        {
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "ID_ORD";
            param[1].OracleType = OracleType.Int32;
            param[1].Value = items.ORD_ID ;
            param[1].Direction = ParameterDirection.Input;



            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "STORE_REQUEST_CANCELLATION.UPDATE_IN_ORDER_ITEM", param);
            return dtResult;
        }
    }
}
