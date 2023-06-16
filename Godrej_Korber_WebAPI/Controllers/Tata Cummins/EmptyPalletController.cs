using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmptyPalletController : ControllerBase
    {

        DataTable dt = new DataTable();
        //EmptyPalletDL objEmptyPalletOut = new EmptyPalletDL();

        private readonly ILogger<EmptyPalletController> _logger;
        private readonly EmptyPalletDL objEmptyPalletOut;

        public EmptyPalletController(ILogger<EmptyPalletController> logger, EmptyPalletDL EmptyDAL)
        {
            _logger = logger;
            objEmptyPalletOut = EmptyDAL;
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



        // GET: api/<EmptyOutController>
        [Route("api/EmptyPalletOut/GetEmptyPalletOut")]
        [HttpGet]
        public JsonResult GetEmptyPalletOut(int parameter)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(parameter != null)
            {
                _logger.LogInformation("Intialization Of EmptyPalletOut Process Has Been Started By this User = " + UserName + " And Requested Count Was =" +parameter);

                dt = objEmptyPalletOut.GetEmptyPalletOut(parameter);

                if(dt.Rows.Count > 0)
                {
                    _logger.LogInformation("Retrived The Data Successfully By This User = " + UserName);

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
                _logger.LogInformation("There Is No Data Database As Per Your Requirement,Count Was Null");
                return new JsonResult(null);
            }
            return new JsonResult(null);
        }

        [Route("api/EmptyPalletOut/GetEmptyPalletOut_1")]
        [HttpGet]
        public JsonResult GetEmptyPalletOut([FromBody] PalletNumber palletNumber)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (palletNumber != null)
            {

                _logger.LogInformation("Intialization Of EmptyPalletOut Process Has Been Started By this User = " + UserName + " And Requested Count Was =" + palletNumber);

                dt = objEmptyPalletOut.GetEmptyPalletOut(palletNumber.PALLET_NUMBER);

                if (dt.Rows.Count > 0) 
                {
                    _logger.LogInformation("Retrived The Data Successfully By This User = " + UserName);

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

                _logger.LogInformation("There Is No Data Database As Per Your Requirement,Count Was Null");
                return new JsonResult(null);
            }

            return new JsonResult(null);
        }
    


        [Route("api/EmptyPalletOut/InsertEmptyPalletData")]
        [HttpPost]
        public ActionResult InsertEmptyPalletData([FromBody] EmptyPallet emptyPalletData)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (emptyPalletData != null)
            {
                _logger.LogInformation("Intialization Of EmptyPalletIN Process Has Been Started By this User = " + UserName );

                emptyPalletData.HU_CRE_WKS_ID = System.Environment.MachineName;
                emptyPalletData.HU_CRE_USER = UserName;

                dt = objEmptyPalletOut.InsertEmptyPallet(emptyPalletData);

                //string output = Convert.ToString(dt.Rows[0][0]);

                int output = Convert.ToInt32(dt.Rows[0][0]);

                if(output == 0)
                {
                    _logger.LogInformation("Data Has Not Been Inserted " );

                }

                if (output == 1)
                {
                    _logger.LogInformation("Data Has Been Inserted ");

                }

                return new JsonResult(output);
            }
            return new JsonResult(null);
           
        }

        [Route("api/EmptyPallet/UpdateEmptyPallet")]
        [HttpPost]
        public ActionResult UpdateEmptyPallet([FromBody] List<EmptyPallet> emptyPallet)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(emptyPallet != null)
            {
                foreach (var data in emptyPallet)
                {

                    _logger.LogInformation("Intialization Of Update EmptyPalletOut Process Has Been Started By this User = " + UserName );

                    data.HU_CRE_USER = System.Environment.MachineName;
                    data.HU_CRE_WKS_ID = UserName;

                    dt = objEmptyPalletOut.UpdateEmptyPalletcheck(data);
                }

                //string output = Convert.ToString(dt.Rows[0][0]);
                int output = Convert.ToInt32(dt.Rows[0][0]);

                if (output == 0)
                {
                    _logger.LogInformation("Data Has Not Been Inserted ");

                }

                if (output == 1)
                {
                    _logger.LogInformation("Data Has Been Inserted ");

                }

                return new JsonResult(output);
            }

            return new JsonResult(null);
        }



    }
}
