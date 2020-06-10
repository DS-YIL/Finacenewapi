using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class CollectionViewModel
    {
        public string Division { get; set; }
        public string PayType { get; set; }
        public string Region { get; set; }
        public decimal CollectedAmount { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public decimal TotalCollectionAmount { get; set; }

    }
}