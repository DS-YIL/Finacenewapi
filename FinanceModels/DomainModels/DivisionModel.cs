using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class DivisionModel
    {
        public int descid { get; set; }
        public Nullable<int> Employeeno { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DeleteFlag { get; set; }
    }
}
