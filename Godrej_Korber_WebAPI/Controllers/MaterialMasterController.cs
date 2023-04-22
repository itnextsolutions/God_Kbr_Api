using Godrej_Korber_DAL;
using Godrej_Korber_Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class MaterialMasterController : ControllerBase
    {
        DataTable dt = new DataTable();
        MaterialMasterDL materialDal = new MaterialMasterDL();
        //GET: api/<MaterialMasterController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<MaterialMasterController>/5
        [Route("api/MaterialMaster/GetProduct")]
        [HttpGet]
        //public string Get()
        //{
        //    dt = materialDal.GetProduct();
        //    return "Sucess";
        //}

        public JsonResult GetProductData()
        {
            dt = materialDal.GetProduct();
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


        [Route("api/MaterialMaster/GetMaterialCategory")]
        [HttpGet]
        public JsonResult GetMaterialCategory()
        {
            dt = materialDal.GetMaterialCategory();
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


        // POST api/<MaterialMasterController>
        [Route("api/MaterialMaster/InsertMaterial")]
        [HttpPost]
        public ActionResult Post([FromBody] MaterialMasterModel materialMaster)
        {
            dt = materialDal.InsertMaterial(materialMaster);

            return new JsonResult("Succes");

        }

        //// PUT api/<MaterialMasterController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MaterialMasterController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
