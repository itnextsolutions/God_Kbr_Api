
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;
using Godrej_Korber_Shared.Models.TataCummins;
using System;

namespace Godrej_Korber_DAL.TataCummins
{
    public class EmptyPalletDL
    {

        DataTable dt = new DataTable();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();


        public DataTable GetEmptyPalletOut(int palletnumber)
        {
           

            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter();
            param[0].ParameterName = "PALLET_NUMBER";
            param[0].OracleType = OracleType.Int32;
            param[0].Value = palletnumber;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new OracleParameter();
            param[1].OracleType = OracleType.Cursor;
            param[1].ParameterName = "OCUR";
            param[1].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.GET_EMPTY_PALLET_DATA", param);
            return dt;
        }

        public DataTable InsertEmptyPallet(EmptyPallet emptypalletModel)
        {

            OracleParameter[] param = new OracleParameter[4];

            param[0] = new OracleParameter();
            param[0].ParameterName = "HU_ID";
            param[0].OracleType = OracleType.Int32;
            param[0].Value = emptypalletModel.HU_ID;
            param[0].Direction= ParameterDirection.Input;

			param[1] = new OracleParameter();
			param[1].ParameterName = "HU_VOL";
			param[1].OracleType = OracleType.Int32;
			param[1].Value = emptypalletModel.HU_VOL;
			param[1].Direction = ParameterDirection.Input;

            param[2]= new OracleParameter();
            param[2].ParameterName = "HU_HUPT_ID";
            param[2].OracleType= OracleType.Float;
            param[2].Value= emptypalletModel.HU_HUPT_ID;
            param[2].Direction= ParameterDirection.Input;

			param[3] = new OracleParameter();
			param[3].OracleType = OracleType.Cursor;
			param[3].ParameterName = "OCUR";
			param[3].Direction = ParameterDirection.Output;

			dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.INSERT_INTO_HUNIT1", param);
			return dt;

			//return dt;
        }



	}
}
