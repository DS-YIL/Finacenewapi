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
    
    public partial class ARDetail
    {
        public int ARdetailID { get; set; }
        public string BillingDocument { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> OutStandingAmount { get; set; }
        public string CompanyCode { get; set; }
        public string DocumentNumber { get; set; }
        public Nullable<System.DateTime> DocumentDate { get; set; }
        public Nullable<System.DateTime> PostingDate { get; set; }
        public Nullable<decimal> DocumentCurrency { get; set; }
        public Nullable<System.DateTime> BaseLinePaymentDte { get; set; }
        public Nullable<System.DateTime> NetDueDate { get; set; }
        public string InvoiceReference { get; set; }
        public string ProjectID { get; set; }
        public string ProjectManager { get; set; }
        public string SalesOffice { get; set; }
        public string SalesOfficeName { get; set; }
    }
}
