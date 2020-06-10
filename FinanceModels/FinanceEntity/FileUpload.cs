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
    
    public partial class FileUpload
    {
        public int ID { get; set; }
        public string BillingDocument { get; set; }
        public string ClearingDocument { get; set; }
        public Nullable<System.DateTime> Clearingdate { get; set; }
        public string CompanyCode { get; set; }
        public string DocumentType { get; set; }
        public string G_LAccount { get; set; }
        public string Assignment { get; set; }
        public string TermsofPayment { get; set; }
        public Nullable<double> Amountinlocalcurrency { get; set; }
        public string Account { get; set; }
        public string Text { get; set; }
        public string Accountname { get; set; }
        public string DocumentNumber { get; set; }
        public string Lineitem { get; set; }
        public string SpecialG_LInd { get; set; }
        public Nullable<System.DateTime> DocumentDate { get; set; }
        public Nullable<System.DateTime> PostingDate { get; set; }
        public string Documentcurrency { get; set; }
        public Nullable<double> AmountInDocCurr { get; set; }
        public string LocalCurrency { get; set; }
        public Nullable<System.DateTime> BaselinePaymentDte { get; set; }
        public Nullable<System.DateTime> NetDueDate { get; set; }
        public string PaymentReference { get; set; }
        public string DocumentHeaderText { get; set; }
        public string Referencekey3 { get; set; }
        public string Clearedopenitemssymbol { get; set; }
        public string Branchaccount { get; set; }
        public string Alternativeaccountno { get; set; }
        public string BaseUnitofMeasure { get; set; }
        public string Reference { get; set; }
        public string Clearedopenitemssymbol1 { get; set; }
        public string Discount1duedatesymbol { get; set; }
        public string Netduedatesymbol { get; set; }
        public string SalesDocument { get; set; }
        public string Referencekey_1 { get; set; }
        public string Referencekey_2 { get; set; }
        public string Invoicereference { get; set; }
        public string CostCenter { get; set; }
        public string Collectiveinvoice { get; set; }
        public string PostingKey { get; set; }
        public string Docstatus { get; set; }
        public string ProfitCenter { get; set; }
        public string FiscalYear { get; set; }
        public string Year_month { get; set; }
        public string AccountType { get; set; }
        public Nullable<double> TimeofEntry { get; set; }
        public string PostingPeriod { get; set; }
        public string Taxcode { get; set; }
        public string SalesDocumentItem { get; set; }
        public string Debit_CreditInd { get; set; }
        public string SpG_LTransType { get; set; }
        public string PmtMethSupplement { get; set; }
        public Nullable<double> Valuedate { get; set; }
        public string TradingPartner { get; set; }
        public string ContractNumber { get; set; }
        public string ContractType { get; set; }
        public string Plant { get; set; }
        public string BillExchangeUsage { get; set; }
        public Nullable<System.DateTime> Paymentdate { get; set; }
        public Nullable<double> Daysnet { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentBlock { get; set; }
        public string Reasoncode { get; set; }
        public Nullable<double> Currentcashdiscamount { get; set; }
        public string MCARunID { get; set; }
        public string Effexchangerate { get; set; }
        public string Follow_ondoctype { get; set; }
        public string Generalledgercurrency { get; set; }
        public Nullable<double> Generalledgeramount { get; set; }
        public string DirectDebitPre_notification { get; set; }
        public string Negativeposting { get; set; }
        public string Fixed { get; set; }
        public string Pmntcardlineitem { get; set; }
        public string SettlementRun { get; set; }
        public string CreditControlArea { get; set; }
        public Nullable<double> HedgedAmount { get; set; }
        public string CreditControlAreaCurrency { get; set; }
        public string WBSelement { get; set; }
        public string Paymentsent { get; set; }
        public string BusinessPlace { get; set; }
        public string SectionCode { get; set; }
        public string Pmntcurrency { get; set; }
        public string Paymentorder { get; set; }
        public string Textsexist { get; set; }
        public string TextID { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Duenet { get; set; }
        public string Cashdisc1due { get; set; }
        public string ReverseClearing { get; set; }
        public string Acctsrblepledind { get; set; }
        public Nullable<double> Sortkey { get; set; }
        public string LineitemID { get; set; }
        public string Asset { get; set; }
        public string ClearingFiscalYear { get; set; }
        public Nullable<double> ClearingItem { get; set; }
        public string Processor { get; set; }
        public string Status { get; set; }
        public string PurchasingDocument { get; set; }
        public string Item { get; set; }
        public string Transaction { get; set; }
        public string AssetSubnumber { get; set; }
        public string Order { get; set; }
        public string ScheduleLineNumber { get; set; }
        public Nullable<double> Valuatedamount { get; set; }
        public Nullable<double> Valuatedamtloccurr2 { get; set; }
        public Nullable<double> ValuatedamtlocCurr3 { get; set; }
        public Nullable<double> AmountInlocCurr2 { get; set; }
        public string Localcurrency2 { get; set; }
        public Nullable<double> AmtInlocCurr3 { get; set; }
        public string OffsettaccountType { get; set; }
        public string Localcurrency3 { get; set; }
        public string BusinessArea { get; set; }
        public string DunningArea { get; set; }
        public string Lastdunned { get; set; }
        public string Dunningblock { get; set; }
        public string Dunninglevel { get; set; }
        public string Dunningkey { get; set; }
        public Nullable<double> WithholdingTaxAmnt { get; set; }
        public Nullable<double> IntCalcNumerator { get; set; }
        public Nullable<double> W_TaxExemptAmount { get; set; }
        public Nullable<double> WithhldgTaxBaseAmount { get; set; }
        public Nullable<double> DiscountBaseAmount { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public string OffsettingAcctNo { get; set; }
        public string RelatedInvIsCustomer_Disputed { get; set; }
        public Nullable<double> CashDiscamtLC { get; set; }
        public string FlowType { get; set; }
        public Nullable<double> ArrearsForDiscount1 { get; set; }
        public Nullable<double> ArrearsAfterNetDueDate { get; set; }
        public string MandateReference { get; set; }
        public Nullable<double> DiscountPercent1 { get; set; }
        public Nullable<double> Days1 { get; set; }
        public string RefKeyHeader2 { get; set; }
        public Nullable<double> DiscountPercent2 { get; set; }
        public Nullable<double> Days2 { get; set; }
        public string DisputedItem { get; set; }
        public string DocumentArchived { get; set; }
        public string Instructionkey1 { get; set; }
        public string Instructionkey2 { get; set; }
        public string Instructionkey3 { get; set; }
        public string Instructionkey4 { get; set; }
        public Nullable<double> AmtiInPaymentCurrency { get; set; }
        public string CaseID { get; set; }
        public string TextForPriority { get; set; }
        public string Mandate { get; set; }
        public string NoName { get; set; }
        public string Reversedwith { get; set; }
        public string HouseBank { get; set; }
        public string Customer { get; set; }
        public string Vendor { get; set; }
        public string CheckNumberFrom { get; set; }
        public string ReferenceKey { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string ParkedBy { get; set; }
        public string UserName { get; set; }
        public string Name1 { get; set; }
        public Nullable<int> FileNo { get; set; }
    
        public virtual ARR_UploadHistory ARR_UploadHistory { get; set; }
    }
}