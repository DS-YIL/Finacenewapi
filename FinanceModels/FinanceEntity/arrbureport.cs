//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanceModels.FinanceEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class arrbureport
    {
        public int id { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public string salesoffice { get; set; }
        public string CustomerCode { get; set; }
        public string docno { get; set; }
        public Nullable<System.DateTime> postingdate { get; set; }
        public string YilSono { get; set; }
        public string pono { get; set; }
        public string wbselement { get; set; }
        public string wbstext { get; set; }
        public string Projectmanager { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> invoicedate { get; set; }
        public Nullable<decimal> docinvoiceamount { get; set; }
        public string invoiceCurrancy { get; set; }
        public Nullable<decimal> inrinvoiceamount { get; set; }
        public Nullable<decimal> DocOutstandingAmount { get; set; }
        public string DocOSCurrency { get; set; }
        public Nullable<decimal> outstandingamount { get; set; }
        public Nullable<decimal> CollectedAmount { get; set; }
        public Nullable<decimal> tdsamount { get; set; }
        public Nullable<decimal> retentionamount { get; set; }
        public Nullable<decimal> notdue { get; set; }
        public Nullable<decimal> days1to30 { get; set; }
        public string Deleteflag { get; set; }
        public Nullable<System.DateTime> osDate { get; set; }
        public Nullable<decimal> days31to60 { get; set; }
        public Nullable<decimal> days61to90 { get; set; }
        public Nullable<decimal> days91to180 { get; set; }
        public Nullable<decimal> days181to365 { get; set; }
        public Nullable<decimal> days366to730 { get; set; }
        public Nullable<decimal> days730to1095 { get; set; }
        public Nullable<decimal> Provision { get; set; }
        public string ActionBy { get; set; }
        public string Remarks { get; set; }
    }
}