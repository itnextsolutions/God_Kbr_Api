using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    public class StoreRequestCancellationController : ControllerBase
    {
        StoreRequestCancellationDL ObjGetStoreOutRequestCancellation = new StoreRequestCancellationDL();
        DataTable dt =new DataTable();

        [Route("api/StoreRequestCancellation/GetStoreOutRequestCancellation")]
        [HttpGet]
        public JsonResult GetStoreOutRequestCancellation()
        {
            dt = ObjGetStoreOutRequestCancellation.GetStoreOutRequestCancellation();

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

        [Route("api/StoreRequestCancellation/UpdateOrderItem")]
        [HttpPost]
        public IActionResult UpdateOrderItem([FromBody] List<StoreRequestCancellationModel> storeRequestCancellations)
        {
           
            foreach (StoreRequestCancellationModel items in storeRequestCancellations)
            {
                dt = ObjGetStoreOutRequestCancellation.UpdateRequestCancelletion(items);

            }
            return new JsonResult("Operation Success");
        }

        [Route("api/StoreRequestCancellation/GetStoreInRequestCancelletion")]
        [HttpGet]
        public JsonResult GetRequestINCancelletion()
        {
            dt = ObjGetStoreOutRequestCancellation.GetRequestINCancelletion();
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

        //update status from STK to TRM

        [Route("api/RequestCancelletion/UpdateRequestCancelletion")]
        [HttpPost]

        public ActionResult UpdateRequestCancelletion([FromBody] List<StoreRequestCancellationModel> Requestdata)
        {
            foreach (var data in Requestdata)
            {

                //objEmptyPalletOut.data = data.HU_ID;
                data.MSG_WRK_STN = System.Environment.MachineName;
                data.MSG_WRK_USER = "Yogesh Gole";

                dt = ObjGetStoreOutRequestCancellation.UpdateRequestCancelletion(data);
            }
            int output = Convert.ToInt32(dt.Rows[0][0]);

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
