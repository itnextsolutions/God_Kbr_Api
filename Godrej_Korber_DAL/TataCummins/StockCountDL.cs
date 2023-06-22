using Godrej_Korber_Shared.Models.TataCummins;
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Godrej_Korber_DAL.TataCummins
{
    public class StockCountDL
    {
        OracleHelper objOracleHelper = new OracleHelper();
        DataTable dtResult = new DataTable();

        private readonly ILogger<StockCountDL> _logger;

        public StockCountDL(ILogger<StockCountDL> logger)
        {
            _logger = logger;
        }

        public DataTable GetStockCount(string headerValues)
        {
            try 
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_GET_PARTNO_GRNO_DATA", param);
                objOracleHelper.CloseConnection();

                if (dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived The Data Successfully By This User = "+ headerValues+ "By These Procedure = SP_GET_PARTNO_GRNO_DATA");

                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Not Retrived Data By This User = " + headerValues + "By These Procedure = SP_GET_PARTNO_GRNO_DATA");

                    return dtResult;
                }
                
            }

            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_GET_PARTNO_GRNO_DATA " + ex);
                return dtResult;
            }

        }
      

        public DataTable GetPalletDetails(string partno,string grno,string headerValues)
        {
            try 
            {
                OracleParameter[] param = new OracleParameter[3];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_STK_PRD_COD";
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].Value = partno;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter(); 
                param[2].ParameterName = "P_STK_REC_NR";
                param[2].OracleDbType = OracleDbType.Varchar2;
                param[2].Value = grno;
                param[2].Direction = ParameterDirection.Input;


                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_GET_STOCK_COUNT_PALLET_DETAILS", param);
                objOracleHelper.CloseConnection();
                if(dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived The Data Successfully By This User = " + headerValues + "By These Procedure = SP_GET_STOCK_COUNT_PALLET_DETAILS Where GR_NO = " + grno+ "And Part_NO = "+partno);
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Not Retrived Data  By This User = " + headerValues + "By These Procedure = SP_GET_STOCK_COUNT_PALLET_DETAILS Where GR_NO = " + grno+ "And Part_NO = "+partno);
                    return dtResult;
                }
            }

            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_GET_STOCK_COUNT_PALLET_DETAILS" + ex);
                return dtResult;
            }

        }

        public DataTable GetPalletDetails1(string headerValues)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;


                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_GETDETAILS1", param);
                objOracleHelper.CloseConnection();

                if (dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived The Data Successfully By This User = " + headerValues + "By These Procedure = SP_GETDETAILS1");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Not Retrived Data By This User = " + headerValues + "By These Procedure = SP_GETDETAILS1");

                    return dtResult;
                }
                
            }

            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_GETDETAILS1 " + ex);
                return dtResult;
            }
        }

        public DataTable GetValidCountForFurtherProcess(StockCountModel stockcount)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[2];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_MVT_PRD_COD";
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].Value = stockcount.STK_PRD_COD;
                param[1].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_GET_VALID_COUNT_FOR_FURTHER_PROCESS", param);
                objOracleHelper.CloseConnection();
                if(dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived Data Successfully!! By These Procedure = SP_GET_VALID_COUNT_FOR_FURTHER_PROCESS Where STK_PRD_COD Was = " +stockcount.STK_PRD_COD);

                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Not Retrived Data By These Procedure = SP_GET_VALID_COUNT_FOR_FURTHER_PROCESS Where STK_PRD_COD Was = " +stockcount.STK_PRD_COD);

                    return dtResult;
                }
            }
            catch(Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_GET_VALID_COUNT_FOR_FURTHER_PROCESS " + ex);
                return dtResult;
            }
            
        }

        public DataTable GetHuPar3(StockCountModel stockcount)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[2];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_HP_PAR2";
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].Value = stockcount.LOC_AISL_ID;
                param[1].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_GET_HUPAR3", param);
                objOracleHelper.CloseConnection();
                string hupar3 = Convert.ToString(dtResult.Rows[0][0]);
                if (dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived Data Successfully!! By These Procedure = SP_GET_HUPAR3 Where hupar3 =" + hupar3);

                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Not Retrived Data By These Procedure = SP_GET_HUPAR3 Where hupar3 =" + hupar3);

                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_GET_HUPAR3 " + ex);
                return dtResult;
            }
           
        }

        public DataTable UpdateInHunit(StockCountModel items, int hupar3)
        {

                OracleParameter[] param = new OracleParameter[3];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_HU_ID";
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].Value = items.HU_ID;
                param[1].Direction = ParameterDirection.Input;
             
                param[2] = new OracleParameter();
                param[2].ParameterName = "P_HU_PAR3";
                param[2].OracleDbType = OracleDbType.Varchar2;
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
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "P_STK_PRD_COD";
            param[1].OracleDbType = OracleDbType.Varchar2;
            param[1].Value = items.STK_PRD_COD;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "P_STK_PRD_QTY";
            param[2].OracleDbType = OracleDbType.Double;
            param[2].Value = items.STK_PRD_QTY;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].ParameterName = "P_HU_ID";
            param[3].OracleDbType = OracleDbType.Int32;
            param[3].Value = items.HU_ID;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].ParameterName = "P_USERNAME";
            param[4].OracleDbType = OracleDbType.Varchar2;
            param[4].Value = items.USERNAME;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].ParameterName = "P_USER_ID";
            param[5].OracleDbType = OracleDbType.Varchar2;
            param[5].Value = items.USER_ID;
            param[5].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_INSERT_INTO_STOCKMOVT", param);
            objOracleHelper.CloseConnection();
            return dtResult;
        }

        public DataTable UpdateAndInsert(StockCountModel items, int hupar3)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[7];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_STK_PRD_COD";
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].Value = items.STK_PRD_COD;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].ParameterName = "P_STK_PRD_QTY";
                param[2].OracleDbType = OracleDbType.Double;
                param[2].Value = items.STK_PRD_QTY;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].ParameterName = "P_HU_ID";
                param[3].OracleDbType = OracleDbType.Int32;
                param[3].Value = items.HU_ID;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].ParameterName = "P_USERNAME";
                param[4].OracleDbType = OracleDbType.Varchar2;
                param[4].Value = items.USERNAME;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].ParameterName = "P_USER_ID";
                param[5].OracleDbType = OracleDbType.Varchar2;
                param[5].Value = items.USER_ID;
                param[5].Direction = ParameterDirection.Input;

                param[6] = new OracleParameter();
                param[6].ParameterName = "P_PAR3_HU";
                param[6].OracleDbType = OracleDbType.Varchar2;
                param[6].Value = hupar3;
                param[6].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_UPDATE_AND_INSERT", param);
                objOracleHelper.CloseConnection();

                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + items.USERNAME + " Where STK_PRD_COD =" + items.STK_PRD_COD +"And HU_ID ="+ items.HU_ID+ "By These Procedure = SP_UPDATE_AND_INSERT");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully By These User =" + items.USERNAME + "  Where STK_PRD_COD =" + items.STK_PRD_COD + "And HU_ID =" + items.HU_ID + "By These Procedure = SP_UPDATE_AND_INSERT");
                    return dtResult;
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database By These Procedure = SP_UPDATE_AND_INSERT");
                    return dtResult;
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }
        
            
        }

        public DataTable StockCountByScannedId(int PalletId)
        {
            try
            {

                OracleParameter[] param = new OracleParameter[2];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_HU_ID";
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].Value = PalletId;
                param[1].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_STOCK_COUNT_BY_SCANNED_ID", param);
                objOracleHelper.CloseConnection();
                if(dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived Data Successfully!! By These Procedure = SP_STOCK_COUNT_BY_SCANNED_ID Where PalletID =" + PalletId);

                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Data not Retrived!! By These Procedure = SP_STOCK_COUNT_BY_SCANNED_ID Where PalletID =" + PalletId);

                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_STOCK_COUNT_BY_SCANNED_ID" + ex);
                return dtResult;
            }
            
        }

        public DataTable UpdateInsertForConfirmation(StockCountModel stockmodel)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[6];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_STK_PRD_QTY";
                param[1].OracleDbType = OracleDbType.Double;
                param[1].Value = stockmodel.STK_PRD_QTY;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].ParameterName = "P_HU_ID";
                param[2].OracleDbType = OracleDbType.Int32;
                param[2].Value = stockmodel.HU_ID;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].ParameterName = "P_STK_PRD_COD";
                param[3].OracleDbType = OracleDbType.Varchar2;
                param[3].Value = stockmodel.STK_PRD_COD;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].ParameterName = "P_USERNAME";
                param[4].OracleDbType = OracleDbType.Varchar2;
                param[4].Value = stockmodel.USERNAME;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].ParameterName = "P_USER_ID";
                param[5].OracleDbType = OracleDbType.Varchar2;
                param[5].Value = stockmodel.USER_ID;
                param[5].Direction = ParameterDirection.Input;


                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_STOCK_COUNT.SP_UPDATE_INSERT_FOR_CONFIRMATION", param);
                objOracleHelper.CloseConnection(); 
                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + stockmodel.USERNAME + " Where STK_PRD_COD =" + stockmodel.STK_PRD_COD + "And HU_ID =" + stockmodel.HU_ID + "BY These Procedure = SP_UPDATE_INSERT_FOR_CONFIRMATION");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully By These User =" + stockmodel.USERNAME + "  Where STK_PRD_COD =" + stockmodel.STK_PRD_COD + "And HU_ID =" + stockmodel.HU_ID + "BY These Procedure = SP_UPDATE_INSERT_FOR_CONFIRMATION");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database BY These Procedure = SP_UPDATE_INSERT_FOR_CONFIRMATION");
                    return dtResult;
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs BY These Procedure = SP_UPDATE_INSERT_FOR_CONFIRMATION " + ex);
                return dtResult;
            }
            
        }
        


    }
}
