using Godrej_Korber_DAL;
using Godrej_Korber_Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LoginController : ControllerBase
    {
        DataTable dt = new DataTable();
        LoginDL objLogin = new LoginDL();

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<LoginController>
        //[Route("api/login/login")]
        //[HttpPost]
        //public ActionResult Post([FromBody] LoginModel login)
        //{
        //    //string connString = this.Configuration.GetConnectionString("DefaultConnection");
        //    login.username = "admin";
        //    login.password = "kiran11";
        //    dt = objLogin.GetLoginDetail(login.username);

        //    if (dt.Rows.Count != 0)
        //    {
        //        dt = objLogin.Login(login.username, login.password);

        //        if (dt.Rows.Count != 0)
        //        {
        //            return new JsonResult("Success");
        //        }

        //        return new JsonResult("Invalid Password");
        //    }

        //    return new JsonResult("Invalid UserName & Password");
        //}

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
