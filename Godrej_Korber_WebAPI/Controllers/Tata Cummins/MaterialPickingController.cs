using Godrej_Korber_DAL.TataCummins;
using Godrej_Korber_Shared.Models.TataCummins;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Godrej_Korber_WebAPI.Controllers.Tata_Cummins
{
    
    public class MaterialPickingController : ControllerBase
    {
        DataTable dtResult = new DataTable();
        MaterialPickingDL objMaterialPicking= new MaterialPickingDL();

        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;



        [Route("api/MaterialPicking/Get_Material_Picking")]
        [HttpGet]
        public ActionResult Get_Material_picking_Data(int pallet_id)
        {
            dtResult = objMaterialPicking.GET_MATERIAL_PICKING_DATA(pallet_id);

            foreach (DataRow row in dtResult.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return new JsonResult (parentRow);
        }


        public ActionResult  Update_Material_Picking_Data(MaterialPickingModel materialData)
        {
            materialData.MSG_CRE_WKS_ID = System.Environment.MachineName;
            materialData.MSG_CRE_USER = "Ajit Sonvane";

            dtResult = objMaterialPicking.UPDATE_MATERIAL_PICKING_DATA(materialData);
            int output = Convert.ToInt32(dtResult.Rows[0][0]);

            if (output == 1)
            {
                return new JsonResult("Success");
            }

            else
            {
                return new JsonResult("Failed");
            }

            
        }
       
    }
}
