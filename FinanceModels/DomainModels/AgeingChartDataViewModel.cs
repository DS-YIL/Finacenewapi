using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class AgeingChartDataViewModel
    {
        public string Ageing { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalCollectedAmount { get; set; }
        public string Region { get; set; }
        public string Division { get; set; }
        public string RegionValue { get; set; }
        public string DivisionValue { get; set; }
        public string CollectionMonth { get; set; }
        public string CollectionAmount { get; set; }
        public List<TotalDivision> TotalDivision { get; set; }
        public List<TotalRegion> TotalRegion { get; set; }
        public List<TotalAgingData> TotalAgeing { get; set; }

    }
}