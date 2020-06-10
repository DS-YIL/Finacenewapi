using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class SummaryReportAbove90ViewModel
    {
                      
        public string Region { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string DocOSCurrency { get; set; }
        public string pono { get; set; }
        public string InvoiceNo { get; set; }
        public decimal inrinvoiceamount { get; set; }
        public decimal DocOutstandingAmount { get; set; }
        public decimal receiptamount { get; set; }
        public decimal tdsamount { get; set; }
        public decimal outstandingamount { get; set; }
        public DateTime postingdate { get; set; }
        public DateTime podate { get; set; }
        public DateTime invoicedate { get; set; }

    }
}