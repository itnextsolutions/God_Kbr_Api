//using Microsoft.AspNetCore.Mvc;
//using Godrej_Korber_DAL.TataCummins;
//using Godrej_Korber_Shared.Models.TataCummins;
//using System.Data;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmptyPalletOutController : ControllerBase
//    {

//        DataTable dt = new DataTable();
//        //EmptyPalletOutDL objEmptyPalletOut = new EmptyPalletOutDL();

//        // GET: api/<EmptyOutController>
//        [Route("api/EmptyPalletOut/GetEmptyPalletOut")]
//        [HttpGet]
//        public JsonResult GetEmptyPalletOut(EmptyPallet palletnumber)
//        {
//            dt = objEmptyPalletOut.GetEmptyPalletOut(palletnumber.PALLET_NUMBER);
//            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
//            Dictionary<string, object> childRow;
//            foreach (DataRow row in dt.Rows)
//            {
//                childRow = new Dictionary<string, object>();
//                foreach (DataColumn col in dt.Columns)
//                {
//                    childRow.Add(col.ColumnName, row[col]);
//                }
//                parentRow.Add(childRow);
//            }
//            return new JsonResult(parentRow);
//        }

//        // GET api/<EmptyOutController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<EmptyOutController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<EmptyOutController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<EmptyOutController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
