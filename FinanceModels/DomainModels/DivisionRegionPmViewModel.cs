using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class DivisionRegionPmViewModel
    {
        public int descid { get; set; }
        public Nullable<int> Employeeno { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DeleteFlag { get; set; }
    }
}