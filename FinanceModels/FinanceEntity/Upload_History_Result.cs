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
    
    public partial class Upload_History_Result
    {
        public int FileNo { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Nullable<int> SuccessRecords { get; set; }
        public Nullable<int> FailedRecords { get; set; }
        public string Status { get; set; }
        public string Uploaded_By { get; set; }
        public Nullable<System.DateTime> System_Date { get; set; }
    }
}