
//using System.Data.SqlClient;
//using System.Data;
//using System.Data.OracleClient;

//namespace Godrej_Korber_DAL.TataCummins
//{
//    public class EmptyPalletOutDL
//    {

//        DataTable dt = new DataTable();
//        OracleHelper oracle = new OracleHelper();
//        SqlHelper objsqlHelper = new SqlHelper();
//        List<SqlParameter> SqlParameters = new List<SqlParameter>();
//        List<OracleParameter> OracleParameters = new List<OracleParameter>();




//        public DataTable GetEmptyPalletOut(int palletnumber)
//        {
//            DataTable dt = new DataTable();

//            OracleParameter[] param = new OracleParameter[1];

//            param[0] = new OracleParameter();
//            param[0].ParameterName = "PALLET_NUMBER";
//            param[0].OracleType = OracleType.Int32;
//            param[0].Value = palletnumber;
//            param[0].Direction = ParameterDirection.Input;

//            param[1] = new OracleParameter();
//            param[1].OracleType = OracleType.Cursor;
//            param[1].ParameterName = "OCUR";
//            param[1].Direction = ParameterDirection.Output;

//            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "GET_EMPTY_PALLET_DATA", param);
//            return dt;
//        }
//    }
//}
