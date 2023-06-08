using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godrej_Korber_Shared.Models.TataCummins;

namespace Godrej_Korber_DAL.TataCummins
{
    public class PalletizationDL
    {
        DataTable dt = new DataTable();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();


        public DataTable GetEmptyPalletOut(string gr_no)
        {


            OracleParameter[] param = new OracleParameter[2];


            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "GR_NO";
            param[1].OracleDbType = OracleDbType.Varchar2;
            param[1].Value = gr_no;
            param[1].Direction = ParameterDirection.Input;


            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_PALLETISATION.GET_PALLETISATION_DATA", param);
            return dt;
        }
         
        public DataTable UpdateInsert(PalletizationModel Data)
        {

            OracleParameter[] param = new OracleParameter[3];


            param[0] = new OracleParameter();
            param[0].OracleDbType = OracleDbType.RefCursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            param[1] = new OracleParameter();
            param[1].ParameterName = "REQ_QTY";
            param[1].OracleDbType = OracleDbType.Int32;
            param[1].Value = Data.ORD_REQ_QTY;
            param[1].Direction = ParameterDirection.Input; 

            param[2] = new OracleParameter();
            param[2].ParameterName = "ID_ORD";
            param[2].OracleDbType = OracleDbType.Int32;
            param[2].Value = Data.ORD_ID;
            param[2].Direction = ParameterDirection.Input;

            dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "MRFWMS.TATA_CUMMINS_PALLETISATION.UPDATE_INSERT_PALLETIZATION", param);
            return dt;
        }
    }
}
