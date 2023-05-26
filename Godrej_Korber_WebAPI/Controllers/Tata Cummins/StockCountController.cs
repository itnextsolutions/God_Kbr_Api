using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    
    public class StockCountController : ControllerBase
    {
        DataTable dt = new DataTable();
        StockCountDL objStockCount = new StockCountDL();

        [Route("api/StockCount/GetStockCount")]
        [HttpGet]
        public JsonResult GetStockCount()
        {
            dt = objStockCount.GetStockCount();
            
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return new JsonResult(parentRow);
        }

        [Route("api/StockCount/GetPalletDetails")]
        [HttpGet]
        public JsonResult GetPalletDetails(string partno, string grno)
        {
            dt = objStockCount.GetPalletDetails(partno, grno);
            if(dt != null) 
            {
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dt.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);
                    }
                    parentRow.Add(childRow);
                }
                return new JsonResult(parentRow);
            }
            return new JsonResult("Failed");
        }

        [Route("api/StockCount/UpdateInsert")]
        [HttpPost]
        public ActionResult UpdateInsert([FromBody] List<StockCountModel> stockcount)
        {
            foreach (StockCountModel items in stockcount)
            {
                dt = objStockCount.GetValidCountForFurtherProcess(items);
                int output = Convert.ToInt32(dt.Rows[0][0]);
                if (output == 0)
                {
                    dt = objStockCount.GetHuPar3(items);

                    int hupar3 = Convert.ToInt32(dt.Rows[0][0]);
                    //string hupar3 = Convert.ToString(dt.Rows[0][0]);
                    //string huid = Convert.ToString(items.HU_ID);
                    //dt = objStockCount.UpdateInHunit(items, hupar3);

                    //int cursor = Convert.ToInt32(dt.Rows[0][0]);

                    //if (cursor == 1)
                    //{
                    //    dt = objStockCount.InsertIntoStockMovt(items);
                    //}

                    items.USER_ID = "1234";
                    items.USERNAME = "YOGESH GOLE";
                    // dt = objStockCount.InsertIntoStockMovt(items);
                    dt = objStockCount.UpdateAndInsert(items, hupar3);

                }
                
            }
            return new JsonResult("Operation Success");

            //dt = objStockCount.GetValidCountForFurtherProcesse(stockcount.STK_REC_POS);



            //    List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            //    Dictionary<string, object> childRow;
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        childRow = new Dictionary<string, object>();
            //        foreach (DataColumn col in dt.Columns)
            //        {
            //            childRow.Add(col.ColumnName, row[col]);
            //        }
            //        parentRow.Add(childRow);
            //    }
            //    return new JsonResult(parentRow);
            //}
        }

    }
}
