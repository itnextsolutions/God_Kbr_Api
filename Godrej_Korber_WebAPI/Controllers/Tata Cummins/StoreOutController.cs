using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http.Extensions;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
  
    public class StoreOutController : ControllerBase
    {
        DataTable dtResult = new DataTable();
       // StoreOutDL objStoreOutDL = new StoreOutDL();

        private readonly ILogger<StoreOutController> _logger;
        private readonly StoreOutDL objStoreOutDL;

        public StoreOutController(ILogger<StoreOutController> logger, StoreOutDL EmptyDAL)
        {
            _logger = logger;
            objStoreOutDL = EmptyDAL;
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
        [Route("api/StoreOut/GetStoreOutData")]
        [HttpGet]
        public JsonResult Get_Store_Out_Data()
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            _logger.LogInformation("Intialization Of GetStoreOutData Process Has Been Started By this User = " + UserName );

             dtResult = objStoreOutDL.Get_Store_Out_Data();

            if(dtResult.Rows.Count > 0)
            {
                _logger.LogInformation("Retrived The Data Successfully By This User = " + UserName);

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
                return new JsonResult(parentRow);
            }
            _logger.LogInformation("There Is No Data Database As Per Your Requirement,Count Was Null");
            return new JsonResult(null);

        }

        [Authorize]
        [Route("api/StoreOut/GetPalletDetails")]
        [HttpPost]
        public JsonResult Get_PalletDetails_Data([FromBody] List<FetchPallet> parameter)
        //public JsonResult Get_PalletDetails_Data_Single_Check([FromQuery] List<string> parameter)
        {
            //List<string[]> myList = JsonSerializer.Deserialize<List<string[]>>(parameter);


            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (parameter != null)
            {
                _logger.LogInformation("Intialization Of GetPalletDetails_Multi_Check Process Has Been Started By this User = " + UserName);

                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (var item in parameter)
                {
                    //var stuff = JsonConvert.DeserializeObject(Convert.ToString(item));

                    dtResult = objStoreOutDL.Get_PalletDetails_Data(item);
                    foreach (DataRow row in dtResult.Rows)
                    {
                        childRow = new Dictionary<string, object>();
                        foreach (DataColumn col in dtResult.Columns)
                        {
                            childRow.Add(col.ColumnName, row[col]);
                        }
                        parentRow.Add(childRow);
                    }
                }

                //dtResult = objStoreOutDL.Get_PalletDetails_Data(parameter);

               
               

                return new JsonResult(parentRow);
            }

            return new JsonResult(null);

        }

        [Authorize]
        [Route("api/StoreOut/GetPalletDetails_Multi_Check")]
        [HttpGet]
        public JsonResult Get_PalletDetails_Data_MultiCheck(List<String> parameter)
        {

            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(parameter != null)
            {
                _logger.LogInformation("Intialization Of GetPalletDetails_Multi_Check Process Has Been Started By this User = " + UserName);

                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;

                foreach (var itm in parameter)
                {
                    dtResult = objStoreOutDL.Get_PalletDetails_Data(itm);

                        foreach (DataRow row in dtResult.Rows)
                        {
                            childRow = new Dictionary<string, object>();
                            foreach (DataColumn col in dtResult.Columns)
                            {
                                childRow.Add(col.ColumnName, row[col]);
                            }
                            parentRow.Add(childRow);
                        }
                }

                return new JsonResult(parentRow);
            }

            return new JsonResult(null);
        }

        [Authorize]
        [Route("api/storeOut/InsertOrderData")]
        [HttpPost]
        public JsonResult Insert_Order_Item([FromBody] List<OrderData> orderData)
        {

            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;
            if ( orderData != null && orderData.Count > 0)
            {
                _logger.LogInformation("Intialization Of Insert_Order_Item Process Has Been Started By this User = " + UserName);
                foreach (OrderData data in orderData)
                {
                    data.EXE_USER = UserName;
                    data.EXE_WKS_ID = System.Environment.MachineName;

                    dtResult = objStoreOutDL.Insert_Into_OrderItm(data);
                }

                if(dtResult.Rows.Count > 0) { 

                    int output = Convert.ToInt32(dtResult.Rows[0][0]);

                    if (output == 1)
                    {
                        _logger.LogInformation("Data Has Been  Inserted Suceessfully By These User = " + UserName);

                        return new JsonResult(output);
                    }

                    else
                    {
                        _logger.LogInformation("Data Has Not Been  Inserted By These User = " + UserName);

                        return new JsonResult(output);
                        
                    }
                }
            }


            return new JsonResult(null);
        }



        [Authorize]
        [Route("api/storeOut/Insert_StockMovt_Update_StockItm")]
        [HttpPost]
        public JsonResult Insert_StockMovt_Update_StockItm([FromBody] List<StoreOutModel> storeOutData)
        {

            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (storeOutData != null)
            {
               
                foreach (StoreOutModel item in storeOutData)
                {
                    _logger.LogInformation("Intialization Of Insert_StockMovt_Update_StockItm Process Has Been Started By this User = " + UserName);

                    item.EXE_USER = UserName;
                    item.EXE_WKS_ID = System.Environment.MachineName;

                    dtResult = objStoreOutDL.Insert_and_update_storeOutData(item);
                }

                if (dtResult.Rows.Count > 0)
                {
                    int output = Convert.ToInt32(dtResult.Rows[0][0]);
                    return new JsonResult(output);
                }
                else 
                { 
                    return new JsonResult(null);
                }



            }
            return new JsonResult(null);
        }


       

    }
}
