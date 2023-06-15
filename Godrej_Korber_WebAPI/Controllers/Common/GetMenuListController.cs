using Godrej_Korber_DAL.Common;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Godrej_Korber_WebAPI.Controllers.Common
{
    public class GetMenuListController : ControllerBase
    {
        DataTable dt = new DataTable();
        MenuListDL objmenulist = new MenuListDL();

        [Route("api/GetMenuList/GetMenu")]
        [HttpGet]
        public JsonResult GetMenu(int userid)
        {
            dt = objmenulist.GetMenuList(userid);

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

        
    }
}
