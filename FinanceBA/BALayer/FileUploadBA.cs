using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceModels.DSOModels;
using FinanceModels.FinanceEntity;
using FinanceDA.FileUploadDA;
using System.Data.SqlClient;
using FinanceModels.DomainModels;

namespace FinanceBA.BALayer
{
   public class FileUploadBA:IFileUploadBA
    {
        private readonly IFileUploadDA _fileUploadRepository;

        public FileUploadBA(IFileUploadDA fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }
        public async Task<List<ARR_UploadHistory>> uploadHistory_GetData()
        {
            return await _fileUploadRepository.uploadHistory_GetData();
        }
        public DataSet GetUploadHistory(string spName, SqlParameter[] paramArr, string tablename)
        {

            return _fileUploadRepository.GetUploadHistory(spName, paramArr, tablename);

        }
        public DataTable exceldata(string localFile, string filePath)
        {

            return _fileUploadRepository.exceldata(localFile, filePath);

        }

        public async Task<List<ARRUploadHistoryDomainModel>> GetAllUploadHistory()
        {
            return await _fileUploadRepository.GetAllUploadHistory();
        }

        public void DeleteRecord(int fileNo)
        {
            _fileUploadRepository.DeleteRecord(fileNo);
        }

        public async Task<int> DeleteFileByFileNo(int fileno)
        {
            return await _fileUploadRepository.DeleteFileByFileNo(fileno);
        }
    }
}
