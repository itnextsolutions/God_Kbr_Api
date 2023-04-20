using Microsoft.AspNetCore.Mvc;
using Godrej_Korber_Shared.Models;
using Godrej_Korber_DAL;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ConfigurationController : ControllerBase
    {

        ConfigurationDL objConfigure = new ConfigurationDL();
        DataTable dtResult = new DataTable();


        // GET: api/<ConfigurationController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ConfigurationController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //// GET api/<ConfigurationController>/5
        [Route("api/configure/GetConfigureMaster")]
        [HttpGet]
        public IActionResult Get()
        {
            dtResult = objConfigure.getConfigurationMaster();
            return (IActionResult)dtResult;
        }


        // POST api/<ConfigurationController>
        [Route("api/configure/InsertConfigurationMaster")]
        [HttpPost]
        public ActionResult Post([FromBody] ConfigurationMaster configure)
        {
            objConfigure.InsertConfigurationMasterOracle(configure);
            return new JsonResult("Added");

        }

        //// PUT api/<ConfigurationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ConfigurationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
