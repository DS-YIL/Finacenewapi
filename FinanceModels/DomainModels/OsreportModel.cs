using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class OsreportModel
    {
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Region { get; set; }
        public string Division { get; set; }
        public string InvoiceNo { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public List<string> division { get; set; }
        //public string Projectmanager { get; set; }
        //public Nullable<System.DateTime> invoicedate { get; set; }
        ////public DateTime invoicedate { get; set; }
        //public Nullable<decimal> inrinvoiceamount { get; set; }

        //public Nullable<decimal> receiptamount { get; set; }
        //public Nullable<decimal> tdsamount { get; set; }
        //public Nullable<decimal> retentionamount { get; set; }
        //public Nullable<decimal> outstandingamount { get; set; }
    }
}
