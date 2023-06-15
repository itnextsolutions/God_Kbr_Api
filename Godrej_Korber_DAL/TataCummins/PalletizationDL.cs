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
                param[1].ParameterName = "GR_NO";
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].Value = gr_no;
                param[1].Direction = ParameterDirection.Input;

                dtResult = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_PALLETISATION.SP_GET_PALLETISATION_DATA", param);
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
                OracleParameter[] param = new OracleParameter[3];

                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].ParameterName = "P_ORD_REQ_QTY";
                param[1].OracleDbType = OracleDbType.Double;
                param[1].Value = Data.ORD_REQ_QTY;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].ParameterName = "P_ORD_ID";
                param[2].OracleDbType = OracleDbType.Int32;
                param[2].Value = Data.ORD_ID;
                param[2].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].ParameterName = "UserName";
                param[4].OracleDbType = OracleDbType.Int32;
                param[4].Value = Data.UserName;
                param[4].Direction = ParameterDirection.Input;

                param[5] = new OracleParameter();
                param[5].ParameterName = "UserID";
                param[5].OracleDbType = OracleDbType.Int32;
                param[5].Value = Data.UserID;
                param[5].Direction = ParameterDirection.Input;

                dtResult = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_PALLETISATION.SP_UPDATE_INSERT_PALLETIZATION", param);
               
                int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + Data.UserName + " Where ORD_ID ="+Data.ORD_ID);
                    return dtResult;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully By These User =" + Data.UserName + "  Where STK_PRD_COD ="  );
                    return dtResult;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database");
                    return dtResult;
                }
            }
            catch(Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }
        }
    }
}
