using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;


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


        public DataTable Get_PalletDetails_Data(FetchPallet fetchPallet )
        {
            try
            {
                OracleParameter[] param = new OracleParameter[5];

               

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].ParameterName = "PRD_COD";
                param[1].Value = fetchPallet.ORD_PRD_COD;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Varchar2;
                param[2].ParameterName = "MSG_ORG_NAME";
                param[2].Value = fetchPallet.ORD_SUPL_COD;
                param[2].Direction = ParameterDirection.Input;


                param[3] = new OracleParameter();
                param[3].OracleDbType = OracleDbType.Varchar2;
                param[3].ParameterName = "MSG_ORD_PAR1";
                param[3].Value = fetchPallet.ORD_PAR1;
                param[3].Direction = ParameterDirection.Input;


                param[4] = new OracleParameter();
                param[4].OracleDbType = OracleDbType.Varchar2;
                param[4].ParameterName = "MSG_ORD_PAR2";
                param[4].Value = fetchPallet.ORD_PAR2;
                param[4].Direction = ParameterDirection.Input;



                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.GET_STORE_OUT_PALLET_DETAILS", param);

                if (dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Data Has Been Retrived Successfully Requested PRD_COD Was = " + fetchPallet.ORD_PRD_COD + " BY These Procedure = GET_STORE_OUT_PALLET_DETAILS ");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Data Has not Been Retrived!! Requested PRD_COD Was = " + fetchPallet.ORD_PRD_COD + " BY These Procedure = GET_STORE_OUT_PALLET_DETAILS ");
                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs  BY These Procedure = GET_STORE_OUT_PALLET_DETAILS " + ex);
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

       
        public DataTable Insert_and_update_storeOutData(StoreOutModel storeOutData)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[13];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR"; ;
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].ParameterName = "MSG_PRD_COD";
                param[1].Value = storeOutData.STK_PRD_COD;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Double;
                param[2].ParameterName = "MSG_PRD_QTY";
                param[2].Value = storeOutData.STK_PRD_QTY;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].OracleDbType = OracleDbType.Double;
                param[3].ParameterName = "MSG_RSV_QTY";
                param[3].Value = storeOutData.STK_RSV_QTY;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].OracleDbType = OracleDbType.Int32;
                param[4].ParameterName = "MSG_HU_ID";
                param[4].Value = storeOutData.HU_ID;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].OracleDbType = OracleDbType.Varchar2;
                param[5].ParameterName = "MSG_EXE_USER";
                param[5].Value = storeOutData.EXE_USER;
                param[5].Direction = ParameterDirection.Input;

                param[6] = new OracleParameter();
                param[6].OracleDbType = OracleDbType.Varchar2;
                param[6].ParameterName = "MSG_EXE_WKS_ID";
                param[6].Value = storeOutData.EXE_WKS_ID;
                param[6].Direction = ParameterDirection.Input;

                param[7] = new OracleParameter();
                param[7].OracleDbType = OracleDbType.Int32;
                param[7].ParameterName = "MSG_ORD_ID";
                param[7].Value = storeOutData.ORD_ID;
                param[7].Direction = ParameterDirection.Input;

                param[8] = new OracleParameter();
                param[8].OracleDbType = OracleDbType.Int32;
                param[8].ParameterName = "MSG_STK_ID";
                param[8].Value = storeOutData.STK_ID;
                param[8].Direction = ParameterDirection.Input;

                param[9] = new OracleParameter();
                param[9].OracleDbType = OracleDbType.Varchar2;
                param[9].ParameterName = "MSG_ORD_REC_POS";
                param[9].Value = storeOutData.ORD_REC_POS;
                param[9].Direction = ParameterDirection.Input;

                param[10] = new OracleParameter();
                param[10].OracleDbType = OracleDbType.Varchar2;
                param[10].ParameterName = "MSG_PRD_DESC";
                param[10].Value = storeOutData.PRD_DESC;
                param[10].Direction = ParameterDirection.Input;

                param[11] = new OracleParameter();
                param[11].OracleDbType = OracleDbType.Varchar2;
                param[11].ParameterName = "MSG_ORD_REC_NR";
                param[11].Value = storeOutData.ORD_REC_NR;
                param[11].Direction = ParameterDirection.Input;

                param[12] = new OracleParameter();
                param[12].OracleDbType = OracleDbType.Varchar2;
                param[12].ParameterName = "MSG_ORG_NAME";
                param[12].Value = storeOutData.ORD_SUPL_COD;
                param[12].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.Insert_and_update_storeOutData_1", param);

                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + storeOutData.EXE_USER + " Where STK_ID " + storeOutData.STK_ID + " And ORD_ID " + storeOutData.ORD_ID + " And STK_PRD_COD =" + storeOutData.STK_PRD_COD + "And RSV_QTY =" + storeOutData.STK_RSV_QTY +  "By These Procedure = Insert_and_update_storeOutData");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted By These User =" + storeOutData.EXE_USER + " Where STK_ID " + storeOutData.STK_ID + " And ORD_ID " + storeOutData.ORD_ID + " And STK_PRD_COD =" + storeOutData.STK_PRD_COD + "And RSV_QTY =" + storeOutData.STK_RSV_QTY + "By These Procedure = Insert_and_update_storeOutData");
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


        //public DataTable Insert_and_update_storeOutData(StoreOutModel modelStoreOut)
        //{
        //    try
        //    {
        //        OracleParameter[] param = new OracleParameter[9];

        //        param[0] = new OracleParameter();
        //        param[0].OracleDbType = OracleDbType.RefCursor;
        //        param[0].ParameterName = "OCUR"; ;
        //        param[0].Direction = ParameterDirection.Output;

        //        param[1] = new OracleParameter();
        //        param[1].OracleDbType = OracleDbType.Varchar2;
        //        param[1].ParameterName = "MSG_PRD_COD";
        //        param[1].Value = modelStoreOut.STK_PRD_COD;
        //        param[1].Direction = ParameterDirection.Input;

        //        param[2] = new OracleParameter();
        //        param[2].OracleDbType = OracleDbType.Int32;
        //        param[2].ParameterName = "MSG_PRD_QTY";
        //        param[2].Value = modelStoreOut.STK_RSV_QTY;
        //        param[2].Direction = ParameterDirection.Input;

        //        param[3] = new OracleParameter();
        //        param[3].OracleDbType = OracleDbType.Int32;
        //        param[3].ParameterName = "MSG_RSV_QTY";
        //        param[3].Value = modelStoreOut.STK_PRD_QTY;
        //        param[3].Direction = ParameterDirection.Input;

        //        param[4] = new OracleParameter();
        //        param[4].OracleDbType = OracleDbType.Int32;
        //        param[4].ParameterName = "MSG_HU_ID";
        //        param[4].Value = modelStoreOut.HU_ID;
        //        param[4].Direction = ParameterDirection.Input;

        //        param[5] = new OracleParameter();
        //        param[5].OracleDbType = OracleDbType.Varchar2;
        //        param[5].ParameterName = "MSG_EXE_USER";
        //        param[5].Value = modelStoreOut.EXE_USER;
        //        param[5].Direction = ParameterDirection.Input;

        //        param[6] = new OracleParameter();
        //        param[6].OracleDbType = OracleDbType.Varchar2;
        //        param[6].ParameterName = "MSG_EXE_WKS_ID";
        //        param[6].Value = modelStoreOut.EXE_WKS_ID;
        //        param[6].Direction = ParameterDirection.Input;

        //        param[7] = new OracleParameter();
        //        param[7].OracleDbType = OracleDbType.Int32;
        //        param[7].ParameterName = "MSG_PARTIAL";
        //        param[7].Value = modelStoreOut.PARTIAL;
        //        param[7].Direction = ParameterDirection.Input;

        //        param[8] = new OracleParameter();
        //        param[8].OracleDbType = OracleDbType.Int32;
        //        param[8].ParameterName = "MSG_STK_ID";
        //        param[8].Value = modelStoreOut.STK_ID;
        //        param[8].Direction = ParameterDirection.Input;

        //        dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.Insert_and_update_storeOutData", param);

        //        int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
        //        if (UpdateOutput == 0)
        //        {
        //            _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + modelStoreOut.EXE_USER + " Where STK_PRD_COD =" + modelStoreOut.STK_PRD_COD + "And RSV_QTY =" + modelStoreOut.STK_PRD_QTY + " And PARTIAL " + modelStoreOut.PARTIAL + "By These Procedure = Insert_and_update_storeOutData");
        //            return dtResult;
        //        }
        //        else if (UpdateOutput == 1)
        //        {
        //            _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + modelStoreOut.EXE_USER + " Where STK_PRD_COD =" + modelStoreOut.STK_PRD_COD + "And RSV_QTY =" + modelStoreOut.STK_PRD_QTY + " And PARTIAL " + modelStoreOut.PARTIAL + "By These Procedure = Insert_and_update_storeOutData");
        //            return dtResult;
        //        }
        //        else
        //        {
        //            _logger.LogInformation("NO, Response From Database By These Procedure = Insert_and_update_storeOutData");
        //            return dtResult;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogWarning("Exception Occurs By These Procedure = Insert_and_update_storeOutData " + ex);
        //        return dtResult;
        //    }
        //}


        public DataTable Insert_Into_OrderItm(OrderData  data)
        {
            try
            {

                OracleParameter[] param = new OracleParameter[9];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].ParameterName = "MSG_ORG_NAME";
                param[1].Value = data.ORD_SUPL_COD;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Varchar2;
                param[2].ParameterName = "MSG_DESCRIPTION";
                param[2].Value = data.ORD_PAR3;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].OracleDbType = OracleDbType.Varchar2;
                param[3].ParameterName = "MSG_PART_NO";
                param[3].Value = data.ORD_PRD_COD;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].OracleDbType = OracleDbType.Double;
                param[4].ParameterName = "MSG_REQ_QTY";
                param[4].Value = data.ORD_REQ_QTY;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].OracleDbType = OracleDbType.Varchar2;
                param[5].ParameterName = "MSG_EXE_USER";
                param[5].Value = data.EXE_USER;
                param[5].Direction = ParameterDirection.Input;

                param[6] = new OracleParameter();
                param[6].OracleDbType = OracleDbType.Varchar2;
                param[6].ParameterName = "MSG_EXE_WKS_ID";
                param[6].Value = data.EXE_WKS_ID;
                param[6].Direction = ParameterDirection.Input;

                param[7] = new OracleParameter();
                param[7].OracleDbType = OracleDbType.Varchar2;
                param[7].ParameterName = "MSG_ORD_PAR1";
                param[7].Value = data.ORD_PAR1;
                param[7].Direction = ParameterDirection.Input;

                param[8] = new OracleParameter();
                param[8].OracleDbType = OracleDbType.Varchar2;
                param[8].ParameterName = "MSG_ORD_PAR2";
                param[8].Value = data.ORD_PAR2;
                param[8].Direction = ParameterDirection.Input;



                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STORE_OUT.Insert_Into_OrderItm", param);
                return dtResult;
            }
            catch(Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = Insert_Order_Item " + ex);
                return dtResult;
            }
        }
    }
}
