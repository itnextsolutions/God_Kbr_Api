using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_Shared.Models.TataCummins
{
    public class StoreRequestCancellationModel
    {
        public int ORD_ID { get; set; }

        public int HU_ID { get; set; }

        public string MSG_WRK_STN { get; set; }

        public string MSG_WRK_USER { get; set; }
    }
}
