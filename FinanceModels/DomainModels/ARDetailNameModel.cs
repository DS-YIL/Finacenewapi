using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public  class ARDetailNameModel
    {
        //public int ARdetailID { get; set; }
        public int id { get; set; }
        public string CustomerName { get; set; }  
        public string CustomerCode { get; set; }
        public string Region { get; set; }
        public string Division { get; set; }
    }
}
