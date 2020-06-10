using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class Newloginmodel
    {
        public string Userid { get; set; }
        public string password { get; set; }
        public int Orgdeptid { get; set; }
        public int EmployeeNo { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Department { get; set; }
        public string  Role { get; set; }
        public string values { get; set; }
        public List<string> Division { get; set; }
        public List<string> Region { get; set; }
    }
}
