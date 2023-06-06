
using System.Data.SqlClient;
using System.Data;
//using System.Data.OracleClient;
using Godrej_Korber_Shared.Models.TataCummins;
using Oracle.ManagedDataAccess.Client;
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
            param[0].OracleDbType = OracleDbType.Int32;
            param[0].Value = palletnumber;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.RefCursor;
            param[1].ParameterName = "OCUR";
            param[1].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.GET_EMPTY_PALLET_DATA", param);
            return dt;
        }

        //public DataTable GetEmptyPalletOut(int palletnumber)
        //{

        //    OracleParameter[] param = new OracleParameter[5];

        //    param[0] = new OracleParameter();
        //    param[0].ParameterName = "PALLET_NUMBER";
        //    param[0].OracleDbType = OracleDbType.Int32;
        //    param[0].Value = palletnumber;
        //    param[0].Direction = ParameterDirection.Input;

        //    param[1] = new OracleParameter();
        //    param[1].ParameterName = "QUERY_TYPE";
        //    param[1].OracleDbType = OracleDbType.VarChar;
        //    param[1].Value = "GET";
        //    param[1].Direction = ParameterDirection.Input;

        //    param[2] = new OracleParameter();
        //    param[2].ParameterName = "PALLET_ID";
        //    param[2].OracleDbType = OracleDbType.Int32;
        //    param[2].Value = palletnumber;
        //    param[2].Direction = ParameterDirection.Input;

        //    param[3] = new OracleParameter();
        //    param[3].ParameterName = "HU_VOL";
        //    param[3].OracleDbType = OracleDbType.Int32;
        //    param[3].Value = palletnumber;
        //    param[3].Direction = ParameterDirection.Input;

        //    param[4] = new OracleParameter();
        //    param[4].OracleDbType = OracleDbType.RefCursor;
        //    param[4].ParameterName = "OCUR";
        //    param[4].Direction = ParameterDirection.Output;

        //    dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.CALL_HUNIT1", param);
        //    return dt;
        //}


        public DataTable InsertEmptyPallet(EmptyPallet emptypalletModel)
        {

            OracleParameter[] param = new OracleParameter[5];

            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.Int32;
            param[1].ParameterName = "HU_ID";
            param[1].Value = emptypalletModel.HU_ID;
            param[1].Direction= ParameterDirection.Input;

			param[2] = new OracleParameter();
            param[2].OracleDbType = OracleDbType.Int32;
            param[2].ParameterName = "HU_VOL";
			param[2].Value = emptypalletModel.HU_VOL;
			param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].OracleDbType= OracleDbType.Varchar2;
            param[3].ParameterName = "HU_CRE_USER";
            param[3].Value = emptypalletModel.HU_CRE_USER;
            param[3].Direction= ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].OracleDbType = OracleDbType.Varchar2;
            param[4].ParameterName = "HU_CRE_WKS_ID";
            param[4].Value = emptypalletModel.HU_CRE_WKS_ID;
            param[4].Direction = ParameterDirection.Input;


            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.INSERT_INTO_HUNIT1", param);
			return dt;
        }


        //public DataTable UpdateEmptyPalletcheck(EmptyPallet wmsmodel)
        //{

        //    OracleParameter[] param = new OracleParameter[2];

        //    param[0] = new OracleParameter();
        //    param[0].OracleDbType = OracleDbType.Int32;
        //    param[0].ParameterName = "MSG_HU_ID";
        //    param[0].Value = wmsmodel.HU_ID;
        //    param[0].Direction = ParameterDirection.Input;

        //    param[1] = new OracleParameter();
        //    param[1].OracleDbType = OracleDbType.RefCursor;
        //    param[1].ParameterName = "OCUR";
        //    param[1].Direction = ParameterDirection.Output;

        //    dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.UPDATE_PALLET_DETAIL", param);
        //    return dt;

        //}



        public DataTable UpdateEmptyPalletcheck(EmptyPallet wmsmodel)
        {

            OracleParameter[] param = new OracleParameter[5];

            param[0] = new OracleParameter();
            param[0].ParameterName = "PALLET_ID";
            param[0].OracleDbType = OracleDbType.Int32;
            param[0].Value = wmsmodel.HU_ID;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new OracleParameter();
            param[1].ParameterName = "QUERY_TYPE";
            param[1].OracleDbType = OracleDbType.Varchar2;
            param[1].Value = "UPDATE";
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "PALLET_NUMBER";
            param[2].OracleDbType = OracleDbType.Int32;
            param[2].Value = wmsmodel.HU_ID;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].ParameterName = "HU_VOL";
            param[3].OracleDbType = OracleDbType.Int32;
            param[3].Value = wmsmodel.HU_ID;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].OracleDbType = OracleDbType.RefCursor;
            param[4].ParameterName = "OCUR";
            param[4].Direction = ParameterDirection.Output;



            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.CALL_HUNIT1", param);
            return dt;

        }



    }
}
