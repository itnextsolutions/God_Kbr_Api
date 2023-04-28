using Godrej_Korber_Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_DAL
{
    public class HostToWmsDL
    {

        DataTable dt = new DataTable();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();

        public DataTable InserIntoHostToWms(HostToWmsModel Wmsmodel)
        {
            OracleParameter[] param = new OracleParameter[29];



            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "ls_result";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "MSG_VENDOR_DESC";
            param[1].OracleType = OracleType.VarChar;
            param[1].Value = Wmsmodel.MSG_VENDOR_CODE;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new OracleParameter();
            param[2].ParameterName = "MSG_MATERIAL_CODE";
            param[2].OracleType = OracleType.VarChar;
            param[2].Value = Wmsmodel.MSG_MATERIAL_CODE;
            param[2].Direction = ParameterDirection.Input;


            param[3] = new OracleParameter();
            param[3].ParameterName = "MSG_MATERIAL_CATEGORY";
            param[3].OracleType = OracleType.VarChar;
            param[3].Value = Wmsmodel.MSG_MATERIAL_CATEGORY;
            param[3].Direction = ParameterDirection.Input;



            param[4] = new OracleParameter();
            param[4].ParameterName = "MSG_DESCRIPTION";
            param[4].OracleType = OracleType.VarChar;
            param[4].Value = Wmsmodel.MSG_DESCRIPTION;
            param[4].Direction = ParameterDirection.Input;



            param[5] = new OracleParameter();
            param[5].ParameterName = "MSG_TRANS_ID";
            param[5].OracleType = OracleType.VarChar;
            param[5].Value = Wmsmodel.MSG_TRANS_ID;
            param[5].Direction = ParameterDirection.Input;


            param[6] = new OracleParameter();
            param[6].ParameterName = "MSG_REF_TRANS_ID";
            param[6].OracleType = OracleType.VarChar;
            param[6].Value = Wmsmodel.MSG_REF_TRANS_ID;
            param[6].Direction = ParameterDirection.Input;


            param[7] = new OracleParameter();
            param[7].ParameterName = "MSG_PROJECT_ID";
            param[7].OracleType = OracleType.VarChar;
            param[7].Value = Wmsmodel.MSG_PROJECT_ID;
            param[7].Direction = ParameterDirection.Input;


            param[8] = new OracleParameter();
            param[8].ParameterName = "MSG_DOM";
            param[8].OracleType = OracleType.VarChar;
            param[8].Value = Wmsmodel.MSG_DOM;
            param[8].Direction = ParameterDirection.Input;


            param[9] = new OracleParameter();
            param[9].ParameterName = "MSG_DOE";
            param[9].OracleType = OracleType.VarChar;
            param[9].Value = Wmsmodel.MSG_DOE;
            param[9].Direction = ParameterDirection.Input;


            param[10] = new OracleParameter();
            param[10].ParameterName = "MSG_VENDOR_CODE";
            param[10].OracleType = OracleType.VarChar;
            param[10].Value = Wmsmodel.MSG_VENDOR_CODE;
            param[10].Direction = ParameterDirection.Input;


            param[11] = new OracleParameter();
            param[11].ParameterName = "MSG_MATERIAL_STATUS";
            param[11].OracleType = OracleType.VarChar;
            param[11].Value = Wmsmodel.MSG_MATERIAL_STATUS;
            param[11].Direction = ParameterDirection.Input;

            param[12] = new OracleParameter();
            param[12].ParameterName = "MSG_UOM";
            param[12].OracleType = OracleType.VarChar;
            param[12].Value = Wmsmodel.MSG_UOM;
            param[12].Direction = ParameterDirection.Input;

            param[13] = new OracleParameter();
            param[13].ParameterName = "MSG_MATERIAL_TYPE";
            param[13].OracleType = OracleType.VarChar;
            param[13].Value = Wmsmodel.MSG_MATERIAL_TYPE;
            param[13].Direction = ParameterDirection.Input;

            param[14] = new OracleParameter();
            param[14].ParameterName = "MSG_MATERIAL_BARCODE";
            param[14].OracleType = OracleType.VarChar;
            param[14].Value = Wmsmodel.MSG_MATERIAL_BARCODE;
            param[14].Direction = ParameterDirection.Input;

            param[15] = new OracleParameter();
            param[15].ParameterName = "MSG_REQ_ORIGIN";
            param[15].OracleType = OracleType.VarChar;
            param[15].Value = Wmsmodel.MSG_REQ_ORIGIN;
            param[15].Direction = ParameterDirection.Input;

            param[16] = new OracleParameter();
            param[16].ParameterName = "MSG_DIP_ROLL_NO";
            param[16].OracleType = OracleType.VarChar;
            param[16].Value = Wmsmodel.MSG_DIP_ROLL_NO;
            param[16].Direction = ParameterDirection.Input;

            param[17] = new OracleParameter();
            param[17].ParameterName = "MSG_INVOICE_NO";
            param[17].OracleType = OracleType.VarChar;
            param[17].Value = Wmsmodel.MSG_INVOICE_NO;
            param[17].Direction = ParameterDirection.Input;

            param[18] = new OracleParameter();
            param[18].ParameterName = "MSG_GRN_NUM";
            param[18].OracleType = OracleType.VarChar;
            param[18].Value = Wmsmodel.MSG_GRN_NUM;
            param[18].Direction = ParameterDirection.Input;

            param[19] = new OracleParameter();
            param[19].ParameterName = "MSG_VENDOR_CON";
            param[19].OracleType = OracleType.VarChar;
            param[19].Value = Wmsmodel.MSG_VENDOR_CON;
            param[19].Direction = ParameterDirection.Input;

            param[20] = new OracleParameter();
            param[20].ParameterName = "MSG_WRK_STN";
            param[20].OracleType = OracleType.VarChar;
            param[20].Value = Wmsmodel.MSG_WRK_STN;
            param[20].Direction = ParameterDirection.Input;

            param[21] = new OracleParameter();
            param[21].ParameterName = "MSG_WRK_USER";
            param[21].OracleType = OracleType.VarChar;
            param[21].Value = Wmsmodel.MSG_WRK_USER;
            param[21].Direction = ParameterDirection.Input;


            param[22] = new OracleParameter();
            param[22].ParameterName = "MSG_PART_FLAG";
            param[22].OracleType = OracleType.VarChar;
            param[22].Value = Wmsmodel.MSG_PART_FLAG;
            param[22].Direction = ParameterDirection.Input;


            param[23] = new OracleParameter();
            param[23].ParameterName = "MSG_QUANTITY";
            param[23].OracleType = OracleType.Float;
            param[23].Value = Wmsmodel.MSG_QUANTITY;
            param[23].Direction = ParameterDirection.Input;


            param[24] = new OracleParameter();
            param[24].ParameterName = "MSG_LENG_QTY";
            param[24].OracleType = OracleType.Float;
            param[24].Value = Wmsmodel.MSG_LENG_QTY;
            param[24].Direction = ParameterDirection.Input;

            param[25] = new OracleParameter();
            param[25].ParameterName = "MSG_NO_OF_SP_BOX";
            param[25].OracleType = OracleType.Float;
            param[25].Value = Wmsmodel.MSG_NO_OF_SP_BOX;
            param[25].Direction = ParameterDirection.Input;

            param[26] = new OracleParameter();
            param[26].ParameterName = "MSG_SHELF_LIFE";
            param[26].OracleType = OracleType.Int32;
            param[26].Value = Wmsmodel.MSG_SHELF_LIFE;
            param[26].Direction = ParameterDirection.Input;


            param[27] = new OracleParameter();
            param[27].ParameterName = "MSG_PAL_TYPE";
            param[27].OracleType = OracleType.Int32;
            param[27].Value = Wmsmodel.MSG_PAL_TYPE;
            param[27].Direction = ParameterDirection.Input;

            param[28] = new OracleParameter();
            param[28].ParameterName = "MSG_TRANS_TYPE";
            param[28].OracleType = OracleType.VarChar;
            param[28].Value = Wmsmodel.MSG_TRANS_TYPE;
            param[28].Direction = ParameterDirection.Input;


            //param[19] = new OracleParameter();
            //param[19].ParameterName = "MSG_VENDOR_CON";
            //param[19].OracleType = OracleType.VarChar;
            //param[19].Value = Wmsmodel.MSG_VENDOR_CON;
            //param[19].Direction = ParameterDirection.Input;



            //param[16] = new OracleParameter();
            //param[16].ParameterName = "MSG_DOR";
            //param[16].OracleType = OracleType.VarChar;
            //param[16].Value = Wmsmodel.MSG_DOR;
            //param[16].Direction = ParameterDirection.Input;



            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "INSERT_INTO_HOST_TO_WMS_IN", param);
            return dt;
        }
    }
}
