using Godrej_Korber_DAL.Common;
using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_WebAPI.Controllers.Tata_Cummins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata;

namespace Godrej_Korber_WebAPI.Controllers.Common
{
    public class DashboardController : ControllerBase
    {

        DataTable dt = new DataTable();
        //DashboardDL objDashboard = new DashboardDL();

        public readonly ILogger<DashboardController> _logger;
        public readonly DashboardDL objDashboard;

        public DashboardController(ILogger<DashboardController> logger, DashboardDL Dashboard)
        {
            _logger = logger;
             objDashboard = Dashboard;
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


        [Route("api/Dashboard/GetDashboardCount")]
        [HttpGet]
        public JsonResult GetDashboadCount()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of GetDashboadCount Process Has Been Started By this User = " + UserName );

            dt = objDashboard.GetDashboadCount();

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

        [Route("api/Dashboard/GetPalletStatus")]
        [HttpGet]
        public JsonResult GetPalletStatus()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of GetPalletStatus Process Has Been Started By this User = " + UserName);

            dt = objDashboard.GetPalletStatus();

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

        [Route("api/Dashboard/GetCraneStatus")]
        [HttpGet]
        public JsonResult GetCraneStatus()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of GetPalletStatus Process Has Been Started By this User = " + UserName);

            dt = objDashboard.GetCraneStatus();

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

    }
}
