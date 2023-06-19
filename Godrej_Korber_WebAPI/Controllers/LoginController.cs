using Godrej_Korber_DAL;
using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models;
using Godrej_Korber_WebAPI.Controllers.Tata_Cummins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LoginController : ControllerBase
    {
        DataTable dtResult = new DataTable();
       // LoginDL objLogin = new LoginDL();

        private readonly ILogger<LoginController> _logger;
        private readonly LoginDL objLogin;

        public LoginController(ILogger<LoginController> logger, LoginDL LoginDAL)
        {
            _logger = logger;
            objLogin = LoginDAL;
        }
        public ActionResult<Dictionary<string, string>> GetAllHeaders()
        {
            Dictionary<string, string> requestHeaders =
               new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key, header.Value);
            }
            return requestHeaders;
        }


        public ActionResult<string> GetHeaderData(string headerKey)
        {
            Request.Headers.TryGetValue("username", out var headerValue);

            return Ok(headerValue);
        }

        private static IConfiguration _configuration;

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST api/<LoginController>
        [Route("api/login/login")]
        [HttpPost]
        public ActionResult Post([FromBody] LoginModel login)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(login != null)
            {
                _logger.LogInformation("Intialization Of Login Process Has Been Started By this User = " + UserName);

                dtResult = objLogin.GetLoginDetail(login);

                if (dtResult.Rows.Count > 0)
                {

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

                    var token = GenerateToken(login.username);

                    string User_Group = Convert.ToString(dtResult.Rows[0][0]);

                    dtResult = objLogin.Get_User_Role(User_Group);

                    string Role_ID = Convert.ToString(dtResult.Rows[0][0]);

                    _logger.LogInformation("Role Group = " + Role_ID);

                    _logger.LogInformation("Logged In Successfully!!" + UserName);

                    return Ok(new
                    {

                        Message = "Success",
                        User = parentRow,
                        jwtToken = token,
                        Role = Role_ID

                    });

                }
                else
                {
                    _logger.LogInformation("Logged In Failed!!" );
                    return new JsonResult("Fail");
                }
            }
            _logger.LogInformation("UserName Not Found");
            return new JsonResult(null);
        }

        private string GenerateToken(string username)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("zxcvbnmlkjhgfdsa"));
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("jwt:key")));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
                //new Claim("CompanyName","Lets Program")
            };
            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("jwt:Issuer"),
                audience: _configuration.GetValue<string>("jwt:Audience"),
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential
                );

            return  tokenhandler.WriteToken(token);
        }

        //private string CreateRefreshToken()
        //{
        //    var tokenBytes = RandomNumberGenerator.GetBytes(64);
        //    var refreshToken = Convert.ToBase64String(tokenBytes);

        //    var tokenInUser = login.username
        //        .Any(async => RefreshToken == refreshToken);
        //    if (tokenInUser)
        //    {
        //        return CreateRefreshToken();
        //    }
        //    return CreateRefreshToken();
        //}

        //private ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        //{
        //    var key = Encoding.UTF8.GetBytes("thisisveryveryimportantkey");
        //    var tokenValidationParamters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateLifetime = false
        //    };
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    SecurityToken securityToken;
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParamters, out securityToken);
        //    var jwtSecurityToken = securityToken as JwtSecurityToken;
        //    if(jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,StringComparison.InvariantCultureIgnoreCase)) 
        //    {
        //        throw new SecurityTokenException("This is an Invalid Token");
        //    }
        //    return principal;    

        //}
        protected string decrypt_pwd(string password)
        {
            int i = Convert.ToInt32(password.Length);
            int j, iVal;
            string sChar;
            string sResult = "";
            char cRes;

            for (j = 0; j < i; j++)
            {
                sChar = password.Substring(j, 1);
                byte[] sAscii = Encoding.ASCII.GetBytes(sChar);

                iVal = 159 - Convert.ToInt32(sAscii[0]);
                cRes = Convert.ToChar(iVal);

                sResult = sResult + cRes;
            }

            return sResult;
        }

        //[HttpGet]
        //[Route("api/Users")]
        //public ActionResult GetAllUsers()
        //{
        //    dtResult = objLogin.GetUsers();
        //    List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> childRow;
        //    foreach (DataRow row in dtResult.Rows)
        //    {
        //        childRow = new Dictionary<string, object>();
        //        foreach (DataColumn col in dtResult.Columns)
        //        {
        //            childRow.Add(col.ColumnName, row[col]);
        //        }
        //        parentRow.Add(childRow);
        //    }
        //    return new JsonResult(parentRow);
        //}

    }
}
