
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.Extensions.Logging;
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


        private readonly ILogger<MaterialPickingDL> _logger;

        public MaterialPickingDL(ILogger<MaterialPickingDL> logger)
        {
            _logger = logger;
        }

        public DataTable GET_MATERIAL_PICKING_DATA(int PALLET_ID)
        {
            try
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
                if(dtResult != null)
                {
                    _logger.LogInformation("Retrived The Data Successfully Where PalletID = "+ PALLET_ID);
                    return dtResult;
                }
                return dtResult;
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dtResult;
            }

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


        public DataTable UPDATE_MATERIAL_PICKING_DATA(dynamic materialData, string MSG_CRE_USER, string MSG_CRE_WKS_ID)
        {

            OracleParameter[] param = new OracleParameter[9];


            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;


            param[1] = new OracleParameter();
            param[1].OracleDbType = OracleDbType.Int32;
            param[1].ParameterName = "MSG_HU_ID";
            param[1].Value = materialData.HU_ID.Value;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].OracleDbType = OracleDbType.Double;
            param[2].ParameterName = "MSG_RSV_QTY";
            param[2].Value = materialData.MVT_DST_QTY.Value;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new OracleParameter();
            param[3].OracleDbType = OracleDbType.Double;
            param[3].ParameterName = "MSG_PRD_QTY";
            param[3].Value = materialData.MVT_PRD_QTY.Value;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new OracleParameter();
            param[4].OracleDbType = OracleDbType.Varchar2;
            param[4].ParameterName = "MSG_STK_REC_POS";
            param[4].Value = materialData.STK_REC_POS.Value;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new OracleParameter();
            param[5].OracleDbType = OracleDbType.Varchar2;
            param[5].ParameterName = "MSG_PRD_COD";
            param[5].Value = materialData.MVT_PRD_COD.Value;
            param[5].Direction = ParameterDirection.Input;

            param[6] = new OracleParameter();
            param[6].OracleDbType = OracleDbType.Int32;
            param[6].ParameterName = "MSG_ORD_ID";
            param[6].Value = materialData.STK_ORD_ITM.Value;
            param[6].Direction = ParameterDirection.Input;


            param[7] = new OracleParameter();
            param[7].OracleDbType = OracleDbType.Varchar2;
            param[7].ParameterName = "MSG_CRE_USER";
            param[7].Value = MSG_CRE_USER;
            param[7].Direction = ParameterDirection.Input;

            param[8] = new OracleParameter();
            param[8].OracleDbType = OracleDbType.Varchar2;
            param[8].ParameterName = "MSG_CRE_WKS_ID";
            param[8].Value = MSG_CRE_WKS_ID;
            param[8].Direction = ParameterDirection.Input;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(), CommandType.StoredProcedure, "MATERIAL_PICKING.UPDATE_INSERT_MATERIAL_PICKING", param);

            int UpdateOutput = Convert.ToInt32(dtResult.Rows[0][0]);
            if (UpdateOutput == 0)
            {
                _logger.LogInformation("Data Has Not Been Updated & Inserted By These User =" + MSG_CRE_USER );
                return dtResult;
            }
            else if (UpdateOutput == 1)
            {
                _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully By These User =" + MSG_CRE_USER);
                return dtResult;
            }
            else
            {
                _logger.LogInformation("NO, Response From Database");
                return dtResult;
            }
        }

    }
}
