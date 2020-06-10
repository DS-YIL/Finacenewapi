using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class SumaryReportModel
    {
        public Int32 Flag { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string ProjectManager { get; set; }
        public string Region { get; set; }
        public string Division { get; set; }
        public Int32 Employeeno { get; set; }
    }
}
