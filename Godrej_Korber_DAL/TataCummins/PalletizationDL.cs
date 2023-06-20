using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.Extensions.Logging;

namespace Godrej_Korber_DAL.TataCummins
{
    public class PalletizationDL
    {
        DataTable dtResult = new DataTable();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();

        private readonly ILogger<PalletizationDL> _logger;

        public PalletizationDL(ILogger<PalletizationDL> logger)
        {
            _logger = logger;
        }


        public DataTable GetEmptyPalletOut(string gr_no)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[2];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "MSG_GR_NO";
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].Value = gr_no;
                param[1].Direction = ParameterDirection.Input;

                dtResult = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_PALLETISATION.SP_GET_PALLETISATION_DATA", param);
                if(dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Data Retrived Sucessfully!!! BY These Procedure = SP_GET_PALLETISATION_DATA ");
                }
                else
                {
                    _logger.LogInformation("Data Not Found!!! BY These Procedure = SP_GET_PALLETISATION_DATA ");
                }
                return dtResult;
            }
            catch(Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }
            
        }
         
        public DataTable UpdateInsert(PalletizationModel Data)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[12];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "MSG_ORD_REQ_QTY";
                param[1].OracleDbType = OracleDbType.Double;
                param[1].Value = Data.ORD_REQ_QTY;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].ParameterName = "MSG_ORD_ID";
                param[2].OracleDbType = OracleDbType.Int32;
                param[2].Value = Data.ORD_ID;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].ParameterName = "MSG_USERNAME";
                param[3].OracleDbType = OracleDbType.Varchar2;
                param[3].Value = Data.UserName;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].ParameterName = "MSG_USER_WKS_ID";
                param[4].OracleDbType = OracleDbType.Varchar2;
                param[4].Value = Data.UserID;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].ParameterName = "MSG_ORD_PRD_COD";
                param[5].OracleDbType = OracleDbType.Varchar2;
                param[5].Value = Data.ORD_PRD_COD;
                param[5].Direction = ParameterDirection.Input;

                param[6] = new OracleParameter();
                param[6].ParameterName = "MSG_HU_ID";
                param[6].OracleDbType = OracleDbType.Int32;
                param[6].Value = Data.ORD_HU_ID;
                param[6].Direction = ParameterDirection.Input;

                param[7] = new OracleParameter();
                param[7].ParameterName = "MSG_ORD_INSPECT_NR";
                param[7].OracleDbType = OracleDbType.Varchar2;
                param[7].Value = Data.ORD_INSPECT_NR;
                param[7].Direction = ParameterDirection.Input;

                param[8] = new OracleParameter();
                param[8].ParameterName = "MSG_ORD_REF_NR";
                param[8].OracleDbType = OracleDbType.Varchar2;
                param[8].Value = Data.ORD_REF_NR;
                param[8].Direction = ParameterDirection.Input;

                param[9] = new OracleParameter();
                param[9].ParameterName = "MSG_SHELF_LIFE";
                param[9].OracleDbType = OracleDbType.Double;
                param[9].Value = Data.ORD_RSV_QTY;
                param[9].Direction = ParameterDirection.Input;

                param[10] = new OracleParameter();
                param[10].ParameterName = "MSG_GR_NO";
                param[10].OracleDbType = OracleDbType.Varchar2;
                param[10].Value = Data.ORD_REC_NR;
                param[10].Direction = ParameterDirection.Input;

                param[11] = new OracleParameter();
                param[11].ParameterName = "MSG_ORD_HU_BAR_COD";
                param[11].OracleDbType = OracleDbType.Varchar2;
                param[11].Value = Data.ORD_HU_BAR_COD;
                param[11].Direction = ParameterDirection.Input;


                dtResult = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_PALLETISATION.SP_UPDATE_INSERT_PALLETIZATION", param);

                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + Data.UserName + " Where ORD_ID =" + Data.ORD_ID + "By These Procedure = SP_UPDATE_INSERT_PALLETIZATION ");
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully By These User =" + Data.UserName + " Where ORD_ID =" + Data.ORD_ID + "By These Procedure = SP_UPDATE_INSERT_PALLETIZATION ");
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database By These Procedure = SP_UPDATE_INSERT_PALLETIZATION ");
                    return dtResult;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }
        }
    }
}
