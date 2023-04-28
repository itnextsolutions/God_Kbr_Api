using Godrej_Korber_DAL;
using Godrej_Korber_Shared.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System.Data;
//using System.Web.Script.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers
{
    
    //[Route("api/[controller]")]
    //[ApiController]
    public class VendorController : ControllerBase
    {
        DataTable dtResult = new DataTable();
        VendorDL objVendorDL = new VendorDL();


        [Route("api/vendor/GetVendorMaster")]
        [HttpGet]
        public JsonResult Get()
        {
            dtResult = objVendorDL.getVendorMaster();

            //JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
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
            //return new JsonResult(true);
        }

       
    }
}
