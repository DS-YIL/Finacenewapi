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
    
    public partial class UploadHistory
    {
        public int FileNo { get; set; }
        public string FileName { get; set; }
        public int SuccessRecords { get; set; }
        public int FailedRecords { get; set; }
        public string Status { get; set; }
        public string Uploaded_By { get; set; }
        public Nullable<System.DateTime> System_Date { get; set; }
        public string FileType { get; set; }
    }
}
