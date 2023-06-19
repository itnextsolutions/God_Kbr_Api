using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    
    public class MaterialPickingController : ControllerBase
    {
        DataTable dtResult = new DataTable();
        //MaterialPickingDL objMaterialPicking= new MaterialPickingDL();

        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;

        private readonly ILogger<MaterialPickingController> _logger;
        private readonly MaterialPickingDL objMaterialPicking;

        public MaterialPickingController(ILogger<MaterialPickingController> logger, MaterialPickingDL EmptyDAL)
        {
            _logger = logger;
            objMaterialPicking = EmptyDAL;
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
        [Route("api/MaterialPicking/Get_Material_Picking")]
        [HttpGet]
        public ActionResult Get_Material_picking_Data(int pallet_id)
        {
            if (pallet_id != null)
            {
                var header = GetAllHeaders();

                var values = GetHeaderData(Convert.ToString(header));

                var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

                _logger.LogInformation("Intialization Of Get_Material_Picking Process Has Been Started By this User = " + UserName+"Requested PalletID Was ="+pallet_id);

                 dtResult = objMaterialPicking.GET_MATERIAL_PICKING_DATA(pallet_id);

                if(pallet_id != null)
                {
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

        //[Route("api/MaterialPicking/Update_Material_Picking")]
        //[HttpPost]
        //public ActionResult  Update_Material_Picking_Data(MaterialPickingModel materialData)
        //{
        //    materialData.MSG_CRE_WKS_ID = USER_WKS_ID;
        //    materialData.MSG_CRE_USER = USER;

        //    dtResult = objMaterialPicking.UPDATE_MATERIAL_PICKING_DATA(materialData);
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

        [Authorize]
        [Route("api/MaterialPicking/UpdateMaterial")]
        [HttpPost]
        public ActionResult Update_Material_Picking_Data([FromBody] List<dynamic> materialData)
        //public ActionResult  Update_Material_Picking_Data([FromBody]List <MaterialPickingModel> materialData)
        {

            var header = GetAllHeaders();

            var values = GetHeaderData(Convert.ToString(header));

            var UserName = (Microsoft.Extensions.Primitives.StringValues)((ObjectResult)values.Result).Value;

            if (materialData != null)
            {
                _logger.LogInformation("Intialization Of UpdateMaterial Process Has Been Started By this User = " + UserName);

                string MSG_CRE_WKS_ID = System.Environment.MachineName;
                string MSG_CRE_USER = UserName;
                foreach (var item in materialData)
                {
                    var stuff = JsonConvert.DeserializeObject(Convert.ToString(item));

                    dtResult = objMaterialPicking.UPDATE_MATERIAL_PICKING_DATA(stuff, MSG_CRE_USER, MSG_CRE_WKS_ID);
                }

                int output = Convert.ToInt32(dtResult.Rows[0][0]);

                if (output == 1)
                {
                    _logger.LogInformation("UpdateMaterial Has Been Successful By this User = " + UserName);

                    return new JsonResult("Success");
                }

                else
                {
                    _logger.LogInformation("UpdateMaterial Has Not Been Successful By this User = " + UserName);
                    return new JsonResult("Failed");
                }
            }
            return new JsonResult(null);

        }


    }
}
