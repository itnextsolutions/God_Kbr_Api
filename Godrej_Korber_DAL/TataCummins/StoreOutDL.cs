using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.Extensions.Logging;

namespace Godrej_Korber_DAL.TataCummins
{
    public class StoreOutDL
    {
        OracleHelper objOracleHelper = new OracleHelper();
        DataTable dtResult = new DataTable();


        private readonly ILogger<StoreOutDL> _logger;

        public StoreOutDL(ILogger<StoreOutDL> logger)
        {
            _logger = logger;
        }

        public DataTable Get_Store_Out_Data()
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.GET_STORE_OUT_DATA", param);
                if (dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived The Data Successfully By These Procedure = GET_STORE_OUT_DATA");

                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Not Retrived Data By These Procedure = GET_STORE_OUT_DATA");

                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }

        }


        public DataTable Get_PalletDetails_Data(string partNo)
        {
            try
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

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.GET_STORE_OUT_PALLET_DETAILS", param);

                if (dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Data Has Been Retrived Successfully Requested PRD_COD Was = " + partNo + " BY These Procedure = GET_STORE_OUT_PALLET_DETAILS ");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Data Has not Been Retrived!! Requested PRD_COD Was = " + partNo + " BY These Procedure = GET_STORE_OUT_PALLET_DETAILS ");
                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs  BY These Procedure = GET_STORE_OUT_PALLET_DETAILS " + ex);
                return dtResult;
            }
        }

        public DataTable Update_Orderitm(OrderItm data)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[6];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].ParameterName = "MSG_ORD_ID";
                param[1].Value = data.ORD_ID;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Double;
                param[2].ParameterName = "MSG_RSV_QTY";
                param[2].Value = data.RSV_QTY;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].OracleDbType = OracleDbType.Int32;
                param[3].ParameterName = "ORD_PARTIAL";
                param[3].Value = data.ORD_PARTIAL;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].OracleDbType = OracleDbType.Varchar2;
                param[4].ParameterName = "MSG_EXE_USER";
                param[4].Value = data.EXE_USER;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].OracleDbType = OracleDbType.Varchar2;
                param[5].ParameterName = "MSG_EXE_WKS_ID";
                param[5].Value = data.EXE_WKS_ID;
                param[5].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.UPDATE_ORDERITM", param);

                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + data.EXE_USER + " Where ORD_ID =" + data.ORD_ID + "And RSV_QTY =" + data.RSV_QTY + " And ORD_PARTIAL " + data.ORD_PARTIAL + "By These Procedure = UPDATE_ORDERITM");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted By These User =" + data.EXE_USER + " Where ORD_ID =" + data.ORD_ID + "And RSV_QTY =" + data.RSV_QTY + " And ORD_PARTIAL " + data.ORD_PARTIAL + "By These Procedure = UPDATE_ORDERITM");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database By These Procedure = UPDATE_ORDERITM");
                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = UPDATE_ORDERITM " + ex);
                return dtResult;
            }
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
            try
            {
                OracleParameter[] param = new OracleParameter[9];

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
                param[7].Direction = ParameterDirection.Input;

                param[8] = new OracleParameter();
                param[8].OracleDbType = OracleDbType.Int32;
                param[8].ParameterName = "MSG_STK_ID";
                param[8].Value = modelStoreOut.STK_ID;
                param[8].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.Insert_and_update_storeOutData", param);

                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + modelStoreOut.EXE_USER + " Where STK_PRD_COD =" + modelStoreOut.STK_PRD_COD + "And RSV_QTY =" + modelStoreOut.STK_PRD_QTY + " And PARTIAL " + modelStoreOut.PARTIAL + "By These Procedure = Insert_and_update_storeOutData");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + modelStoreOut.EXE_USER + " Where STK_PRD_COD =" + modelStoreOut.STK_PRD_COD + "And RSV_QTY =" + modelStoreOut.STK_PRD_QTY + " And PARTIAL " + modelStoreOut.PARTIAL + "By These Procedure = Insert_and_update_storeOutData");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database By These Procedure = Insert_and_update_storeOutData");
                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = Insert_and_update_storeOutData " + ex);
                return dtResult;
            }
        }
    }
}
