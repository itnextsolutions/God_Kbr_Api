using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godrej_Korber_Shared.Models;


namespace Godrej_Korber_DAL
{
    public class LoginDL
    {
        DataTable dtResult = new DataTable();
        OracleHelper objoracleHelper = new OracleHelper();
       

        public DataTable Login(string username)
        {
            OracleParameter[] param = new OracleParameter[1];

            param[0] = new OracleParameter();
            param[0].ParameterName = "Username";
            param[0].OracleType = OracleType.VarChar;
            param[0].Value = username;
            param[0].Direction = ParameterDirection.Input;

            dtResult = objoracleHelper.ExecuteDataTable(objoracleHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLogin", param);
            return dtResult;
        }
        public DataTable GetLoginDetail(LoginModel loginData)
        {
            OracleParameter[] param = new OracleParameter[3];

            param[0] = new OracleParameter();
            param[0].ParameterName = "LS_RESULT";
            param[0].OracleType = OracleType.Cursor;           
            param[0].Direction = ParameterDirection.Output;


            param[1] = new OracleParameter();
            param[1].ParameterName = "MSG_USERNAME";
            param[1].OracleType = OracleType.VarChar;
            param[1].Value = loginData.username;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "MSG_PASSWORD";
            param[2].OracleType = OracleType.VarChar;
            param[2].Value = loginData.password;
            param[2].Direction = ParameterDirection.Input;

            dtResult = objoracleHelper.ExecuteDataTable(objoracleHelper.GetConnection(), CommandType.StoredProcedure, "SP_GET_LOGIN_DETAILS", param);
            return dtResult;
        }
    }
}
