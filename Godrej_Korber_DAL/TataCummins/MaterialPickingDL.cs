
using Godrej_Korber_Shared.Models.TataCummins;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_DAL.TataCummins
{
    public class MaterialPickingDL
    {
        DataTable dtResult = new DataTable();
        OracleHelper  objOracleHelper = new OracleHelper();


        public DataTable GET_MATERIAL_PICKING_DATA(int PALLET_ID)
        {

            OracleParameter[] param = new OracleParameter[2];


            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;


            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.Int32;
            param[1].ParameterName = "PALLET_ID";
            param[1].Value = PALLET_ID;
            param[1].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "MATERIAL_PICKING.GET_MATERIAL_PICKING_DATA", param);
            return dtResult;
        }

        public DataTable UPDATE_MATERIAL_PICKING_DATA(MaterialPickingModel materialData)
        {

            OracleParameter[] param = new OracleParameter[3];


            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;


            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.Int32;
            param[1].ParameterName = "MSG_ORD_ID";
            param[1].Value = materialData.MSG_ORD_ID;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].OracleDbType = OracleDbType.Int32;
            param[2].ParameterName = "MSG_RSV_QTY";
            param[2].Value = materialData.MSG_RSV_QTY;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].OracleDbType = OracleDbType.Varchar2;
            param[3].ParameterName = "MSG_CRE_WKS_ID";
            param[3].Value = materialData.MSG_CRE_WKS_ID;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].OracleDbType = OracleDbType.Varchar2;
            param[4].ParameterName = "MSG_CRE_USER";
            param[4].Value = materialData.MSG_CRE_USER;
            param[4].Direction = ParameterDirection.Input;


            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "MATERIAL_PICKING.UPDATE_INSERT_MATERIAL_PICKING", param);
            return dtResult;
        }
    }
}
