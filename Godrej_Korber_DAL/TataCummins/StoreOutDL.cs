
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace Godrej_Korber_DAL.TataCummins
{
    public class StoreOutDL
    {
        OracleHelper objOracleHelper = new OracleHelper();
        DataTable dtResult = new DataTable();

        public DataTable Get_Store_Out_Data()
        {
            OracleParameter[] param = new OracleParameter[1];

            param[0] = new OracleParameter();
            param[0].OracleType = OracleType.Cursor;
            param[0].ParameterName = "OCUR";
            param[0].Direction = ParameterDirection.Output;

            dtResult = objOracleHelper.ExecuteDataTable(objOracleHelper.GetConnection(),CommandType.StoredProcedure,"ORDERVIEW.GET_STORE_OUT_DATA",param);
            return dtResult;

        }
    }
}
