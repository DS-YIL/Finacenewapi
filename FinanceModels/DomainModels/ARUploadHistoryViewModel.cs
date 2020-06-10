using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class ARUploadHistoryViewModel
    {
        public int FileNo { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Nullable<int> SuccessRecords { get; set; }
        public Nullable<int> FailedRecords { get; set; }
        //public Nullable<DateTime> System_Date { get; set; }
        public string System_Date { get; set; }
        public string Uploaded_By { get; set; }
     
    }
}