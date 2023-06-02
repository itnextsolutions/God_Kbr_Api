using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
  
    public class StoreOutController : ControllerBase
    {
        DataTable dtResult = new DataTable();
        StoreOutDL objStoreOutDL = new StoreOutDL();


        [Route("api/StoreOut/GetStoreOutData")]
        [HttpGet]
        public JsonResult Get_Store_Out_Data()
        {
            dtResult = objStoreOutDL.Get_Store_Out_Data();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtResult.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return new JsonResult(parentRow);
        }

        [Route("api/StoreOut/GetPalletDetails")]
        [HttpGet]
        public JsonResult Get_PalletDetails_Data(string parameter)
        {

            dtResult = objStoreOutDL.Get_PalletDetails_Data(parameter);
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtResult.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            return new JsonResult(parentRow);
        }


        //[Route("api/storeOut/Insert_StockMovt_Update_StockItm")]
        //[HttpPost]
        //public JsonResult Insert_StockMovt_Update_StockItm([FromBody] List<StoreOutModel> storeOutData)
        //{
        //    foreach(StoreOutModel item in storeOutData){

        //        item.EXE_USER = System.Environment.MachineName;
        //        item.EXE_WKS_ID = "AJIT SONVANE";

        //        dtResult = objStoreOutDL.Insert_StockMovt(item);
        //    }

        //    int output = Convert.ToInt32(dtResult.Rows[0][0]);

        //    if (output == 1)
        //    {
        //        return new JsonResult("Success");
        //    }

        //    else
        //    {
        //        return new JsonResult("Failed");
        //    }

        //}


        [Route("api/storeOut/Insert_StockMovt_Update_StockItm")]
        //[Route("api/storeOut/Update_Hunit1")]
        [HttpPost]
        public JsonResult Insert_StockMovt_Update_StockItm_1([FromBody] List<StoreOutModel> storeOutData)
        {
            foreach (StoreOutModel item in storeOutData)
            {

                item.EXE_USER = System.Environment.MachineName;
                item.EXE_WKS_ID = "AJIT SONVANE";

                dtResult = objStoreOutDL.Insert_and_update_storeOutData(item);
            }

            int output = Convert.ToInt32(dtResult.Rows[0][0]);

            if (output == 1)
            {
                return new JsonResult("Success");
            }

            else
            {
                return new JsonResult("Failed");
            }

        }

    }
}
