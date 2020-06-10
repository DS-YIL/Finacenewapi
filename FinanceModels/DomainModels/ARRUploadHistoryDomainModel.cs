using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class ARRUploadHistoryDomainModel
    {
        public int FileNo { get; set; }
        public string FileName { get; set; }
        public Nullable<int> SuccessRecords { get; set; }
        public Nullable<int> FailedRecords { get; set; }
        public string Status { get; set; }
        public string Uploaded_By { get; set; }
        public Nullable<DateTime> System_Date { get; set; }
        public string FileType { get; set; }
        public Nullable<bool> DelFlag { get; set; }
        public string FilePath { get; set; }
    }
}
