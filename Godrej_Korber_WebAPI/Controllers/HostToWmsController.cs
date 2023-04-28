using Godrej_Korber_DAL;
using Godrej_Korber_Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class HostToWmsController : ControllerBase
    {

        DataTable dtResult = new DataTable();
        
        HostToWmsDL wmsDL= new HostToWmsDL();



        //// GET: api/<HostToWmsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<HostToWmsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        
        [Route("api/HostToWms/InsertInToHostToWms")]
        [HttpPost]
        public ActionResult InsertInToHostToWms([FromBody] HostToWmsModel wmsModel)
        {

            wmsModel.MSG_WRK_STN = System.Environment.MachineName;
            wmsModel.MSG_WRK_USER = "AJIT SONVANE";


            dtResult = wmsDL.InserIntoHostToWms(wmsModel);

            int output = Convert.ToInt32(dtResult.Rows[0][0]);

            if (output == 1)
            {
                return new JsonResult("Success");
            }

            else
            {
                return new JsonResult("Failed");
            }
        }


        //// PUT api/<HostToWmsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<HostToWmsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
