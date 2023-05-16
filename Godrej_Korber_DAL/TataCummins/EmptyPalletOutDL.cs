
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;

namespace Godrej_Korber_DAL.TataCummins
{
    public class EmptyPalletOutDL
    {

        DataTable dt = new DataTable();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();




        public DataTable GetEmptyPalletOut()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.GET_MATERIAL_MASTER_DATA", param);
            return dt;
        }
    }
}
