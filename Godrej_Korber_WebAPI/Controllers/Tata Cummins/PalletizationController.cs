using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    public class PalletizationController : ControllerBase
    {
        DataTable dt = new DataTable();
        //PalletizationDL objpalletizationDL = new PalletizationDL();

        private readonly ILogger<PalletizationController> _logger;
        private readonly PalletizationDL objpalletizationDL;

        public PalletizationController(ILogger<PalletizationController> logger, PalletizationDL PalletizationDAL)
        {
            _logger = logger;
            objpalletizationDL = PalletizationDAL;
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

        [Route("api/PalletizationController/GetOrder")]
        [HttpGet]
        public JsonResult GetOrder(string gr_no)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (gr_no != null) 
            {
                _logger.LogInformation("Intialization Of Palletization Process Has Been Started By this User = " + UserName + " And The Requested Gr_No Was = "+gr_no );

                dt = objpalletizationDL.GetEmptyPalletOut(gr_no);

                if (dt != null)
                {
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
                return new JsonResult("There Is No Data Database As Per Your Requirement");
            }

            _logger.LogInformation("Null Data Is Coming");
            return new JsonResult("Data Is Coming Null,You Need To Contact With Your Software Devloper");
        }


        [Route("api/PalletizationController/UpdateInsert")]
        [HttpPost]
        public ActionResult UpdateInsert([FromBody] List<PalletizationModel> palletization)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(palletization != null)
            {
                _logger.LogInformation("Updating And Inserting Of Palletization Process Has Been Started By this User = " + UserName);

                foreach (PalletizationModel items in palletization)
                {
                    items.UserName = UserName;
                    items.UserID = System.Environment.MachineName;

                    dt = objpalletizationDL.UpdateInsert(items);

                    int UpdateOutput = Convert.ToInt32(dt.Rows[0][0]);

                    if (UpdateOutput == 0)
                    {
                        return new JsonResult("Data Has Not Been Updated & Inserted");
                    }
                    else if (UpdateOutput == 1)
                    {
                        return new JsonResult("Data Has Been Updated & Inserted Sucessfully ");
                    }
                    else
                    {
                        return new JsonResult("NO, Response From Database");
                    }
                }
            }

            _logger.LogInformation("Null Data Is Coming");
            return new JsonResult("Data Is Coming Null,You Need To Contact With Your Software Devloper");

        }

    }
}
