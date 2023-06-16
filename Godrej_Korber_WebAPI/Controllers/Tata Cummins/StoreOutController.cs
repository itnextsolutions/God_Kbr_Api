using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http.Extensions;
using System.Reflection.Metadata;

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

        [Route("api/StoreOut/GetPalletDetails_Single_Check")]
        [HttpGet]
        public JsonResult Get_PalletDetails_Data_Single_Check(string parameter)
        {
            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(parameter != null)
            {
                _logger.LogInformation("Intialization Of GetPalletDetails_Single_Check Process Has Been Started By this User = " + UserName);

                dtResult = objStoreOutDL.Get_PalletDetails_Data(parameter);
                
                if (dtResult.Rows.Count > 0) 
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
            return new JsonResult(null);
            
         }


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


        //[Route("api/storeOut/Insert_StockMovt_Update_StockItm")]
        //[HttpPost]
        //public JsonResult Insert_StockMovt_Update_StockItm([FromBody] List<StoreOutModel> storeOutData)
        //{
        //    foreach (StoreOutModel item in storeOutData)
        //    {

        //        item.EXE_USER = System.Environment.MachineName;
        //        item.EXE_WKS_ID = "AJIT SONVANE";

        //        dtResult = objStoreOutDL.Insert_StockMovt(item);
        //    }

        //    int output = Convert.ToInt32(dtResult.Rows[0][0]);

        //    if (output == 1)
        //    {
        //        return new JsonResult("Success");
        //    }

        //    else
        //    {
        //        return new JsonResult("Failed");
        //    }

        //}


        [Route("api/storeOut/Insert_StockMovt_Update_StockItm")]
        
        [HttpPost]
        public JsonResult Insert_StockMovt_Update_StockItm_1([FromBody] UpdateList storeOutData)
        {

            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if(storeOutData != null)
            {
                foreach (OrderItm data in storeOutData.orderData)
                {

                    _logger.LogInformation("Intialization Of Insert_StockMovt_Update_StockItm (Update_Orderitm) Process Has Been Started By this User = " + UserName);

                    data.EXE_USER = UserName;
                    data.EXE_WKS_ID = System.Environment.MachineName;

                    objStoreOutDL.Update_Orderitm(data);

                }

                foreach (StoreOutModel item in storeOutData.storeOutData)
                {
                    _logger.LogInformation("Intialization Of Insert_StockMovt_Update_StockItm Process Has Been Started By this User = " + UserName);

                    item.EXE_USER = UserName;
                    item.EXE_WKS_ID = System.Environment.MachineName;

                    dtResult = objStoreOutDL.Insert_and_update_storeOutData(item);
                }

                int output = Convert.ToInt32(dtResult.Rows[0][0]);

                if (output == 1)
                {
                    _logger.LogInformation("Data Has Been Updated And Inserted Suceessfully By These User = " + UserName);

                    return new JsonResult("Success");
                }

                else
                {
                    _logger.LogInformation("Data Has Not Been Updated And Inserted By These User = " + UserName);

                    return new JsonResult("Failed");
                }

            }
            return new JsonResult(null);
        }

    }
}
