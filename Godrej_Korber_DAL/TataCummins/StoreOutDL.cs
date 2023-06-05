
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Godrej_Korber_Shared.Models.TataCummins;

namespace Godrej_Korber_DAL.TataCummins
{
    public class StoreOutDL
    {
        OracleHelper objOracleHelper = new OracleHelper();
        DataTable dtResult = new DataTable();

        public DataTable Get_Store_Out_Data()
        {
            OracleParameter[] param = new OracleParameter[1];

            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(),CommandType.StoredProcedure,"ORDERVIEW.GET_STORE_OUT_DATA", param);
            return dtResult;

        }


        public DataTable Get_PalletDetails_Data( string partNo)
        {
            OracleParameter[] param = new OracleParameter[2];


            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;


            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.Varchar2;
            param[1].ParameterName = "PRD_COD";
            param[1].Value = partNo;
            param[1].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.GET_STOCK_COUNT_PALLET_DETAILS", param);
            return dtResult;
        }

        public DataTable Insert_StockMovt(StoreOutModel  modelStoreOut )
        {
            OracleParameter[] param = new OracleParameter[7];

            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";;
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.Varchar2;
            param[1].ParameterName = "MSG_PRD_COD";
            param[1].Value = modelStoreOut.STK_PRD_COD;
            param[1].Direction = ParameterDirection.Input;

            
            param[2] = new OracleParameter();
            param[2].OracleDbType = OracleDbType.Int32;
            param[2].ParameterName = "MSG_PRD_QTY";
            param[2].Value = modelStoreOut.STK_RSV_QTY;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].OracleDbType = OracleDbType.Int32;
            param[3].ParameterName = "MSG_DST_QTY";
            param[3].Value = modelStoreOut.STK_PRD_QTY;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].OracleDbType = OracleDbType.Int32;
            param[4].ParameterName = "MSG_HU_ID";
            param[4].Value = modelStoreOut.HU_ID;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].OracleDbType = OracleDbType.Varchar2;
            param[5].ParameterName = "MSG_EXE_USER";
            param[5].Value = modelStoreOut.EXE_USER;
            param[5].Direction = ParameterDirection.Input;

            param[6] = new OracleParameter();
            param[6].OracleDbType = OracleDbType.Varchar2;
            param[6].ParameterName = "MSG_EXE_WKS_ID";
            param[6].Value = modelStoreOut.EXE_WKS_ID;
            param[6].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.INSERT_INTO_STOCKMOVT", param);
            return dtResult;

        }


        public DataTable Insert_and_update_storeOutData(StoreOutModel modelStoreOut)
        {
            OracleParameter[] param = new OracleParameter[8];

            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR"; ;
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.Varchar2;
            param[1].ParameterName = "MSG_PRD_COD";
            param[1].Value = modelStoreOut.STK_PRD_COD;
            param[1].Direction = ParameterDirection.Input;


            param[2] = new OracleParameter();
            param[2].OracleDbType = OracleDbType.Int32;
            param[2].ParameterName = "MSG_PRD_QTY";
            param[2].Value = modelStoreOut.STK_RSV_QTY;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].OracleDbType = OracleDbType.Int32;
            param[3].ParameterName = "MSG_RSV_QTY";
            param[3].Value = modelStoreOut.STK_PRD_QTY;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].OracleDbType = OracleDbType.Int32;
            param[4].ParameterName = "MSG_HU_ID";
            param[4].Value = modelStoreOut.HU_ID;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].OracleDbType = OracleDbType.Varchar2;
            param[5].ParameterName = "MSG_EXE_USER";
            param[5].Value = modelStoreOut.EXE_USER;
            param[5].Direction = ParameterDirection.Input;

            param[6] = new OracleParameter();
            param[6].OracleDbType = OracleDbType.Varchar2;
            param[6].ParameterName = "MSG_EXE_WKS_ID";
            param[6].Value = modelStoreOut.EXE_WKS_ID;
            param[6].Direction = ParameterDirection.Input;

            param[7] = new OracleParameter();
            param[7].OracleDbType = OracleDbType.Int32;
            param[7].ParameterName = "MSG_PARTIAL";
            param[7].Value = modelStoreOut.PARTIAL;
            param[7].Direction= ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.Insert_and_update_storeOutData", param);

            return dtResult;
        }
    }
}
