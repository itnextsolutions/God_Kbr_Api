using Microsoft.AspNetCore.Mvc;
using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using System.Data;
using Godrej_Korber_Shared.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmptyPalletController : ControllerBase
    {

        DataTable dt = new DataTable();
        EmptyPalletDL objEmptyPalletOut = new EmptyPalletDL();

        // GET: api/<EmptyOutController>
        [Route("api/EmptyPalletOut/GetEmptyPalletOut")]
        [HttpGet]
        public JsonResult GetEmptyPalletOut(EmptyPallet palletnumber)
        {
            dt = objEmptyPalletOut.GetEmptyPalletOut(palletnumber.PALLET_NUMBER);
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

		

		[Route("api/EmptyPalletOut/InsertEmptyPalletData")]
		[HttpPost]
		public ActionResult InsertEmptyPalletData([FromBody] EmptyPallet wmsModel)
		{

			//wmsModel.MSG_WRK_STN = System.Environment.MachineName;
			//wmsModel.MSG_WRK_USER = "SONALI KAMBLE";

			dt = objEmptyPalletOut.InsertEmptyPallet(wmsModel);

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


		//update status from STK to RSV
		
	//	[Route("api/EmptyPallet/UpdateEmptyPallet")]
	//	[HttpPost]
	//	public ActionResult UpdateEmptyPallet([FromBody] EmptyPallet HU_ID)
	//	{
	//		foreach (var HU_ID in EmptyPallet.HU_ID)

	//		{
	//			//EmptyPallet.MSG_WRK_STN = System.Environment.MachineName;
	//			//EmptyPallet.MSG_WRK_USER = "SONALI KAMBLE";

	//			dt = objEmptyPalletOut.UpdateEmptyPalletcheck(HU_ID);
	//		}
	//		return new JsonResult(dt);

	//}
		                     
	}
}
