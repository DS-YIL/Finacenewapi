using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class MCReportModel
    {
        public string Division { get; set; }
        public Nullable<System.DateTime> oSdate { get; set; }
        public Nullable<decimal> OSAMt { get; set; }
        public Nullable<decimal> notDue { get; set; }
        public Nullable<decimal> retention { get; set; }
        public Nullable<decimal> collectable { get; set; }
        public Nullable<decimal> days1to30 { get; set; }
        public Nullable<decimal> days31to60 { get; set; }
        public Nullable<decimal> days61to90 { get; set; }
        public Nullable<decimal> days91to180 { get; set; }
        public Nullable<decimal> days181to365 { get; set; }
        public Nullable<decimal> days366to730 { get; set; }
        public Nullable<decimal> above730days { get; set; }
        public Nullable<decimal> Provision { get; set; }

    }
}