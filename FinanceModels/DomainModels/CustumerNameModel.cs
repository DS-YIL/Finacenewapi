using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class CustumerNameModel
    {
        //public int ARdetailID { get; set; }
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Region { get; set; }
        public string Division { get; set; }

    }

}