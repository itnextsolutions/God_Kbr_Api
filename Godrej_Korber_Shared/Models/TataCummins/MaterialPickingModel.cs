using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_Shared.Models.TataCummins
{
    public class MaterialPickingModel
    {

        public int PALLET_ID { get; set; }

        public int  MSG_ORD_ID { get; set; }

        public int MSG_RSV_QTY { get; set; }

        public string MSG_CRE_WKS_ID { get; set; }

        public string MSG_CRE_USER { get; set; }
    }
}
