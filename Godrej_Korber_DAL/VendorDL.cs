using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godrej_Korber_Shared.Models;
using System.Data.OracleClient;

namespace Godrej_Korber_DAL
{
    public class VendorDL
    {
        DataTable dtResult = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        OracleHelper objOracle = new OracleHelper();

        //List<SqlParameter> SqlParameters = new List<SqlParameter>();


        //public DataTable InsertVendor(VendorModel vendor)
        //{
        //    SqlParameter[] param = new SqlParameter[5];

        //    param[0] = new SqlParameter();
        //    param[0].ParameterName = "MATERIAL_CODE";
        //    param[0].SqlDbType = SqlDbType.VarChar;
        //    param[0].Value = vendor.MATERIAL_CODE;
        //    param[0].Direction = ParameterDirection.Input;

        //    param[1] = new SqlParameter();
        //    param[1].ParameterName = "MATERIAL_CATEGORY";
        //    param[1].SqlDbType = SqlDbType.VarChar;
        //    param[1].Value = vendor.MATERIAL_CATEGORY;
        //    param[1].Direction = ParameterDirection.Input;

        //    param[2] = new SqlParameter();
        //    param[2].ParameterName = "MATERIAL_DESC";
        //    param[2].SqlDbType = SqlDbType.VarChar;
        //    param[2].Value = vendor.MATERIAL_DESC;
        //    param[2].Direction = ParameterDirection.Input;

        //    param[3] = new SqlParameter();
        //    param[3].ParameterName = "VENDOR_CODE";
        //    param[3].SqlDbType = SqlDbType.VarChar;
        //    param[3].Value = vendor.VENDOR_CODE;
        //    param[3].Direction = ParameterDirection.Input;

        //    param[4] = new SqlParameter();
        //    param[4].ParameterName = "VENDOR_DESC";
        //    param[4].SqlDbType = SqlDbType.VarChar;
        //    param[4].Value = vendor.VENDOR_DESC;
        //    param[4].Direction = ParameterDirection.Input;


        //    dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_InsertVendorMaster", param);
        //    return dt;
        //}




        public DataTable InsertVendorMasterOracle(VendorModel vendor)
        {
            try
            {

                OracleParameter[] param = new OracleParameter[5];

                

                param[0] = new OracleParameter();
                param[0].OracleType = OracleType.VarChar;
                param[0].ParameterName = "MATERIAL_CATEGORY";
                param[0].Value = vendor.MATERIAL_CATEGORY;
                param[0].Direction = ParameterDirection.Input;

                param[1] = new OracleParameter();
                param[1].OracleType = OracleType.VarChar;
                param[1].ParameterName = "MATERIAL_CODE";
                param[1].Value = vendor.MATERIAL_CODE;
                param[1].Direction = ParameterDirection.Input;

                param[2] = new OracleParameter();
                param[2].OracleType = OracleType.VarChar;
                param[2].ParameterName = "MATERIAL_DESC";
                param[2].Value = vendor.MATERIAL_DESC;
                param[2].Direction = ParameterDirection.Input;

                param[3] = new OracleParameter();
                param[3].OracleType = OracleType.VarChar;
                param[3].ParameterName = "VENDOR_CODE";
                param[3].Value = vendor.VENDOR_CODE;
                param[3].Direction = ParameterDirection.Input;

                param[4] = new OracleParameter();
                param[4].OracleType = OracleType.VarChar;
                param[4].ParameterName = "VENDOR_DESC";
                param[4].Value = vendor.VENDOR_DESC;
                param[4].Direction = ParameterDirection.Input;

               

                dtResult = objOracle.ExecuteDataTable(objOracle.GetConnection(), CommandType.StoredProcedure, "INSERT_INTO_VENDOR_MASTER", param);
            }

            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {
                objOracle.CloseConnection();
            }

            return dtResult;
        }


        public DataTable getVendorMaster()
        {
            dtResult = objOracle.ExecuteDataTable(objOracle.GetConnection(), CommandType.Text, "Select * from VENDOR_MASTER");

            return dtResult;
        }




    }
}
