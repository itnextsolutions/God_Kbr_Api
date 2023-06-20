using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    public class StoreRequestCancellationController : ControllerBase
    {
        //StoreRequestCancellationDL ObjGetStoreOutRequestCancellation = new StoreRequestCancellationDL();
        DataTable dt =new DataTable();

        private readonly ILogger<StoreRequestCancellationController> _logger;
        private readonly StoreRequestCancellationDL ObjGetStoreOutRequestCancellation;

        public StoreRequestCancellationController(ILogger<StoreRequestCancellationController> logger, StoreRequestCancellationDL storerequest)
        {
            _logger = logger;
            ObjGetStoreOutRequestCancellation = storerequest;
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

        [Authorize]
        [Route("api/StoreRequestCancellation/GetStoreOutRequestCancellation")]
        [HttpGet]
        public JsonResult GetStoreOutRequestCancellation()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var Username = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of Store Out Request Cancellation Process Has Been Started By this User = " + Username);

            dt = ObjGetStoreOutRequestCancellation.GetStoreOutRequestCancellation(Username);

            if (dt.Rows.Count > 0)
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
            return new JsonResult(null);
        }

        [Authorize]
        [Route("api/StoreRequestCancellation/UpdateOrderItem")]
        [HttpPost]
        public IActionResult UpdateOrderItem([FromBody] List<StoreRequestCancellationModel> storeRequestCancellations)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var Username = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(storeRequestCancellations != null)
            {
                foreach (StoreRequestCancellationModel items in storeRequestCancellations)
                {
                    _logger.LogInformation("Updating The Process Of Intialization In Store Request Cancellation Has Been Started By this User = " + Username);

                    dt = ObjGetStoreOutRequestCancellation.UpdateOrderItem(items,Username);

                    int UpdateOutput = Convert.ToInt32(dt.Rows[0][0]);
                    if (UpdateOutput == 0)
                    {
                        _logger.LogInformation("Data Has Not Been Updated & Inserted By These User ="+ Username);
                        return new JsonResult(UpdateOutput);
                    }
                    else if (UpdateOutput == 1)
                    {
                        _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully ");
                        return new JsonResult(UpdateOutput);
                    }
                    else
                    {
                        _logger.LogInformation("NO, Response From Database");
                        return new JsonResult("NO, Response From Database");
                    }
                }
            }
            _logger.LogInformation("Null Data Is Coming");
            return new JsonResult("Data Is Coming Null,You Need To Contact With Your Software Devloper");
        }

        [Authorize]
        [Route("api/StoreRequestCancellation/GetStoreInRequestCancelletion")]
        [HttpGet]
        public JsonResult GetRequestINCancelletion()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var Username = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of Store Out Request Cancellation Process Has Been Started By this User = " + Username);

            dt = ObjGetStoreOutRequestCancellation.GetRequestINCancelletion(Username);

            if(dt != null)
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

        //update status from STK to TRM

        [Authorize]
        [Route("api/RequestCancelletion/UpdateRequestCancelletion")]
        [HttpPost]
        public ActionResult UpdateRequestCancelletion([FromBody] List<StoreRequestCancellationModel> Requestdata)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var Username = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (Requestdata != null)
            {
                foreach (StoreRequestCancellationModel data in Requestdata)
                {
                    //objEmptyPalletOut.data = data.HU_ID;
                    data.MSG_WRK_STN = System.Environment.MachineName;
                    data.MSG_WRK_USER = Username;

                    dt = ObjGetStoreOutRequestCancellation.UpdateRequestCancelletion(data,Username);

                    int UpdateOutput = Convert.ToInt32(dt.Rows[0][0]);

                    if (UpdateOutput == 0)
                    {
                        _logger.LogInformation("Data Has Not Been Updated & Inserted By These User ="+ Username);
                        return new JsonResult(UpdateOutput);
                    }
                    else if (UpdateOutput == 1)
                    {
                        _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully ");
                        return new JsonResult(UpdateOutput);
                    }
                    else
                    {
                        _logger.LogInformation("NO, Response From Database");
                        return new JsonResult("NO, Response From Database");
                    }
                }
            }
            _logger.LogInformation("Null Data Is Coming");
            return new JsonResult("Data Is Coming Null ,You Need To Contact With Your Software Devloper");
        }
    }
}
