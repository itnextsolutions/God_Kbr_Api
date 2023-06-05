using Godrej_Korber_Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.OracleClient;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_DAL
{
    public class MaterialMasterDL
    {
        DataTable dt = new DataTable();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();


        

        public DataTable GetProduct()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.GET_MATERIAL_MASTER_DATA", param);
            return dt;
        }


        public DataTable GetMaterialCategory()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.GET_MATERIAL_CATEGORY", param);
            return dt;
        }


        public DataTable GetPalletType()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.GET_PALLET_TYPE", param);
            return dt;
        }

        public DataTable GetMaterialStatus()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.GET_MATERIAL_STATUS", param);
            return dt;
        }



        public DataTable GetMaterialType()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.GET_MATERIAL_TYPE", param);
            return dt;
        }

    }
}
