using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    
    public class PalletizationController : ControllerBase
    {
        DataTable dt = new DataTable();
        PalletizationDL objpalletizationDL = new PalletizationDL();

        [Route("api/PalletizationController/GetOrder")]
        [HttpGet]
        public JsonResult GetOrder(string gr_no)
        {
            dt = objpalletizationDL.GetEmptyPalletOut(gr_no);

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

        [Route("api/PalletizationController/UpdateInsert")]
        [HttpPost]
        public ActionResult UpdateInsert([FromBody] List<PalletizationModel> palletization)
        {
            foreach (PalletizationModel items in palletization)
            {
                dt = objpalletizationDL.UpdateInsert(items);

            }
            return new JsonResult("Operation Success");

        }

    }
}
