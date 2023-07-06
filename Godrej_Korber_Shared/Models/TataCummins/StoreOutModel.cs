using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_Shared.Models.TataCummins
{
    public class StoreOutModel
    {
        public int ORD_ID { get; set; }

        public string ORD_REC_POS { get; set; }

        public string ORD_REC_NR { get; set; }

        public string PRD_DESC { get; set; }


        public string STK_PRD_COD { get; set; }

        public float STK_RSV_QTY { get; set; }

        public float STK_PRD_QTY { get; set; }

        public int HU_ID { get; set; }

        public string EXE_USER { get; set; }

        public string EXE_WKS_ID { get; set; }

        public int PARTIAL { get; set; }

        public int STK_ID { get; set; }



    }

    public class OrderItm
    {
        public int ORD_ID { get; set; }

        public string ORD_PRD_COD { get; set; }

        public float ORD_REQ_QTY { get; set; }

        public float RSV_QTY { get; set; }

        public int ORD_PARTIAL { get; set; }

        public string EXE_USER { get; set; }

        public string EXE_WKS_ID { get; set; }

    }


    public class UpdateList
    {
        public List<StoreOutModel> storeOutData { get; set; }

        public List<OrderItm> orderData { get; set; }
    }

    public class OrderData
    {
        public int ORD_ID { get; set; }

        public string ORD_REC_POS { get; set; }

        public string ORD_PRD_COD { get; set; }

        public float ORD_REQ_QTY { get; set; }

        public string EXE_USER { get; set; }

        public string EXE_WKS_ID { get; set; }

    }
}
