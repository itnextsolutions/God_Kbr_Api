using Microsoft.AspNetCore.Mvc;
using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmptyPalletOutController : ControllerBase
    {
        EmptyPalletOutDL objEmptyPalletOut = new EmptyPalletOutDL();
        // GET: api/<EmptyOutController>
        [HttpGet]
        public IEnumerable<string> Get(EmptyPalletOut emptyPallet)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmptyOutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmptyOutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmptyOutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmptyOutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
