
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
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
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(),CommandType.StoredProcedure,"ORDERVIEW.GET_STORE_OUT_DATA", param);
            return dtResult;

        }


        public DataTable Get_PalletDetails_Data( string partNo)
        {
            OracleParameter[] param = new OracleParameter[2];


            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;


            param[1] = new OracleParameter();
            param[1].OracleType = OracleType.VarChar;
            param[1].ParameterName = "PRD_COD";
            param[1].Value = partNo;
            param[1].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.GET_STOCK_COUNT_PALLET_DETAILS", param);
            return dtResult;
        }

        //public DataTable Insert_StockMovt_Update_StockItm(StoreOutModel  )
        //{
        //    //OracleParameter



        //    return dtResult;
        //}
    }
}
