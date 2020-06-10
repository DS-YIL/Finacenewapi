using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class OsArReportDataModel
    {
        public Int32 Flag { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string InvoiceNo { get; set; }
        public string RegionS { get; set; }
        public string DivisionS { get; set; }
        public string ProjectManager { get; set; }
        public Int32 ProjectManagerID { get; set; }
        public string SelectedValue { get; set; }
        public string txtSaleOrderNo { get; set; }
        public string txtDocNo { get; set; }
        public string txtInvoiceNo { get; set; }
        public string txtCustpono { get; set; }
        public string txtProjectId { get; set; }
        public string txtCustomerCode { get; set; }
        public string AgingCritria { get; set; }
    }
}
