using Godrej_Korber_Shared.Models.TataCummins;
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Logging;

namespace Godrej_Korber_DAL.TataCummins
{
    public class StoreRequestCancellationDL
    {

        OracleHelper objOracleHelper = new OracleHelper();
        DataTable dtResult = new DataTable();

        private readonly ILogger<StoreRequestCancellationDL> _logger;

        public StoreRequestCancellationDL(ILogger<StoreRequestCancellationDL> logger)
        {
            _logger = logger;
        }

        public DataTable GetStoreOutRequestCancellation(string Username)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "STORE_REQUEST_CANCELLATION.SP_GET_STORE_OUT_REQUEST_CANCELLATION", param);
               
                if (dtResult != null)
                {
                    _logger.LogInformation("Retrived The Data Successfully By This User = " + Username + "By These Procedure = SP_GET_STORE_OUT_REQUEST_CANCELLATION");

                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Data Has Not Been Retrived By This User = " + Username + "By These Procedure = SP_GET_STORE_OUT_REQUEST_CANCELLATION");

                    return dtResult;
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_GET_STORE_OUT_REQUEST_CANCELLATION " + ex);
                return dtResult;
            }
        }

        public DataTable UpdateOrderItem(StoreRequestCancellationModel items,string Username)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[2];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_ORD_ID";
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].Value = items.ORD_ID;
                param[1].Direction = ParameterDirection.Input;
                
                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "STORE_REQUEST_CANCELLATION.SP_UPDATE_IN_ORDER_ITEM", param);
                
                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + Username+ " Which Is ORD_ID = "+ items.ORD_ID + "By These Procedure = SP_UPDATE_IN_ORDER_ITEM");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully By These User =" + Username+ " Which Is ORD_ID = "+ items.ORD_ID + " By These Procedure = SP_UPDATE_IN_ORDER_ITEM");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database By These Procedure = SP_UPDATE_IN_ORDER_ITEM");
                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_UPDATE_IN_ORDER_ITEM " + ex);
                return dtResult;
            }

        }

        public DataTable GetRequestINCancelletion(string Username)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].ParameterName = "OCUR";
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].Direction = ParameterDirection.Output;
                
                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "STORE_REQUEST_CANCELLATION.SP_TATACUMMINSREQUESTINCANCELLETION", param);

                if (dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived The Data Successfully By This User = " + Username + "By These Procedure = SP_TATACUMMINSREQUESTINCANCELLETION");

                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("Data Has Not been By This User = " + Username + "By These Procedure = SP_TATACUMMINSREQUESTINCANCELLETION");

                    return dtResult;
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_TATACUMMINSREQUESTINCANCELLETION" + ex);
                return dtResult;
            }

        }

        public DataTable UpdateRequestCancelletion(StoreRequestCancellationModel data,string Username)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[2];

                param[0] = new OracleParameter();
                param[0].ParameterName = "OCUR";
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_HU_ID";
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].Value = data.HU_ID;
                param[1].Direction = ParameterDirection.Input;

                dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "STORE_REQUEST_CANCELLATION.SP_UPDATE_IN_HUNIT", param);

                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + Username + " Which Is HU_ID =" + data.HU_ID + "By These Procedure = SP_UPDATE_IN_HUNIT");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully By These User =" + Username + " Which Is HU_ID =" + data.HU_ID + "By These Procedure = SP_UPDATE_IN_HUNIT");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database By These Procedure = SP_UPDATE_IN_HUNIT");
                    return dtResult;
                }
            }
            catch(Exception ex) 
            {
                _logger.LogWarning("Exception Occurs By These Procedure = SP_UPDATE_IN_HUNIT" + ex);
                return dtResult;
            }
           

        }
    }
}
