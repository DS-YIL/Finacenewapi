using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class TotalAgingData
    {
        public decimal Totalamount { get; set; }
        public string Ageing { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalCollectedAmount { get; set; }
        public string Region { get; set; }
        public string Division { get; set; }
    }
}