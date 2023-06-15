
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Godrej_Korber_DAL.Common
{
    public class MenuListDL
    {

        DataTable dt = new DataTable();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();


        public DataTable GetMenuList(int userid)
        {


            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "GROUP_PR";
            param[1].OracleDbType = OracleDbType.Int32;
            param[1].Value = userid;
            param[1].Direction = ParameterDirection.Input;

            

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "GET_MENU_LIST", param);
            return dt;
        }


    }
}
