using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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

        private readonly ISession _session;

       

        // GET: api/<EmptyOutController>
        [Route("api/EmptyPalletOut/GetEmptyPalletOut")]
        [HttpGet]
        public JsonResult GetEmptyPalletOut(int parameter)
        {
            dt = objEmptyPalletOut.GetEmptyPalletOut(parameter);
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

        [Route("api/EmptyPalletOut/GetEmptyPalletOut_1")]
        [HttpGet]
        public JsonResult GetEmptyPalletOut([FromBody] PalletNumber palletNumber)
        {
            dt = objEmptyPalletOut.GetEmptyPalletOut(palletNumber.PALLET_NUMBER);
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
        public ActionResult InsertEmptyPalletData([FromBody] EmptyPallet emptyPalletData)
        {
            

            emptyPalletData.HU_CRE_WKS_ID = System.Environment.MachineName;
            emptyPalletData.HU_CRE_USER = "Ajit Sonvane";

            dt = objEmptyPalletOut.InsertEmptyPallet(emptyPalletData);

            //string output = Convert.ToString(dt.Rows[0][0]);

              int output = Convert.ToInt32(dt.Rows[0][0]);

            return new JsonResult(output);
        }


        [Route("api/EmptyPallet/UpdateEmptyPallet")]
        [HttpPost]
        public ActionResult UpdateEmptyPallet([FromBody] List<EmptyPallet> emptyPallet)
        {
            foreach (var data in emptyPallet)
            {
                
                data.HU_CRE_USER = System.Environment.MachineName;
                data.HU_CRE_WKS_ID = "SONALI KAMBLE";

                dt = objEmptyPalletOut.UpdateEmptyPalletcheck(data);
            }

            //string output = Convert.ToString(dt.Rows[0][0]);
            int output = Convert.ToInt32(dt.Rows[0][0]);

            return new JsonResult(output);

        }



    }
}
