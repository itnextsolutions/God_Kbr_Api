using Godrej_Korber_Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
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


        public DataTable InsertMaterial(MaterialMasterModel materialMaster)
        {
            OracleParameter[] param = new OracleParameter[9];



            param[0] = new OracleParameter();
            param[0].ParameterName = "P_PRD_COD";
            param[0].OracleType = OracleType.VarChar;
            param[0].Value = materialMaster.PRD_COD;
            param[0].Direction = ParameterDirection.Input;


            param[1] = new OracleParameter();
            param[1].ParameterName = "P_PRD_GRP_COD";
            param[1].OracleType = OracleType.VarChar;
            param[1].Value = materialMaster.PRD_GRP_COD;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "P_PRD_DESC";
            param[2].OracleType = OracleType.VarChar;
            param[2].Value = materialMaster.PRD_DESC;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].ParameterName = "P_PRD_LENG";
            param[3].OracleType = OracleType.Float;
            param[3].Value = materialMaster.PRD_LENG;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].ParameterName = "P_PRD_CTRL_TYPE";
            param[4].OracleType = OracleType.VarChar;
            param[4].Value = materialMaster.PRD_CTRL_TYPE;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].ParameterName = "P_PRD_PACK_QTY";
            param[5].OracleType = OracleType.Float;
            param[5].Value = materialMaster.PRD_PACK_QTY;
            param[5].Direction = ParameterDirection.Input;

            param[6] = new OracleParameter();
            param[6].ParameterName = "P_PRD_MEAS_UNIT";
            param[6].OracleType = OracleType.VarChar;
            param[6].Value = materialMaster.PRD_MEAS_UNIT;
            param[6].Direction = ParameterDirection.Input;

            param[7] = new OracleParameter();
            param[7].ParameterName = "P_PRD_HUPT_ID";
            param[7].OracleType = OracleType.Float;
            param[7].Value = materialMaster.PRD_HUPT_ID;
            param[7].Direction = ParameterDirection.Input;

            param[8] = new OracleParameter();
            param[8].OracleType = OracleType.Cursor;
            param[8].ParameterName = "OCUR";
            param[8].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.INSERT_INTO_PRODUCT", param);
            return dt;
        }

        public DataTable GetProduct()
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


        public DataTable GetMaterialCategory()
        {
            DataTable dt = new DataTable();

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.GET_MATERIAL_CATEGORY", param);
            return dt;
        }


        public DataTable UpdateMaterial(MaterialMasterModel materialMaster)
        {
            OracleParameter[] param = new OracleParameter[9];



            param[0] = new OracleParameter();
            param[0].ParameterName = "P_PRD_COD";
            param[0].OracleType = OracleType.VarChar;
            param[0].Value = materialMaster.PRD_COD;
            param[0].Direction = ParameterDirection.Input;


            param[1] = new OracleParameter();
            param[1].ParameterName = "P_PRD_GRP_COD";
            param[1].OracleType = OracleType.VarChar;
            param[1].Value = materialMaster.PRD_GRP_COD;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "P_PRD_DESC";
            param[2].OracleType = OracleType.VarChar;
            param[2].Value = materialMaster.PRD_DESC;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].ParameterName = "P_PRD_LENG";
            param[3].OracleType = OracleType.Float;
            param[3].Value = materialMaster.PRD_LENG;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].ParameterName = "P_PRD_CTRL_TYPE";
            param[4].OracleType = OracleType.VarChar;
            param[4].Value = materialMaster.PRD_CTRL_TYPE;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].ParameterName = "P_PRD_PACK_QTY";
            param[5].OracleType = OracleType.Float;
            param[5].Value = materialMaster.PRD_PACK_QTY;
            param[5].Direction = ParameterDirection.Input;

            param[6] = new OracleParameter();
            param[6].ParameterName = "P_PRD_MEAS_UNIT";
            param[6].OracleType = OracleType.VarChar;
            param[6].Value = materialMaster.PRD_MEAS_UNIT;
            param[6].Direction = ParameterDirection.Input;

            param[7] = new OracleParameter();
            param[7].ParameterName = "P_PRD_HUPT_ID";
            param[7].OracleType = OracleType.Float;
            param[7].Value = materialMaster.PRD_HUPT_ID;
            param[7].Direction = ParameterDirection.Input;

            param[8] = new OracleParameter();
            param[8].OracleType = OracleType.Cursor;
            param[8].ParameterName = "OCUR";
            param[8].Direction = ParameterDirection.Output;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "WMS_PRODUCT.UPDATE_PRODUCT", param);
            return dt;
        }

    }
}
