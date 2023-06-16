
using System.Data.SqlClient;
using System.Data;
//using System.Data.OracleClient;
using Godrej_Korber_Shared.Models.TataCummins;
using Oracle.ManagedDataAccess.Client;
using System;
using Microsoft.Extensions.Logging;

namespace Godrej_Korber_DAL.TataCummins
{
    public class EmptyPalletDL
    {

        DataTable dt = new DataTable();
        DataSet dtResult = new DataSet();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();

        private readonly ILogger<EmptyPalletDL> _logger;

        public EmptyPalletDL(ILogger<EmptyPalletDL> logger)
        {
            _logger = logger;
        }


        public DataTable GetEmptyPalletOut(int palletnumber)
        {
            try
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

                dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_EMPTY_PALLET.GET_EMPTY_PALLET_DATA", param);
                return dt;
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dt;
            }

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
            try
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
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Int32;
                param[2].ParameterName = "HU_VOL";
                param[2].Value = emptypalletModel.HU_VOL;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].OracleDbType = OracleDbType.Varchar2;
                param[3].ParameterName = "HU_CRE_USER";
                param[3].Value = emptypalletModel.HU_CRE_USER;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].OracleDbType = OracleDbType.Varchar2;
                param[4].ParameterName = "HU_CRE_WKS_ID";
                param[4].Value = emptypalletModel.HU_CRE_WKS_ID;
                param[4].Direction = ParameterDirection.Input;

                dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_EMPTY_PALLET.INSERT_INTO_HUNIT1", param);
                int UpdateOutput = Convert.ToInt32(dt.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been  Inserted By These User =" + emptypalletModel.HU_CRE_USER + " Where HU_ID =" + emptypalletModel.HU_ID + "And HU_VOl =" + emptypalletModel.HU_VOL);
                    return dt;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been  Inserted Sucessfully By These User =" + emptypalletModel.HU_CRE_USER + "  Where HU_ID =" + emptypalletModel.HU_ID + "And HU_VOL =" + emptypalletModel.HU_VOL);
                    return dt;;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database");
                    return dt;
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dt;
            }
        }


        public DataTable UpdateEmptyPalletcheck(EmptyPallet palletData)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[4];


                param[0] = new OracleParameter();
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].ParameterName = "OCUR";
                param[0].Direction = ParameterDirection.Output;

                param[1] = new OracleParameter();
                param[1].OracleDbType = OracleDbType.Int32;
                param[1].ParameterName = "MSG_HU_ID";
                param[1].Value = palletData.HU_ID;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleDbType = OracleDbType.Varchar2;
                param[2].ParameterName = "MSG_HU_CRE_USER";
                param[2].Value = palletData.HU_CRE_USER;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].OracleDbType = OracleDbType.Varchar2;
                param[3].ParameterName = "MSG_HU_CRE_WKS_ID";
                param[3].Value = palletData.HU_CRE_WKS_ID;
                param[3].Direction = ParameterDirection.Input;

                dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "TATA_CUMMINS_EMPTY_PALLET.UPDATE_PALLET_DETAIL", param);
                int UpdateOutput = Convert.ToInt32(dt.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated By These User =" + palletData.HU_CRE_USER + " Where HU_ID =" + palletData.HU_ID );
                    return dt;
                }
                else if (UpdateOutput == 1)
                {
                    _logger.LogInformation("Data Has Been Updated Sucessfully By These User =" + palletData.HU_CRE_USER + "  Where HU_ID =" + palletData.HU_ID);
                    return dt; ;
                }
                else
                {
                    _logger.LogInformation("NO, Response From Database");
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dt;
            }

        }



        //public DataTable UpdateEmptyPalletcheck(EmptyPallet wmsmodel)
        //{

        //    OracleParameter[] param = new OracleParameter[5];

        //    param[0] = new OracleParameter();
        //    param[0].ParameterName = "PALLET_ID";
        //    param[0].OracleDbType = OracleDbType.Int32;
        //    param[0].Value = wmsmodel.HU_ID;
        //    param[0].Direction = ParameterDirection.Input;

        //    param[1] = new OracleParameter();
        //    param[1].ParameterName = "QUERY_TYPE";
        //    param[1].OracleDbType = OracleDbType.Varchar2;
        //    param[1].Value = "UPDATE";
        //    param[1].Direction = ParameterDirection.Input;

        //    param[2] = new OracleParameter();
        //    param[2].ParameterName = "PALLET_NUMBER";
        //    param[2].OracleDbType = OracleDbType.Int32;
        //    param[2].Value = wmsmodel.HU_ID;
        //    param[2].Direction = ParameterDirection.Input;

        //    param[3] = new OracleParameter();
        //    param[3].ParameterName = "HU_VOL";
        //    param[3].OracleDbType = OracleDbType.Int32;
        //    param[3].Value = wmsmodel.HU_ID;
        //    param[3].Direction = ParameterDirection.Input;

        //    param[4] = new OracleParameter();
        //    param[4].OracleDbType = OracleDbType.RefCursor;
        //    param[4].ParameterName = "OCUR";
        //    param[4].Direction = ParameterDirection.Output;



        //    dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_EMPTY_PALLET.CALL_HUNIT1", param);
        //    return dt;

        //}



    }
}
