﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class SummaryJobReportViewModel
    {
     
        public string wbselement { get; set; }
        public string CustomerName { get; set; }
        public string Division { get; set; }
        public string InvoiceNo { get; set; }
        public string CustomerCode { get; set; }
        public string DocOSCurrency { get; set; }
        public decimal DocOutstandingAmount { get; set; }
        public decimal tdsamount { get; set; }
        public decimal retentionamount { get; set; }
        public decimal inrinvoiceamount { get; set; }
        public decimal days1to30 { get; set; }
        public decimal days31to60 { get; set; }
        public decimal days61to90 { get; set; }
        public decimal days91to180 { get; set; }
        public decimal days366to730 { get; set; }
        public decimal above730days { get; set; }
        public decimal receiptamount { get; set; }
        public decimal Provision { get; set; }
        public decimal notdue { get; set; }
        public decimal outstandingamount { get; set; }
    }
}