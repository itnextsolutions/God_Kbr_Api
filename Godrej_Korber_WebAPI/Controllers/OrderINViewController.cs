using Godrej_Korber_DAL;
using Godrej_Korber_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Godrej_Korber_WebAPI.Controllers
{
	//[Route("api/[controller]")]
	//[ApiController]
	public class OrderINViewController : ControllerBase
	{

		DataTable dt = new DataTable();
		OrderINViewDL OrderINDal = new OrderINViewDL();

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
				//HostToWmsModel data = new HostToWmsModel

				wmsModel.MSG_ORD_ID = wmsModel.MSG_ORD_ID;
				wmsModel.MSG_ORD_DT_REQUEST = wmsModel.MSG_Hrs;

				//set other properties of data object here

				wmsModel.MSG_WRK_STN = System.Environment.MachineName;
				wmsModel.MSG_WRK_USER = "SONALI KAMBLE";
			

				dt = OrderINDal.UpdateInOrderItm(wmsModel, Hrs);
			 }

			//foreach (HostToWmsModel data in wmsModels)
			//{
			//	int Hr = 4;
			//	data.MSG_WRK_STN = System.Environment.MachineName;
			//	data.MSG_WRK_USER = "SONALI KAMBLE";

			//	dt = OrderINDal.UpdateInOrderItm(data, Hrs);
			//}

			return new JsonResult("Success");
		}

	}
}
