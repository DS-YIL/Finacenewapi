using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class OutstandingVsCollectionViewModel
    {
        public string Division { get; set; }
        public decimal CollectedAmount { get; set; }
        public decimal Outstandingamount { get; set; }
    }
}