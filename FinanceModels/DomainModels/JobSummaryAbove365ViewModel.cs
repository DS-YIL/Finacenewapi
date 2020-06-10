using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class JobSummaryAbove365ViewModel
    {
        public string wbselement { get; set; }
        public string Projectmanager { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public decimal Above90days { get; set; }
        
    }
}