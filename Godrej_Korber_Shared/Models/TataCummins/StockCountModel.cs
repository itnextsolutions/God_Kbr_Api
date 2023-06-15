using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_Shared.Models.TataCummins
{
    public class StockCountModel
    {
        public int HU_ID { get; set; }
        public string STK_PRD_COD { get; set; }
        public string STK_REC_POS { get; set; }
        public string PRD_DESC { get; set; }
        public double STK_PRD_QTY { get; set; }
        public int LOC_AISL_ID { get; set; }
        public string LOC_X { get; set; }
        public string LOC_Y { get; set; }
        public string LOC_Z { get; set; }
        public string LOC_P { get; set; }

        public string USERNAME { get; set; }

        public string USER_ID { get; set; }

    }

}
