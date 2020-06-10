using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class OsARReportViewModel
    {
        public string Region { get; set; }
        public string Division { get; set; }
        public string SalesOffice { get; set; }
        public string CustomerCode { get; set; }
        public string DocNo { get; set; }
        public string PostingDate { get; set; }
       // public string YGSSONo { get; set; }
        public string YilSono { get; set; }
        public string PoNo { get; set; }
        public string WBS { get; set; }
        public string WBSProjectName { get; set; }
        public string Projectmanager { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime invoicedate { get; set; }
        public decimal DocInvoiceAmount { get; set; }
        public string invoiceCurrancy { get; set; }
        public decimal INRInvAmt { get; set; }
        public decimal DocOutstandingAmount { get; set; }
        public string DocOSCurrency { get; set; }
        public decimal INROSAmt { get; set; }
        public decimal Collected { get; set; }
        public decimal TDS { get; set; }
        public decimal Retention { get; set; }
        public decimal NoDue { get; set; }
        public decimal days1to30 { get; set; }
        public decimal days31to60 { get; set; }
        public decimal days61to90 { get; set; }
        public decimal days91to180 { get; set; }
        public decimal days181to365 { get; set; }
        public decimal days366to730 { get; set; }
        public decimal above730days { get; set; }
        public decimal Provision { get; set; }
        public string Remarks { get; set; }
        public string ActionBy { get; set; }
       
    }
}