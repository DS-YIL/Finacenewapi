using FinanceModels.DomainModels;
using FinanceModels.FinanceEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceDA.FileUploadDA
{
   public class FileUpLoadDA:IFileUploadDA
    {

        // SqlConnection Conn1 = new SqlConnection(@"data source = 10.29.15.68;User ID=sa;Password=yil@1234; initial catalog = Logisticks1;Integrated Security=false;");
        SqlConnection Conn1 = new SqlConnection(@"Data Source=10.29.15.68;User ID=sa;Password=yil@1234;Initial Catalog=Logisticks1;Integrated Security=True;");
        SqlCommand Cmd = new SqlCommand();
        SqlDataAdapter Adp = new SqlDataAdapter();
        DataSet Ds = new DataSet();
        DataTable Dt;
        SqlParameter[] Param;

        public void OpenConection()
        {
            try
            {
                if (Conn1.State == ConnectionState.Closed)
                {
                    Conn1 = new SqlConnection(@"data source = 10.29.15.68;User ID=sa;Password=yil@1234; initial catalog = Logisticks1;Integrated Security=false;");
                    Conn1.Open();

                }
            }
            catch
            {
            }
        }

        public DataTable exceldata(string localFile, string filePath)
        {
            SqlConnection Conn1 = new SqlConnection(@"data source = 10.29.15.68;User ID=sa;Password=yil@1234; initial catalog = Logisticks1;Integrated Security=false;");
            File.Move(localFile, filePath);
            var query1 = "Insert into ARR_UploadHistory(FileName)" + "values(@FileName);";
            //using (var con = new SqlConnection(Conn1))
            using (var cmd = new SqlCommand(query1, Conn1))
            {
                cmd.Parameters.Add("@FileName", SqlDbType.VarChar, 500).Value = filePath;
                //cmd.Parameters.Add("@SuccessRecords", SqlDbType.Int).Value = SuccessRecords;
                Conn1.Open();
                cmd.ExecuteNonQuery();
                Conn1.Close();
            }
            DataTable dtexcel = new DataTable();

            bool hasHeaders = false;
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //Looping Total Sheet of Xl File
            /*foreach (DataRow schemaRow in schemaTable.Rows)
            }*/
            //Looping a first Sheet of Xl File
            DataRow schemaRow = schemaTable.Rows[0];
            string sheet = schemaRow["TABLE_NAME"].ToString();
            if (!sheet.EndsWith("_"))
            {
                string query = "SELECT  * FROM [Sheet1$]";
                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                dtexcel.Locale = CultureInfo.CurrentCulture;
                daexcel.Fill(dtexcel);
            }

            conn.Close();

            //Insert records to database table.
            Logisticks1Entities entities = new Logisticks1Entities();
            foreach (DataRow row in dtexcel.Rows)
            {
                entities.FileUploads.Add(new FileUpload
                {

                    CompanyCode = row["Company Code"].ToString(),
                    DocumentType = row["Document Type"].ToString(),
                    DocumentNumber = row["Document Number"].ToString(),
                    BillingDocument = row["Billing Document"].ToString(),
                    ClearingDocument = row["Clearing Document"].ToString(),
                    G_LAccount = row["G/L Account"].ToString(),
                    Assignment = row["Assignment"].ToString(),
                    TermsofPayment = row["Terms of Payment"].ToString(),
                    Account = row["Text"].ToString(),
                    Text = row["Terms of Payment"].ToString(),
                    Accountname = row["Account name"].ToString(),
                    Lineitem = row["Line item"].ToString(),
                    //SpecialG_LInd = row["Special G/L ind."].ToString(),
                    Documentcurrency = row["Document currency"].ToString(),
                    LocalCurrency = row["Local Currency"].ToString(),
                    PaymentReference = row["Payment reference"].ToString(),
                    DocumentHeaderText = row["Document Header Text"].ToString(),
                    Referencekey3 = row["Reference key 3"].ToString(),
                    Clearedopenitemssymbol = row["Cleared/open items symbol"].ToString(),
                    Branchaccount = row["Branch account"].ToString(),
                    //Alternativeaccountno = row["Alternative account no"].ToString(),
                    BaseUnitofMeasure = row["Base Unit of Measure"].ToString(),
                    Reference = row["Reference"].ToString(),
                    // Clearedopenitemssymbol1 = row["Clearedopenitemssymbol1"].ToString(),
                    // Discount1duedatesymbol = row["Discount1duedatesymbol"].ToString(),
                    // Netduedatesymbol = row["Netduedatesymbol"].ToString(),
                    SalesDocument = row["Sales Document"].ToString(),
                    Referencekey_1 = row["Reference key 1"].ToString(),
                    Referencekey_2 = row["Reference key 2"].ToString(),
                    Invoicereference = row["Invoice reference"].ToString(),
                    CostCenter = row["Cost Center"].ToString(),
                    Collectiveinvoice = row["Collective invoice"].ToString(),
                    PostingKey = row["Posting Key"].ToString(),
                    //Docstatus = row["Doc.status"].ToString(),
                    ProfitCenter = row["Profit Center"].ToString(),
                    FiscalYear = row["Fiscal Year"].ToString(),
                    Year_month = row["Year/month"].ToString(),
                    AccountType = row["Account Type"].ToString(),
                    PostingPeriod = row["Posting Period"].ToString(),
                    Taxcode = row["Tax code"].ToString(),
                    SalesDocumentItem = row["Sales Document Item"].ToString(),
                    // Debit_CreditInd = row["Debit/Credit Ind."].ToString(),
                    //SpG_LTransType = row["Sp.G/L trans.type"].ToString(),
                    // PmtMethSupplement = row["Pmt meth. supplement"].ToString(),
                    TradingPartner = row["Trading Partner"].ToString(),
                    ContractNumber = row["Contract Number"].ToString(),
                    ContractType = row["Contract Type"].ToString(),
                    Plant = row["Plant"].ToString(),
                    //BillExchangeUsage = row["Bill/Exchange Usage"].ToString(),
                    PaymentMethod = row["Payment Method"].ToString(),
                    PaymentBlock = row["Payment Block"].ToString(),
                    Reasoncode = row["Reason code"].ToString(),
                    MCARunID = row["MCA Run ID"].ToString(),
                    //Effexchangerate = row["Eff.exchange rate"].ToString(),
                    // Follow_ondoctype = row["Follow-on doc.type"].ToString(),
                    Generalledgercurrency = row["General ledger currency"].ToString(),
                    DirectDebitPre_notification = row["Direct Debit Pre-notification"].ToString(),
                    Negativeposting = row["Negative posting"].ToString(),
                    Fixed = row["Fixed"].ToString(),
                    Pmntcardlineitem = row["Pmnt card line item"].ToString(),
                    SettlementRun = row["Settlement run"].ToString(),
                    CreditControlArea = row["Credit control area"].ToString(),
                    CreditControlAreaCurrency = row["Credit control area currency"].ToString(),
                    WBSelement = row["WBS element"].ToString(),
                    Paymentsent = row["Payment sent"].ToString(),
                    BusinessPlace = row["Business Place"].ToString(),
                    SectionCode = row["Section Code"].ToString(),
                    Pmntcurrency = row["Pmnt currency"].ToString(),
                    Paymentorder = row["Payment order"].ToString(),
                    Textsexist = row["Texts exist"].ToString(),
                    TextID = row["Text ID"].ToString(),
                    Duenet = row["Due net"].ToString(),
                    // Cashdisc1due = row["Cash disc.1 due"].ToString(),
                    ReverseClearing = row["Reverse clearing"].ToString(),
                    //Acctsrblepledind = row["Accts rble pled.ind."].ToString(),
                    LineitemID = row["Line item ID"].ToString(),
                    Asset = row["Asset"].ToString(),
                    ClearingFiscalYear = row["Clearing Fiscal Year"].ToString(),
                    Processor = row["Processor"].ToString(),
                    Status = row["Status"].ToString(),
                    PurchasingDocument = row["Purchasing Document"].ToString(),
                    Item = row["Item"].ToString(),
                    Transaction = row["Transaction"].ToString(),
                    AssetSubnumber = row["Asset Subnumber"].ToString(),
                    Order = row["Order"].ToString(),
                    ScheduleLineNumber = row["Schedule Line Number"].ToString(),
                    Localcurrency2 = row["Local currency 2"].ToString(),
                    //OffsettaccountType = row["Offsett.account type"].ToString(),
                    Localcurrency3 = row["Local currency 3"].ToString(),
                    BusinessArea = row["Business Area"].ToString(),
                    DunningArea = row["Dunning Area"].ToString(),
                    Lastdunned = row["Last dunned"].ToString(),
                    Dunningblock = row["Dunning block"].ToString(),
                    Dunninglevel = row["Dunning level"].ToString(),
                    Dunningkey = row["Dunning key"].ToString(),
                    // OffsettingAcctNo = row["Offsetting acct no."].ToString(),
                    // RelatedInvIsCustomer_Disputed = row["Related Inv. Is Customer-Disputed"].ToString(),
                    FlowType = row["Flow Type"].ToString(),
                    MandateReference = row["Mandate Reference"].ToString(),
                    //RefKeyHeader2 = row["Ref.key (header) 2"].ToString(),
                    DisputedItem = row["Disputed item"].ToString(),
                    DocumentArchived = row["Document archived"].ToString(),
                    Instructionkey1 = row["Instruction key 1"].ToString(),
                    Instructionkey2 = row["Instruction key 2"].ToString(),
                    Instructionkey3 = row["Instruction key 3"].ToString(),
                    Instructionkey4 = row["Instruction key 4"].ToString(),
                    CaseID = row["Case ID"].ToString(),
                    TextForPriority = row["Text for Priority"].ToString(),
                    Mandate = row["Mandate"].ToString(),
                    // NoName = row[" "].ToString(),
                    Reversedwith = row["Reversed with"].ToString(),
                    HouseBank = row["House Bank"].ToString(),
                    Customer = row["Customer"].ToString(),
                    Vendor = row["Vendor"].ToString(),
                    CheckNumberFrom = row["Check number from"].ToString(),
                    ReferenceKey = row["Reference Key"].ToString(),
                    ParkedBy = row["Parked by"].ToString(),
                    UserName = row["User name"].ToString(),
                    Name1 = row["Name 1"].ToString(),


                });
            }
            entities.SaveChanges();
            return dtexcel;

        }

        public async Task<List<ARR_UploadHistory>> uploadHistory_GetData()
        {
            List<ARR_UploadHistory> uploadHistoryList = new List<ARR_UploadHistory>();
            SqlConnection con = null;
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Logisticks1Entities"].ConnectionString;

                using (con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.ARR_UploadHistory", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                uploadHistoryList.Add(new ARR_UploadHistory()
                                {
                                    FileNo = Convert.ToInt32(reader["FileNo"].ToString()),
                                });
                            }
                        }
                        reader.Close();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return uploadHistoryList;
        }

        public async Task<List<ARRUploadHistoryDomainModel>> GetAllUploadHistory()
        {
            using (var logisticksEntities = new Logisticks1Entities())
            {
                try
                {
                    var uploadHistoryList = await logisticksEntities.ARR_UploadHistory
                        .Where(t => t.DelFlag == true)
                        .OrderByDescending(t => t.FileNo)
                        .Select(h => new ARRUploadHistoryDomainModel
                        {
                            FileNo = h.FileNo,
                            FilePath = h.FilePath,
                            FileName = h.FileName,
                            SuccessRecords = h.SuccessRecords,
                            FailedRecords = h.FailedRecords,
                            System_Date = h.System_Date,
                            Uploaded_By = h.Uploaded_By

                        }).Take(8).ToListAsync();
                    return uploadHistoryList;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }




        public DataSet GetUploadHistory(string spName, SqlParameter[] paramArr, string tablename)
        {
            try
            {
                OpenConection();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn1;
                Cmd.CommandText = spName;
                Cmd.CommandTimeout = 0;
                Cmd.CommandType = CommandType.StoredProcedure;

                if (paramArr != null)
                {
                    foreach (SqlParameter sqlParam in paramArr)
                    {
                        Cmd.Parameters.Add(sqlParam);
                    }
                }

                Adp = new SqlDataAdapter(Cmd);
                Ds = new DataSet();
                Adp.Fill(Ds, tablename);

                Cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (Conn1.State != ConnectionState.Closed)
                {
                    Conn1.Close();
                    Conn1.Dispose();
                }
            }
            return Ds;
        }

        public void DeleteRecord(int fileNo)
        {
            using (var logisticksEntities = new Logisticks1Entities())
            {
                try
                {
                    var result = logisticksEntities.ARR_UploadHistory.Find(fileNo);
                    result.DelFlag = false;
                    logisticksEntities.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<int> DeleteFileByFileNo(int fileno)
        {
            var obj = new Logisticks1Entities();
            try
            {
                var data = obj.ARR_UploadHistory.Find(fileno);
                data.DelFlag = false;
                obj.SaveChanges();
                int file = data.FileNo;
                return file;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
