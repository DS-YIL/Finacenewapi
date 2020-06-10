using FinanceModels.DomainModels;
using FinanceModels.FinanceEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceDA.FileUploadDA
{
   public interface IFileUploadDA
    {
        Task<List<ARR_UploadHistory>> uploadHistory_GetData();
        DataTable exceldata(string localFile, string filePath);
        DataSet GetUploadHistory(string spName, SqlParameter[] paramArr, string tablename);
        Task<List<ARRUploadHistoryDomainModel>> GetAllUploadHistory();
        void DeleteRecord(int fileNo);
        Task<int> DeleteFileByFileNo(int fileno);
    }
}
