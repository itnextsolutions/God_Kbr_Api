using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
  
    public class StoreOutController : ControllerBase
    {
        DataTable dtResult = new DataTable();
        StoreOutDL objStoreOutDL = new StoreOutDL();

        string USER = "AJIT SONVANE";
        string USER_WKS_ID = System.Environment.MachineName;



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

        [Route("api/StoreOut/GetPalletDetails_Single_Check")]
        [HttpGet]
        public JsonResult Get_PalletDetails_Data_Single_Check(string parameter)
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


         [Route("api/StoreOut/GetPalletDetails_Multi_Check")]
        [HttpGet]
        public JsonResult Get_PalletDetails_Data_MultiCheck(List<String> parameter)
        {

            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
           

            foreach (var itm in parameter)
            {
                dtResult = objStoreOutDL.Get_PalletDetails_Data(itm);

                foreach (DataRow row in dtResult.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);
                    }
                    parentRow.Add(childRow);
                }

            }

               return new JsonResult(parentRow);
        }


        //[Route("api/storeOut/Insert_StockMovt_Update_StockItm")]
        //[HttpPost]
        //public JsonResult Insert_StockMovt_Update_StockItm([FromBody] List<StoreOutModel> storeOutData)
        //{
        //    foreach (StoreOutModel item in storeOutData)
        //    {

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
        
        [HttpPost]
        public JsonResult Insert_StockMovt_Update_StockItm_1([FromBody] UpdateList storeOutData)
        {
            

            foreach (OrderItm data in  storeOutData.orderData)
            {
                data.EXE_USER = USER;
                data.EXE_WKS_ID = USER_WKS_ID;

                objStoreOutDL.Update_Orderitm(data);

            }

            foreach (StoreOutModel item in storeOutData.storeOutData)
            {

                item.EXE_USER = USER;
                item.EXE_WKS_ID = USER_WKS_ID;

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
