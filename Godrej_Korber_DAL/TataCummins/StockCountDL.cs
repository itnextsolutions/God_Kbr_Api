using Godrej_Korber_Shared.Models.TataCummins;
using System.Data;
using System.Data.OracleClient;

namespace Godrej_Korber_DAL.TataCummins
{
    public class StockCountDL
    {
        OracleHelper objOracleHelper = new OracleHelper();
        DataTable dtResult = new DataTable();

        public DataTable GetStockCount()
        {   
            OracleParameter[] param = new OracleParameter[1];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure,"TATA_CUMMINS_STOCK_COUNT.GET_PARTNO_GRNO_DATA",param);
            objOracleHelper.CloseConnection();
            return dtResult;

        }

        public DataTable GetPalletDetails(string partno,string grno)
        {
            OracleParameter[] param = new OracleParameter[3];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "PRD_COD";
            param[1].OracleType = OracleType.Int32;
            param[1].Value = partno;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "REC_POS";
            param[2].OracleType = OracleType.Int32;
            param[2].Value = grno;
            param[2].Direction = ParameterDirection.Input;

           
            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.GET_STOCK_COUNT_PALLET_DETAILS", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable GetPalletDetails1()
        {
            OracleParameter[] param = new OracleParameter[1];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;


            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.GETDETAILS1", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable GetValidCountForFurtherProcess(StockCountModel stockcount)
        {
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "PART_NO";
            param[1].OracleType = OracleType.Int32;
            param[1].Value = stockcount.STK_PRD_COD;
            param[1].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.GET_VALID_COUNT_FOR_FURTHER_PROCESS", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable GetHuPar3(StockCountModel stockcount)
        {
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "AISL_ID";
            param[1].OracleType = OracleType.Int32;
            param[1].Value = stockcount.LOC_AISL_ID;
            param[1].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.GET_HUPAR3", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable UpdateInHunit(StockCountModel items, int hupar3)
        {
            OracleParameter[] param = new OracleParameter[3];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Number;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "YOGESH";
            param[1].OracleType = OracleType.Int32;
            param[1].Value = items.HU_ID;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "AJIT";
            param[2].OracleType = OracleType.NVarChar;
            param[2].Value = hupar3;
            param[2].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.UPDATE_IN_HUNIT1", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable InsertIntoStockMovt(StockCountModel items)
        {
            OracleParameter[] param = new OracleParameter[6];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "STK_PRD_COD";
            param[1].OracleType = OracleType.VarChar;
            param[1].Value = items.STK_PRD_COD;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "STK_PRD_QTY";
            param[2].OracleType = OracleType.Int32;
            param[2].Value = items.STK_PRD_QTY;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].ParameterName = "HU_ID";
            param[3].OracleType = OracleType.Int32;
            param[3].Value = items.HU_ID;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].ParameterName = "USERNAME";
            param[4].OracleType = OracleType.VarChar;
            param[4].Value = items.USERNAME;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].ParameterName = "USER_ID";
            param[5].OracleType = OracleType.VarChar;
            param[5].Value = items.USER_ID;
            param[5].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.INSERT_INTO_STOCKMOVT", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable UpdateAndInsert(StockCountModel items, int hupar3)
        {
            OracleParameter[] param = new OracleParameter[7];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "STK_PRD_COD";
            param[1].OracleType = OracleType.VarChar;
            param[1].Value = items.STK_PRD_COD;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "STK_PRD_QTY";
            param[2].OracleType = OracleType.Int32;
            param[2].Value = items.STK_PRD_QTY;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].ParameterName = "ID_HU";
            param[3].OracleType = OracleType.Int32;
            param[3].Value = items.HU_ID;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].ParameterName = "USERNAME";
            param[4].OracleType = OracleType.VarChar;
            param[4].Value = items.USERNAME;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].ParameterName = "USER_ID";
            param[5].OracleType = OracleType.VarChar;
            param[5].Value = items.USER_ID;
            param[5].Direction = ParameterDirection.Input;

            param[6] = new OracleParameter();
            param[6].ParameterName = "PAR3_HU";
            param[6].OracleType = OracleType.NVarChar;
            param[6].Value = hupar3;
            param[6].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.UPDATE_AND_INSERT", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable StockCountByScannedId(int PalletId)
        {
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "ID_HU";
            param[1].OracleType = OracleType.Int32;
            param[1].Value = PalletId;
            param[1].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.STOCK_COUNT_BY_SCANNED_ID", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable UpdateInsertForConfirmation(StockCountModel stockmodel)
        {
            OracleParameter[] param = new OracleParameter[6];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "AVA_QTY";
            param[1].OracleType = OracleType.VarChar;
            param[1].Value = stockmodel.STK_PRD_QTY;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "ID_HU";
            param[2].OracleType = OracleType.Int32;
            param[2].Value = stockmodel.HU_ID;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].ParameterName = "PART_NO";
            param[3].OracleType = OracleType.Int32;
            param[3].Value = stockmodel.STK_PRD_COD;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].ParameterName = "USERNAME";
            param[4].OracleType = OracleType.VarChar;
            param[4].Value = stockmodel.USERNAME;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].ParameterName = "USER_ID";
            param[5].OracleType = OracleType.VarChar;
            param[5].Value = stockmodel.USER_ID;
            param[5].Direction = ParameterDirection.Input;


            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.UPDATE_INSERT_FOR_CONFIRMATION", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }
        


    }
}
