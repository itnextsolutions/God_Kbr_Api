using Godrej_Korber_DAL;
using Godrej_Korber_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Godrej_Korber_WebAPI.Controllers
{

    public class OrderINViewController : ControllerBase
    {

        DataTable dt = new DataTable();
        OrderINViewDL OrderINDal = new OrderINViewDL();
        //PalletizationDL palletDl = new PalletizationDL();


        [Route("api/OrderINView/GetOrderdetail")]
        [HttpGet]

        public JsonResult GetOrderdetaildata()
        {
            dt = OrderINDal.GetOrder_IN_View();

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

        [Route("api/OrderInnView/UpdateInOrderInView")]
        [HttpPost]
        public ActionResult UpdateInInOrderInView([FromBody] UpdateData wmsModels)
        {
            int Hrs = Convert.ToInt32(wmsModels.Hr);

            foreach (var wmsModel in wmsModels.WmsModels)
            {

                wmsModel.MSG_WRK_STN = System.Environment.MachineName;
                wmsModel.MSG_WRK_USER = "SONALI KAMBLE";

                dt = OrderINDal.UpdateInOrderItm(wmsModel, Hrs);
                //dt = OrderINDal.updateOrderDtRequest(wmsModel, Hrs);
            }

            return new JsonResult("Success");
        }
    }
}
