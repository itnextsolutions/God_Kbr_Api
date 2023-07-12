using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    public class StockCountController : ControllerBase
    {
        DataTable dt = new DataTable();

        //StockCountDL objStockCount = new StockCountDL();
        private readonly ILogger<StockCountController> _logger;
        private readonly StockCountDL objStockCount;

        public StockCountController(ILogger<StockCountController> logger, StockCountDL stockDAL)
        {
            _logger = logger;
            objStockCount = stockDAL;
        }
        public ActionResult<Dictionary<string, string>> GetAllHeaders()
        {
            Dictionary<string, string> requestHeaders =
               new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key,header.Value);
            }
            return requestHeaders;
        }


        public ActionResult<string> GetHeaderData(string headerKey)
        {
            Request.Headers.TryGetValue("username", out var headerValue);

            return Ok(headerValue);
        }


        [Authorize]
        [Route("api/StockCount/GetStockCount")]
        [HttpGet]
        public JsonResult GetStockCount()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var headerValues = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of Stock Count Process Has Been Started By this User = " + headerValues);

            dt = objStockCount.GetStockCount(headerValues);

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
            return new JsonResult(null);

        }

        [Authorize]
        [Route("api/StockCount/GetPalletDetails")]
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public JsonResult GetPalletDetails(string partno, string grno)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var headerValues = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(partno != null && grno != null)
            {
                _logger.LogInformation("Intialization Of Stock Count Process Has Been Started By this User = " + headerValues);

                dt = objStockCount.GetPalletDetails(partno, grno, headerValues);
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
                _logger.LogInformation("There Is No Data In Database As Per Your Requirement,Count Was Null");
                return new JsonResult(null);
            }
            _logger.LogInformation("Null Data Is Coming");
            return new JsonResult(null);

        }

        [Authorize]
        [Route("api/StockCount/GetPalletDetails1")]
        [HttpGet]
        public JsonResult GetPalletDetails1()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var headerValues = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of Stock Count Process Has Been Started By this User = " + headerValues);

            dt = objStockCount.GetPalletDetails1(headerValues);

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
            _logger.LogInformation("There Is No Data In Database As Per Your Requirement,Count Was Null");
            return new JsonResult(null);
        }

        [Authorize]
        [Route("api/StockCount/UpdateInsert")]
        [HttpPost]
        public ActionResult UpdateInsert([FromBody] List<StockCountModel> stockcount)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var headerValues = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (stockcount != null)
            {
                _logger.LogInformation("Updating Of Stock Count Process Has Been Started By this User = " + headerValues);

                foreach (StockCountModel items in stockcount)
                {
                    dt = objStockCount.GetValidCountForFurtherProcess(items);

                    int output = Convert.ToInt32(dt.Rows[0][0]);

                    _logger.LogInformation("Got The Count = " + output);

                    if (output == 0)
                    {
                        dt = objStockCount.GetHuPar3(items);

                        int hupar3 = Convert.ToInt32(dt.Rows[0][0]);

                        _logger.LogInformation("Got The Aisl ID = " + hupar3);

                        items.USER_ID = System.Environment.MachineName;
                        items.USERNAME = headerValues;

                        dt = objStockCount.UpdateAndInsert(items, hupar3);

                        int UpdateOutput = Convert.ToInt32(dt.Rows[0][0]);
                        if (UpdateOutput == 0)
                        {
                            _logger.LogInformation("Data Has Not Been Updated & Inserted" );
                            return new JsonResult(UpdateOutput);
                        }
                        else if(UpdateOutput == 1)
                        {
                            _logger.LogInformation("Data Has Been Updated & Inserted Sucessfully ");
                            return new JsonResult(UpdateOutput);
                        }
                        else
                        {
                            _logger.LogInformation("NO, Response From Database");
                            return new JsonResult(UpdateOutput);
                        }
                    }
                }
            }

            _logger.LogInformation("Null Data Is Coming");
            return new JsonResult(null);
         
        }

        [Authorize]
        [Route("api/StockCount/StockCountByScannedId")]
        [HttpGet]
        public ActionResult StockCountByScannedId(int palletid)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var headerValues = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (palletid != null)
            {
                _logger.LogInformation("Intializing The Process Of Getting the Data Of This PalletID ="+palletid+"Has Been Started By These");

                dt = objStockCount.StockCountByScannedId(palletid);

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

                _logger.LogInformation("This PalleId = " + palletid + "Has Not Data");
                return new JsonResult(0);
            }

            _logger.LogInformation("Pallet_ID Was NUll" + palletid );
            return new JsonResult(null);

        }

        [Authorize]
        [Route("api/StockCount/UpdateInsertForConfirmation")]
        [HttpGet]
        public ActionResult UpdateInsertForConfirmation(StockCountModel stockCount)
        {

            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var headerValues = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(stockCount != null)
            {
                stockCount.USER_ID = System.Environment.MachineName;
                stockCount.USERNAME = headerValues;

                _logger.LogInformation("Updating Of Stock Count Confirmation Process Has Been Started By this User = " + headerValues);

                dt = objStockCount.UpdateInsertForConfirmation(stockCount);

                int UpdateOutput = Convert.ToInt32(dt.Rows[0][0]);
                if (UpdateOutput == 0)
                {
                    _logger.LogInformation("Data Has Not Been Updated & Inserted");
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
                    return new JsonResult(UpdateOutput);
                }
            }
            _logger.LogInformation("Null Data Is Coming");
            return new JsonResult(null);

        }

    }
}
