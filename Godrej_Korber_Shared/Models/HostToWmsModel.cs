using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_Shared.Models
{
    public class HostToWmsModel
    {
        public string MSG_TYPE { get; set; }
        public string MSG_TRANS_ID { get; set; }
        public string MSG_REF_TRANS_ID { get; set; }
        public string MSG_PROJECT_ID { get; set; }
        public string MSG_DOM { get; set; }
        public string MSG_DOE { get; set; }
        public string MSG_VENDOR_CODE { get; set; }

        public string MSG_VENDOR_DESC { get; set; }

        public string MSG_MATERIAL_CODE { get; set; }
        public string MSG_MATERIAL_STATUS { get; set; }
        public float MSG_QUANTITY { get; set; }
        public float MSG_NO_OF_SP_BOX { get; set; }
        public string MSG_UOM { get; set; }
        public string MSG_MATERIAL_TYPE { get; set; }
        public string MSG_MATERIAL_CATEGORY { get; set; }
        public string MSG_MATERIAL_BARCODE { get; set; }
        public string MSG_REQ_ORIGIN { get; set; }
        public string MSG_DOR { get; set; }
        public string MSG_DIP_ROLL_NO { get; set; }
        public string MSG_INVOICE_NO { get; set; }
        public string MSG_GRN_NUM { get; set; }
        public string MSG_DESCRIPTION { get; set; }
        public int MSG_SHELF_LIFE { get; set; }
        public string MSG_VENDOR_CON { get; set; }
        public int MSG_PAL_TYPE { get; set; }
        public string MSG_WRK_STN { get; set; }
        public string MSG_WRK_USER { get; set; }

        public int MSG_ORD_ID { get; set; }

        public int MSG_ORD_DT_REQUEST { get; set; }


        public float MSG_LENG_QTY { get; set; }

        public string MSG_PART_FLAG { get; set; }

        public string MSG_TRANS_TYPE { get; set; }

        public int MSG_Hrs { get; set; }
    }

	public class UpdateData
	{
		public List<HostToWmsModel> WmsModels { get; set; }
		public string Hr { get; set; }
		//public IEnumerable<HostToWmsModel> data { get; set; }
	}

	//public class HostToWmsModel
	//{
	//    //public string MSG_TYPE { get; set; }
	//    //public string MSG_TRANS_ID { get; set; }
	//    //public string MSG_REF_TRANS_ID { get; set; }
	//    //public string MSG_PROJECT_ID { get; set; }
	//    //public string MSG_DOM { get; set; }
	//    //public string MSG_DOE { get; set; }
	//    public string MSG_VENDOR_CODE { get; set; }

	//    public string MSG_VENDOR_DESC { get; set; }
	//    public string MSG_MATERIAL_CODE { get; set; }
	//    //public string MSG_MATERIAL_STATUS { get; set; }
	//    //public float MSG_QUANTITY { get; set; }
	//    //public float MSG_NO_OF_SP_BOX { get; set; }
	//    //public string MSG_UOM { get; set; }
	//    //public string MSG_MATERIAL_TYPE { get; set; }
	//    public string MSG_MATERIAL_CATEGORY { get; set; }
	//    //public string MSG_MATERIAL_BARCODE { get; set; }
	//    //public string MSG_REQ_ORIGIN { get; set; }
	//    //public string MSG_DOR { get; set; }
	//    //public string MSG_DIP_ROLL_NO { get; set; }
	//    //public string MSG_INVOICE_NO { get; set; }
	//    //public string MSG_GRN_NUM { get; set; }
	//    public string MSG_DESCRIPTION { get; set; }
	//    //public int MSG_SHELF_LIFE { get; set; }
	//    //public string MSG_VENDOR_CON { get; set; }
	//    //public int MSG_PAL_TYPE { get; set; }
	//    //public string MSG_WRK_STN { get; set; }
	//    //public string MSG_WRK_USER { get; set; }
	//}
}
