using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class JobSummaryAbove90ViewModel
    {
       public string wbselement { get; set; }
        public string ProjectManager { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        
        public decimal Above90days { get; set; }
        //public decimal outstandingamount { get; set; }
        //public decimal DocOutstandingAmount { get; set; }
        //public decimal inrinvoiceamount { get; set; }
    }
}