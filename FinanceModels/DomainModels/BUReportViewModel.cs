using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class BUReportViewModel
    {
        public decimal INRInvAmt { get; set; }
        public decimal INROSAmt { get; set; }
        public decimal Collected { get; set; }
        public decimal TDS { get; set; }
        public decimal Retention { get; set; }
        public decimal NoDue { get; set; }
        public decimal Provision { get; set; }
        //public string Region { get; set; }
        public string Division { get; set; }
        public decimal days1to30 { get; set; }
        public decimal days31to60 { get; set; }
        public decimal days61to90 { get; set; }
        public decimal days91to180 { get; set; }
        public decimal days181to365 { get; set; }
        public decimal days366to730 { get; set; }
        public decimal above730days { get; set; }

    }
}