using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class OsBUReportDataModel
    {
     
        public Int32 Flag { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        //public string Division { get; set; }
        //public string Region { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
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

        public List<string> division { get; set; }
        public List<string> region { get; set; }
        public List<string> projectmanager { get; set; }
        public List<string> customername { get; set; }
        public DateTime? OsdDate { get; set; }
    }

    public class DateModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
