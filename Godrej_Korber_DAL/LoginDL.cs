using Oracle.ManagedDataAccess.Client;
using System.Data;
using Godrej_Korber_Shared.Models;
using Microsoft.Extensions.Logging;
using System.Runtime.Intrinsics.Arm;

namespace Godrej_Korber_DAL
{
    public class LoginDL
    {
        DataTable dtResult = new DataTable();
        OracleHelper objoracleHelper = new OracleHelper();

        private readonly ILogger<LoginDL> _logger;

        public LoginDL(ILogger<LoginDL> logger)
        {
            _logger = logger;
        }


        public DataTable Login(string username)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].ParameterName = "Username";
                param[0].OracleDbType = OracleDbType.Varchar2;
                param[0].Value = username;
                param[0].Direction = ParameterDirection.Input;

                dtResult = objoracleHelper.ExecuteDataTable(objoracleHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLogin", param);
                if (dtResult.Rows.Count > 0)
                { 
                    _logger.LogInformation("Got The UserName ");
                }
                return dtResult;
            }
            catch(Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }
           
        }
        public DataTable GetLoginDetail(LoginModel loginData,string pass)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[3];

                param[0] = new OracleParameter();
                param[0].ParameterName = "LS_RESULT";
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].Direction = ParameterDirection.Output;


                param[1] = new OracleParameter();
                param[1].ParameterName = "MSG_USERNAME";
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].Value = loginData.username;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].ParameterName = "MSG_PASSWORD";
                param[2].OracleDbType = OracleDbType.Varchar2;
                param[2].Value = pass;
                param[2].Direction = ParameterDirection.Input;

                dtResult = objoracleHelper.ExecuteDataTable(objoracleHelper.GetConnection(), CommandType.StoredProcedure, "SP_GET_LOGIN_DETAILS", param);
                if(dtResult.Rows.Count > 0)
                {
                    _logger.LogInformation("Logged In!!!!");
                    return dtResult;
                }
                return dtResult;
                
            }
           catch(Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }
         }

        public DataTable GetUsers()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = objoracleHelper.ExecuteDataTable(objoracleHelper.GetConnection(), CommandType.StoredProcedure, "MRFWMS.GetAllUsers", param);
            return dt;
        }

        public DataTable Get_User_Role(string User_Group)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[2];

                param[0] = new OracleParameter();
                param[0].ParameterName = "OCUR";
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].Direction = ParameterDirection.Output;


                param[1] = new OracleParameter();
                param[1].ParameterName = "USER_GROUP";
                param[1].OracleDbType = OracleDbType.Varchar2;
                param[1].Value = User_Group;
                param[1].Direction = ParameterDirection.Input;


                dtResult = objoracleHelper.ExecuteDataTable(objoracleHelper.GetConnection(), CommandType.StoredProcedure, "GET_ROLE_ID", param);
                return dtResult;
            }
            catch(Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }
            
        }

        
    }
}
