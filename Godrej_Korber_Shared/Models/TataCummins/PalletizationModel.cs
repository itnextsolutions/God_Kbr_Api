﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_Shared.Models.TataCummins
{
    public class PalletizationModel
    {
        public double ORD_REQ_QTY { get; set; }

        public int ORD_ID { get; set; }

        public string ORD_PRD_COD { get; set; }

        public string ORD_REF_NR { get; set; }

        public string ORD_INSPECT_NR { get; set; }

        public string ORD_HU_BAR_COD { get; set; }

        public string ORD_REC_NR { get; set; }

        public string UserName { get; set; }

        public string UserID { get; set; }

        public int ORD_HU_ID { get; set; }

        public double ORD_RSV_QTY { get; set; }

        public string PRD_DESC { get; set; }

        public bool NOT_USEABLE { get; set; }

        public double SHELF_LIFE { get; set; }

    }
}
