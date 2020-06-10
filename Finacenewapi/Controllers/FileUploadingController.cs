using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FinanceBA.BALayer;
using FinanceModels.FinanceEntity;
using FinanceModels.DSOModels;
using FinanceModels.DomainModels;

namespace Finacenewapi.Controllers
{
    public class FileUploadingController : ApiController
    {
        private static int iSucceRows = 0, iFailedRows = 0;
        public static int fileno = 0;
        private readonly IFileUploadBA  _iFileUploadManager;

        public FileUploadingController(IFileUploadBA iFileUploadManager)
        {
            _iFileUploadManager = iFileUploadManager;
        }


        [HttpPost]
        [Route("api/FileUploading/UploadFile")]
        public async Task<string> UploadFile()
        {
            DSODataModel data = new DSODataModel();
            //var ctx = HttpContext.Current.Request;
            //var root = ctx.curr.Server.MapPath("~/App_Data");
            var ctx = HttpContext.Current.Request;
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            string path = "";
            string user = "";
            DateTime dateUpload;
            string FileName = "";
            
            int succRecs = 0, failRecs = 0;
            
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {

                await Request.Content.ReadAsMultipartAsync(provider);
                string FileType = ctx.Files.AllKeys[0];
                //string FileType = provider.FormData[0].ToString();
                //string FileType = "ARR-Report";
                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;

                    name = name.Trim('"');
                    string extension = System.IO.Path.GetExtension(name);
                    string result = name.Substring(0, name.Length - extension.Length);
                    FileName = result;
                    dateUpload = DateTime.Now;
                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, "files", name);
                    // SaveFilePathSQLServerADO(localFileName, filePath);
                    int successValue;
                    UpdateUploadHistory(filePath, FileName, FileType);
                    exceldata(localFileName, filePath, FileName, dateUpload, fileno, FileType);
                    //UpdateUploadHistory(filePath, FileName,  FileType);
                    this.uploadHistory();

                }
            }
            catch (Exception e)
            {
                return $"Error:{e.Message}";
            }
            return "File Uploaded!";
        }

        [HttpPost]
        [Route("api/FileUploading/UploadFile1")]
        public IHttpActionResult UploadFile1()
        {

            //var revisionId = "";
            var ctx = HttpContext.Current;
            //var root = ctx.Server.MapPath("~/App_Data");
            var httpRequest = HttpContext.Current.Request;
            var serverPath = ctx.Server.MapPath("~/App_Data");
            string parsedFileName = "";
            if (httpRequest.Files.Count > 0)
            {
                //revisionId = httpRequest.Files.AllKeys[0];
                var postedFile = httpRequest.Files[0];
                parsedFileName = string.Format(DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMM") + ToValidFileName(postedFile.FileName));
                serverPath = serverPath + string.Format("\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.ToString("MMM"));
                var filePath = Path.Combine(serverPath, ToValidFileName(postedFile.FileName));
                if (!Directory.Exists(serverPath))
                    Directory.CreateDirectory(serverPath);
                postedFile.SaveAs(filePath);

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

                DataRow schemaRow = schemaTable.Rows[0];
                string sheet = schemaRow["TABLE_NAME"].ToString();
                if (!sheet.EndsWith("_"))
                {
                    string query = "SELECT  * FROM [" + sheet + "]";
                    OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                    dtexcel.Locale = CultureInfo.CurrentCulture;
                    daexcel.Fill(dtexcel);
                }

                conn.Close();
                int iSucceRows = 0;
                try
                {
                    Logisticks1Entities entities = new Logisticks1Entities();
                    foreach (DataRow row in dtexcel.Rows)
                    {

                        ARR_Master mprIteminfos = new ARR_Master();
                        if (row[1].ToString() != "" && row[2].ToString() != "")
                        {
                            //string unitname = "";
                            //UnitMaster data = new UnitMaster();
                            //if (!string.IsNullOrEmpty(row[3].ToString()))
                            //    unitname = row[3].ToString();
                            //if (!string.IsNullOrEmpty(unitname))
                            //    data = entities.UnitMasters.Where(x => x.UnitName == unitname).FirstOrDefault();
                            //if (!string.IsNullOrEmpty(row[1].ToString()))
                            //    mprIteminfos.ItemDescription = row[1].ToString();
                            //mprIteminfos.RevisionId = Convert.ToInt32(revisionId);
                            //if (!string.IsNullOrEmpty(row[2].ToString()))
                            //    mprIteminfos.Quantity = Convert.ToInt32(row[2]);
                            //if (!string.IsNullOrEmpty(row[4].ToString()))
                            //    mprIteminfos.SOLineItemNo = row[4].ToString();
                            //if (!string.IsNullOrEmpty(row[5].ToString()))
                            //    mprIteminfos.TargetSpend = Convert.ToInt32(row[5]);
                            //if (!string.IsNullOrEmpty(row[6].ToString()))
                            //    mprIteminfos.MfgPartNo = row[6].ToString();
                            //if (!string.IsNullOrEmpty(row[7].ToString()))
                            //    mprIteminfos.MfgModelNo = row[7].ToString();
                            //if (!string.IsNullOrEmpty(row[8].ToString()))
                            //    mprIteminfos.ReferenceDocNo = row[8].ToString();
                            //if (data != null)
                            //    mprIteminfos.UnitId = data.UnitId;
                            //if (row[9].ToString() == "")
                            //    mprIteminfos.Itemid = "NewItem";
                            //else
                            //{
                            //    mprIteminfos.Itemid = row[9].ToString();
                            //    if (row[9].ToString() == "NewItem" || row[9].ToString() == "0000")
                            //        mprIteminfos.Itemid = "NewItem";
                            //}
                            //this._mprBusenessAcess.addMprItemInfo(mprIteminfos);
                            //entities.MPRItemInfoes.Add(mprIteminfos);
                            //entities.SaveChanges();
                        }
                        iSucceRows++;
                    }

                    //string unitname = row["UnitId"].ToString();
                    //var data = entities.UnitMasters.Where(x => x.UnitName == unitname).FirstOrDefault();

                    //MPRItemInfo mprIteminfos = new MPRItemInfo();
                    //if (row["ItemDescription"].ToString() != "" && row["Quantity"].ToString() != "")
                    //{
                    //	mprIteminfos.ItemDescription = row["ItemDescription"].ToString();
                    //	mprIteminfos.RevisionId = Convert.ToInt32(revisionId);
                    //	mprIteminfos.Quantity = Convert.ToInt32(row["Quantity"]);
                    //	mprIteminfos.SOLineItemNo = row["SOLineItemNo"].ToString();
                    //	mprIteminfos.TargetSpend = Convert.ToInt32(row["TargetSpend"]);
                    //	mprIteminfos.MfgPartNo = row["MfgPartNo"].ToString();
                    //	mprIteminfos.MfgModelNo = row["MfgModelNo"].ToString();
                    //	mprIteminfos.ReferenceDocNo = row["ReferenceDocNo"].ToString();
                    //	if(data!=null)
                    //	mprIteminfos.UnitId = data.UnitId;
                    //	if (row["YGSMaterialCode"].ToString() == "")
                    //		mprIteminfos.Itemid = "0000";
                    //	else
                    //	{
                    //		mprIteminfos.Itemid = row["YGSMaterialCode"].ToString();
                    //		if (row["YGSMaterialCode"].ToString() == "NewItem")
                    //			mprIteminfos.Itemid = "0000";
                    //	}
                    //	this._mprBusenessAcess.addMprItemInfo(mprIteminfos);
                    //	//entities.MPRItemInfoes.Add(mprIteminfos);
                    //	//entities.SaveChanges();
                    //}
                    //iSucceRows++;
                    //}
                    int succRecs = iSucceRows;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return Ok(parsedFileName);

        }

        public static DataTable exceldata(string localFile, string filePath, string FileName, DateTime dateUpload, int res, string FileType)
        {
            //SqlConnection Conn1 = new SqlConnection(@"data source = 10.29.15.68;User ID=sa;Password=yil@1234; initial catalog = Logisticks1;Integrated Security=false;");
            SqlConnection Conn1 = new SqlConnection(@"data source = CPC-_0108;User ID=sa;Password=yil@4321; initial catalog = Logisticks1;Integrated Security=false;");
            File.Move(localFile, filePath);
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
                string query = "SELECT  * FROM [" + sheet + "]";
                //string query = "SELECT  * FROM  [Summary$]";
                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                dtexcel.Locale = CultureInfo.CurrentCulture;
                daexcel.Fill(dtexcel);
            }

            conn.Close();
            iSucceRows = 0;
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Insert records to database table.
            Logisticks1Entities entities = new Logisticks1Entities();
            foreach (DataRow row in dtexcel.Rows)
            {
                if (FileType == "ARR-Report")
                {
                    entities.ARR_Master.Add(new ARR_Master
                    {
                        Fileno = fileno,
                        CustomerCode = row["Customer Cd#"].ToString(),
                        CustomerName = row["Customer Name"].ToString(),
                        osDate = Convert.ToDateTime(row["OS Date"].ToString()),
                        Division = row["Division"].ToString(),
                        docno = row["Doc#No#"].ToString(),
                        postingdate = Convert.ToDateTime(row["Posting Dt#"].ToString()),
                        salesoffice = row["Sales Office"].ToString(),
                        salesofficeName = row["Sales Office Name"].ToString(),
                        salesgroup = row["Sales Group"].ToString(),
                        SalesgroupName = row["Sales Group Name"].ToString(),
                        paymentterm = row["PAYMENT TERM"].ToString(),
                        paymenttermDescription = row["PAYMENT TERM TEXT"].ToString(),
                        sono = row["YGS SO No#"].ToString(),
                        pono = row["P#O#NO#"].ToString(),
                        podate = Convert.ToDateTime(row["P#O#Dt#"].ToString()),
                        wbselement = row["WBS"].ToString(),
                        wbstext = row["WBS/Project Name"].ToString(),
                        //projectmgrid = row["projectmgrid"].ToString(),
                        //Projectmanager = row["Incharge"].ToString(),
                        InvoiceNo = row["Inv#No#"].ToString(),
                        docinvoiceamount = Convert.ToDecimal(row["Doc#Inv#Amt#"].ToString()),
                        invoiceCurrancy = row["Curr#"].ToString(),
                        inrinvoiceamount = Convert.ToDecimal(row["INR Inv#Amt#"].ToString()),
                        //receiptamount = Convert.ToDecimal(row["receiptamount"].ToString()),
                        //Docreceiptamount = Convert.ToDecimal(row["Docreceiptamount"].ToString()),
                        //receiptCurrancy = row["receiptCurrancy"].ToString(),
                        invoicedate = Convert.ToDateTime(row["Inv#Dt#"].ToString()),
                        tdsamount = Convert.ToDecimal(row["TDS"].ToString()),
                        retentionamount = Convert.ToDecimal(row["Retention"].ToString()),
                        outstandingamount = Convert.ToDecimal(row["INR OS#Amt#"].ToString()),
                        DocOutstandingAmount = Convert.ToDecimal(row["Doc#OS#Amt#"].ToString()),
                        DocOSCurrency = row["Curr#1"].ToString(),
                        CollectedAmount = Convert.ToDecimal(row["Collected"].ToString()),
                        Narration = row["Narration"].ToString(),
                        noofdays = Convert.ToInt32(row["No#of Days"].ToString()),
                        NetDueDate = Convert.ToDateTime(row["Net Due Date"].ToString()),
                        JobCode = row["Job Code"].ToString(),
                        notdue = Convert.ToDecimal(row["Not Due"].ToString()),
                        days1to30 = Convert.ToDecimal(row["1 - 30 Days"].ToString()),
                        days31to60 = Convert.ToDecimal(row["31 - 60 Days"].ToString()),
                        days61to90 = Convert.ToDecimal(row["61 - 90 Days"].ToString()),
                        days91to180 = Convert.ToDecimal(row["91 - 180 Days"].ToString()),
                        days181to365 = Convert.ToDecimal(row["181 - 365 Days"].ToString()),
                        days366to730 = Convert.ToDecimal(row["366 - 730 Days"].ToString()),
                        above730days = Convert.ToDecimal(row["Above 730 Days"].ToString()),
                        days730to1095 = Convert.ToDecimal(row["730 - 1095 Days"].ToString()),
                        days1095to1460 = Convert.ToDecimal(row["1095 - 1460 Days"].ToString()),
                        days1460to1825 = Convert.ToDecimal(row["1460 - 1825 Days"].ToString()),
                        days1825to2190 = Convert.ToDecimal(row["1825 - 2190 Days"].ToString()),
                        days2190to2555 = Convert.ToDecimal(row["2190 - 2555 Days"].ToString()),
                        Above2555Days = Convert.ToDecimal(row["Above 2555 Days"].ToString()),
                        //rowno = row["rowno"].ToString(),
                        //Fileno = row["Fileno"].ToString(),
                        Region = row["Region"].ToString(),
                        YilSono = row["YIL SO No#"].ToString(),
                        Deleteflag = "N",
                        Provision = Convert.ToDecimal(row["Provision"].ToString())
                    }); ;
                    iSucceRows++;
                }

                else if (FileType == "SO Detail")
                {
                    entities.SO_Detail_Upload.Add(new SO_Detail_Upload
                    {
                        Projectdefinitionlevel0 = row["Project definition(level 0)"].ToString(),
                        SalesOffice = row["Sales Office"].ToString(),
                        // SalesDocumentNo = row["Sales Document No."].ToString(),
                        //SalesOrderItemNo = row["Sales Order Item No."].ToString(),
                        //Material = row["Material"].ToString(),
                        //MaterialDescription = row["MaterialDescription"].ToString(),
                        //QuotationNo = row["QuotationNo"].ToString(),
                        //QuotationItemNo = row["QuotationItemNo"].ToString(),
                        //Quotationvalidto = row["Quotationvalidto"].ToString(),
                        //BillingDocumentNo = row["BillingDocumentNo"].ToString(),
                        //SalesDocumentType = row["SalesDocumentType"].ToString(),
                        //TextSalesDocumentType = row["TextSalesDocumentType"].ToString(),
                        //SalesOrganization = row["SalesOrganization"].ToString(),
                        //TextSalesOrganization = row["TextSalesOrganization"].ToString(),
                        //DistributionChannel = row["DistributionChannel"].ToString(),
                        //TextDistributionChannel = row["TextDistributionChannel"].ToString(),
                        //TextSalesOffice = row["TextSalesOffice"].ToString(),
                        //TextSalesGroup = row["TextSalesGroup"].ToString(),
                        //SalesFU = row["SalesFU"].ToString(),
                        //POnumber = row["POnumber"].ToString(),
                        //Version = row["Version"].ToString(),
                        //Orderreason = row["Orderreason"].ToString(),
                        //TextOrderreason = row["TextOrderreason"].ToString(),
                        //SDdocumentcurrency = row["SDdocumentcurrency"].ToString(),
                        //ConditionGroup1 = row["ConditionGroup1"].ToString(),
                        //TextConditionGroup1 = row["TextConditionGroup1"].ToString(),
                        //DeliveryBlockStatusH = row["DeliveryBlockStatusH"].ToString(),
                        //Currency = row["Currency"].ToString(),
                        //TextDeliveryBlockStatusH = row["TextDeliveryBlockStatusH"].ToString(),
                        //BillingBlockStatusH = row["BillingBlockStatusH"].ToString(),
                        //TextBillingBlockStatusH = row["TextBillingBlockStatusH"].ToString(),
                        //Soldtoparty = row["Soldtoparty"].ToString(),
                        //NameSoldtoparty = row["NameSoldtoparty"].ToString(),
                        //Payer = row["Payer"].ToString(),
                        //NamePayer = row["NamePayer"].ToString(),
                        //Billtoparty = row["Billtoparty"].ToString(),
                        //NameBillingtoparty = row["NameBillingtoparty"].ToString(),
                        //Shiptoparty = row["Shiptoparty"].ToString(),
                        //NameShiptoparty = row["NameShiptoparty"].ToString(),
                        //ContactShip = row["ContactShip"].ToString(),
                        //Name1ContactShip = row["Name1ContactShip"].ToString(),
                        //Name2ContactShip = row["Name2ContactShip"].ToString(),
                        //Name3ContactShip = row["Name3ContactShip"].ToString(),
                        //TELNUMBERContactShip = row["TELNUMBERContactShip"].ToString(),
                        //ForwardingAgent = row["ForwardingAgent"].ToString(),
                        //NameForwardingAgent = row["NameForwardingAgent"].ToString(),
                        //Consignee = row["Consignee"].ToString(),
                        //NameConsignee = row["NameConsignee"].ToString(),
                        //EndUser = row["EndUser"].ToString(),
                        //NameEndUser = row["NameEndUser"].ToString(),
                        //Soldtoparty2 = row["Soldtoparty2"].ToString(),
                        //NameSoldtoparty2 = row["NameSoldtoparty2"].ToString(),
                        //Soldtoparty3 = row["Soldtoparty3"].ToString(),
                        //NameSoldtoparty3 = row["NameSoldtoparty3"].ToString(),
                        //SalesPerson = row["SalesPerson"].ToString(),
                        //NameSalesPerson = row["NameSalesPerson"].ToString(),
                        //SalesEngineer = row["SalesEngineer"].ToString(),
                        //NameSalesEngineer = row["NameSalesEngineer"].ToString(),
                        //ContentsChecker = row["ContentsChecker"].ToString(),
                        //Handledby = row["Handledby"].ToString(),
                        //NameHandledby = row["NameHandledby"].ToString(),
                        //Approver = row["Approver"].ToString(),
                        //NameApprover = row["NameApprover"].ToString(),
                        //ApprovalStatusChangedby = row["ApprovalStatusChangedby"].ToString(),
                        //NameApprovalStatusChangedby = row["NameApprovalStatusChangedby"].ToString(),
                        //Exporter = row["Exporter"].ToString(),
                        //NameExporter = row["NameExporter"].ToString(),
                        //Importer = row["Importer"].ToString(),
                        //NameImporter = row["NameImporter"].ToString(),
                        //SDUserStatus = row["SDUserStatus"].ToString(),
                        //TextSDUserStatus = row["TextSDUserStatus"].ToString(),


                    }
                        );
                    iSucceRows++;
                }

                else if (FileType == "Coll Detail")
                {
                    entities.CollectionDetails.Add(new CollectionDetail
                    {
                        DocumentNumber = row["DocumentNumber"].ToString(),
                        Lineitem = row["Line item"].ToString(),
                        PostingDate = Convert.ToDateTime(row["Posting Date"].ToString()),
                        DocumentDate = Convert.ToDateTime(row["DocumentDate"].ToString()),
                        DocumentType = row["DocumentType"].ToString(),
                        PostingKey = row["PostingKey"].ToString(),
                        Account = row["Account"].ToString(),
                        Accountname = row["Accountname"].ToString(),
                        GLAccount = row["GLAccount"].ToString(),
                        Reference = row["Reference"].ToString(),
                        Amountindoccurr = float.Parse(row["Amountindoccurr"].ToString()),
                        Documentcurrency = row["Documentcurrency"].ToString(),
                        Effexchangerate = row["Effexchangerate"].ToString(),
                        Amountinlocalcurrency = float.Parse(row["Amountinlocalcurrency"].ToString()),
                        LocalCurrency = row["LocalCurrency"].ToString(),
                        BusinessPlace = row["BusinessPlace"].ToString(),
                        Taxcode = row["Taxcode"].ToString(),
                        PurchasingDocument = row["PurchasingDocument"].ToString(),
                        Item = row["Item"].ToString(),
                        EntryDate = Convert.ToDateTime(row["EntryDate"].ToString()),
                        FiscalYear = row["FiscalYear"].ToString(),
                        Invoicereference = row["Invoicereference"].ToString(),
                        ReferenceKey = row["ReferenceKey"].ToString(),
                        Wtaxexemptamount = float.Parse(row["Wtaxexemptamount"].ToString()),
                        Withhldgtaxbaseamount = float.Parse(row["Withhldgtaxbaseamount"].ToString()),
                        Withholdingtaxamnt = float.Parse(row["Withholdingtaxamnt"].ToString()),
                        NoName = row["NoName"].ToString(),
                        AccountType = row["AccountType"].ToString(),
                        Acctsrblepledind = row["Acctsrblepledind"].ToString(),
                        Alternativeaccountno = row["Alternativeaccountno"].ToString(),
                        Amountinloccurr2 = float.Parse(row["Amountinloccurr2"].ToString()),
                        Amtinloccurr3 = float.Parse(row["Amtinloccurr3"].ToString()),
                        Amtinpaymentcurrency = float.Parse(row["Amtinpaymentcurrency"].ToString()),
                        Arrearsafternetduedate = float.Parse(row["Arrearsafternetduedate"].ToString()),
                        Arrearsfordiscount1 = float.Parse(row["Arrearsfordiscount1"].ToString()),
                        Asset = row["Asset"].ToString(),
                        Assignment = row["Assignment"].ToString(),
                        BaseUnitofMeasure = row["BaseUnitofMeasure"].ToString(),
                        BaselinePaymentDte = Convert.ToDateTime(row["EntryDate"].ToString()),
                        BillExchangeUsage = row["BillExchangeUsage"].ToString(),
                        BillingDocument = row["BillingDocument"].ToString(),
                        Branchaccount = row["Branchaccount"].ToString(),
                        BusinessArea = row["BusinessArea"].ToString(),
                        CaseID = row["CaseID"].ToString(),
                        CashdiscamtLC = float.Parse(row["CashdiscamtLC"].ToString()),
                        Cashdisc1due = row["Cashdisc1due"].ToString(),
                        Checknumberfrom = row["Checknumberfrom"].ToString(),
                        Clearedopenitemssymbol = row["Clearedopenitemssymbol"].ToString(),
                        Clearedopenitemssymbol1 = row["Clearedopenitemssymbol1"].ToString(),
                        Clearingdate = Convert.ToDateTime(row["Clearingdate"].ToString()),
                        ClearingDocument = row["ClearingDocument"].ToString(),
                        ClearingFiscalYear = row["ClearingFiscalYear"].ToString(),
                        Clearingitem = float.Parse(row["Clearingitem"].ToString()),
                        Collectiveinvoice = row["Collectiveinvoice"].ToString(),
                        CompanyCode = row["CompanyCode"].ToString(),
                        ContractNumber = row["ContractNumber"].ToString(),
                        ContractType = row["ContractType"].ToString(),
                        CostCenter = row["CostCenter"].ToString(),
                        Creditcontrolarea = row["Creditcontrolarea"].ToString(),
                        Creditcontrolareacurrency = row["Creditcontrolareacurrency"].ToString(),
                        Currentcashdiscamount = float.Parse(row["Currentcashdiscamount"].ToString()),
                        Customer = row["Customer"].ToString(),
                        Days1 = float.Parse(row["Days1"].ToString()),
                        Days2 = float.Parse(row["Days2"].ToString()),
                        Daysnet = float.Parse(row["Daysnet"].ToString()),
                        DebitCreditInd = row["DebitCreditInd"].ToString(),
                        DirectDebitPrenotification = row["DirectDebitPrenotification"].ToString(),
                        Discount1duedatesymbol = row["Discount1duedatesymbol"].ToString(),
                        Discountamount = float.Parse(row["Discountamount"].ToString()),
                        Discountbaseamount = float.Parse(row["Discountbaseamount"].ToString()),
                        DiscountPercent1 = float.Parse(row["DiscountPercent1"].ToString()),
                        DiscountPercent2 = float.Parse(row["DiscountPercent2"].ToString()),
                        Disputeditem = row["Disputeditem"].ToString(),
                        Docstatus = row["Docstatus"].ToString(),
                        Documentarchived = row["Documentarchived"].ToString(),
                        DocumentHeaderText = row["DocumentHeaderText"].ToString(),
                        Duenet = row["Duenet"].ToString(),
                        DunningArea = row["DunningArea"].ToString(),
                        Dunningblock = row["Dunningblock"].ToString(),
                        Dunningkey = row["Dunningkey"].ToString(),
                        Dunninglevel = row["Dunninglevel"].ToString(),
                        Fixed = row["Fixed"].ToString(),
                        FlowType = row["FlowType"].ToString(),
                        Followondoctype = row["Followondoctype"].ToString(),
                        Generalledgeramount = float.Parse(row["Generalledgeramount"].ToString()),
                        Generalledgercurrency = row["Generalledgercurrency"].ToString(),
                        Hedgedamount = float.Parse(row["Hedgedamount"].ToString()),
                        HouseBank = row["HouseBank"].ToString(),
                        Instructionkey1 = row["Instructionkey1"].ToString(),
                        Instructionkey2 = row["Instructionkey2"].ToString(),
                        Instructionkey3 = row["Instructionkey3"].ToString(),
                        Instructionkey4 = row["Instructionkey4"].ToString(),
                        Intcalcnumerator = float.Parse(row["Intcalcnumerator"].ToString()),
                        Lastdunned = row["Lastdunned"].ToString(),
                        LineitemID = row["LineitemID"].ToString(),
                        Localcurrency2 = row["Localcurrency2"].ToString(),
                        Localcurrency3 = row["Localcurrency3"].ToString(),
                        Mandate = row["Mandate"].ToString(),
                        MandateReference = row["MandateReference"].ToString(),
                        MCARunID = row["MCARunID"].ToString(),
                        Name1 = row["Name1"].ToString(),
                        Negativeposting = row["Negativeposting"].ToString(),
                        Netduedate = Convert.ToDateTime(row["Netduedate"].ToString()),
                        Pmntcardlineitem = row["Pmntcardlineitem"].ToString(),
                        Offsettaccounttype = row["Offsettaccounttype"].ToString(),
                        Offsettingacctno = row["Offsettingacctno"].ToString(),
                        PaymentBlock = row["PaymentBlock"].ToString(),
                        Paymentdate = Convert.ToDateTime(row["Paymentdate"].ToString()),
                        PaymentMethod = row["PaymentMethod"].ToString(),
                        Paymentorder = row["Paymentorder"].ToString(),
                        Paymentreference = row["Paymentreference"].ToString(),
                        Paymentsent = row["Paymentsent"].ToString(),
                        Plant = row["Plant"].ToString(),
                        Pmntcurrency = row["Pmntcurrency"].ToString(),
                        Pmtmethsupplement = row["Pmtmethsupplement"].ToString(),
                        PostingPeriod = row["PostingPeriod"].ToString(),
                        Processor = row["Processor"].ToString(),
                        ProfitCenter = row["ProfitCenter"].ToString(),
                        Quantity = float.Parse(row["Quantity"].ToString()),
                        Reasoncode = row["Reasoncode"].ToString(),
                        Refkeyheader2 = row["Refkeyheader2"].ToString(),
                        Referencekey1 = row["Referencekey1"].ToString(),
                        Referencekey2 = row["Referencekey2"].ToString(),
                        Referencekey3 = row["Referencekey3"].ToString(),
                        RelatedInvIsCustomerDisputed = row["RelatedInvIsCustomerDisputed"].ToString(),
                        Reverseclearing = row["Reverseclearing"].ToString(),
                        Reversedwith = row["Reversedwith"].ToString(),
                        SalesDocument = row["SalesDocument"].ToString(),
                        SalesDocumentItem = row["SalesDocumentItem"].ToString(),
                        ScheduleLineNumber = row["ScheduleLineNumber"].ToString(),
                        SectionCode = row["SectionCode"].ToString(),
                        Settlementrun = row["Settlementrun"].ToString(),
                        SpGLtranstype = row["SpGLtranstype"].ToString(),
                        SpecialGLind = row["SpecialGLind"].ToString(),
                        Status = row["Status"].ToString(),
                        Subnumber = row["Subnumber"].ToString(),
                        TermsofPayment = row["TermsofPayment"].ToString(),
                        Text = row["Text"].ToString(),
                        Sortkey = float.Parse(row["Sortkey"].ToString()),
                        TextID = row["TextID"].ToString(),
                        TextforPriority = row["TextforPriority"].ToString(),
                        Textsexist = row["Textsexist"].ToString(),
                        TimeofEntry = float.Parse(row["TimeofEntry"].ToString()),
                        TradingPartner = row["TradingPartner"].ToString(),
                        //Transaction = row["TradingPartner"].ToString(),
                        Username = row["Username"].ToString(),
                        Valuatedamount = float.Parse(row["Valuatedamount"].ToString()),
                        Valuatedamtloccurr3 = float.Parse(row["Valuatedamtloccurr3"].ToString()),
                        Valuatedamtloccurr2 = float.Parse(row["Valuatedamtloccurr2"].ToString()),
                        Valuedate = Convert.ToDateTime(row["Valuedate"].ToString()),
                        Vendor = row["Username"].ToString(),
                        WBSelement = row["WBSelement"].ToString(),
                        Yearmonth = row["Yearmonth"].ToString(),




                    }
                        );
                    iSucceRows++;
                }
            }
            //foreach (DataRow row in dtexcel.Rows)
            //{
            //    if(FileType == "Invoice Detail")
            //    {
            //        entities.FileUploads.Add(new FileUpload
            //        {
            //            CompanyCode = row["Company Code"].ToString(),
            //            DocumentType = row["Document Type"].ToString(),
            //            DocumentNumber = row["Document Number"].ToString(),
            //            BillingDocument = row["Billing Document"].ToString(),
            //            ClearingDocument = row["Clearing Document"].ToString(),
            //            G_LAccount = row["G/L Account"].ToString(),
            //            Assignment = row["Assignment"].ToString(),
            //            TermsofPayment = row["Terms of Payment"].ToString(),
            //            Account = row["Text"].ToString(),
            //            Text = row["Terms of Payment"].ToString(),
            //            Accountname = row["Account name"].ToString(),
            //            Lineitem = row["Line item"].ToString(),
            //            //SpecialG_LInd = row["Special G/L ind."].ToString(),
            //            Documentcurrency = row["Document currency"].ToString(),
            //            LocalCurrency = row["Local Currency"].ToString(),
            //            Amountinlocalcurrency = Convert.ToDouble(row["Amount in local currency"].ToString()),
            //            BaselinePaymentDte = Convert.ToDateTime(row["Baseline Payment Dte"].ToString()),
            //            NetDueDate = Convert.ToDateTime(row["Net due date"].ToString()),
            //            PaymentReference = row["Payment reference"].ToString(),
            //            DocumentHeaderText = row["Document Header Text"].ToString(),
            //            Referencekey3 = row["Reference key 3"].ToString(),
            //            Clearedopenitemssymbol = row["Cleared/open items symbol"].ToString(),
            //            Branchaccount = row["Branch account"].ToString(),
            //            //Alternativeaccountno = row["Alternative account no"].ToString(),
            //            BaseUnitofMeasure = row["Base Unit of Measure"].ToString(),
            //            Reference = row["Reference"].ToString(),
            //            // Clearedopenitemssymbol1 = row["Clearedopenitemssymbol1"].ToString(),
            //            // Discount1duedatesymbol = row["Discount1duedatesymbol"].ToString(),
            //            // Netduedatesymbol = row["Netduedatesymbol"].ToString(),
            //            SalesDocument = row["Sales Document"].ToString(),
            //            Referencekey_1 = row["Reference key 1"].ToString(),
            //            Referencekey_2 = row["Reference key 2"].ToString(),
            //            Invoicereference = row["Invoice reference"].ToString(),
            //            CostCenter = row["Cost Center"].ToString(),
            //            Collectiveinvoice = row["Collective invoice"].ToString(),
            //            PostingKey = row["Posting Key"].ToString(),
            //            //Docstatus = row["Doc.status"].ToString(),
            //            ProfitCenter = row["Profit Center"].ToString(),
            //            FiscalYear = row["Fiscal Year"].ToString(),
            //            Year_month = row["Year/month"].ToString(),
            //            AccountType = row["Account Type"].ToString(),
            //            PostingPeriod = row["Posting Period"].ToString(),
            //            Taxcode = row["Tax code"].ToString(),
            //            SalesDocumentItem = row["Sales Document Item"].ToString(),
            //            // Debit_CreditInd = row["Debit/Credit Ind."].ToString(),
            //            //SpG_LTransType = row["Sp.G/L trans.type"].ToString(),
            //            // PmtMethSupplement = row["Pmt meth. supplement"].ToString(),
            //            TradingPartner = row["Trading Partner"].ToString(),
            //            ContractNumber = row["Contract Number"].ToString(),
            //            ContractType = row["Contract Type"].ToString(),
            //            Plant = row["Plant"].ToString(),
            //            //BillExchangeUsage = row["Bill/Exchange Usage"].ToString(),
            //            PaymentMethod = row["Payment Method"].ToString(),
            //            PaymentBlock = row["Payment Block"].ToString(),
            //            Reasoncode = row["Reason code"].ToString(),
            //            MCARunID = row["MCA Run ID"].ToString(),
            //            //Effexchangerate = row["Eff.exchange rate"].ToString(),
            //            // Follow_ondoctype = row["Follow-on doc.type"].ToString(),
            //            Generalledgercurrency = row["General ledger currency"].ToString(),
            //            DirectDebitPre_notification = row["Direct Debit Pre-notification"].ToString(),
            //            Negativeposting = row["Negative posting"].ToString(),
            //            Fixed = row["Fixed"].ToString(),
            //            Pmntcardlineitem = row["Pmnt card line item"].ToString(),
            //            SettlementRun = row["Settlement run"].ToString(),
            //            CreditControlArea = row["Credit control area"].ToString(),
            //            CreditControlAreaCurrency = row["Credit control area currency"].ToString(),
            //            WBSelement = row["WBS element"].ToString(),
            //            Paymentsent = row["Payment sent"].ToString(),
            //            BusinessPlace = row["Business Place"].ToString(),
            //            SectionCode = row["Section Code"].ToString(),
            //            Pmntcurrency = row["Pmnt currency"].ToString(),
            //            Paymentorder = row["Payment order"].ToString(),
            //            Textsexist = row["Texts exist"].ToString(),
            //            TextID = row["Text ID"].ToString(),
            //            Duenet = row["Due net"].ToString(),
            //            // Cashdisc1due = row["Cash disc.1 due"].ToString(),
            //            ReverseClearing = row["Reverse clearing"].ToString(),
            //            //Acctsrblepledind = row["Accts rble pled.ind."].ToString(),
            //            LineitemID = row["Line item ID"].ToString(),
            //            Asset = row["Asset"].ToString(),
            //            ClearingFiscalYear = row["Clearing Fiscal Year"].ToString(),
            //            Processor = row["Processor"].ToString(),
            //            Status = row["Status"].ToString(),
            //            PurchasingDocument = row["Purchasing Document"].ToString(),
            //            Item = row["Item"].ToString(),
            //            Transaction = row["Transaction"].ToString(),
            //            AssetSubnumber = row["Asset Subnumber"].ToString(),
            //            Order = row["Order"].ToString(),
            //            ScheduleLineNumber = row["Schedule Line Number"].ToString(),
            //            Localcurrency2 = row["Local currency 2"].ToString(),
            //            //OffsettaccountType = row["Offsett.account type"].ToString(),
            //            Localcurrency3 = row["Local currency 3"].ToString(),
            //            BusinessArea = row["Business Area"].ToString(),
            //            DunningArea = row["Dunning Area"].ToString(),
            //            Lastdunned = row["Last dunned"].ToString(),
            //            Dunningblock = row["Dunning block"].ToString(),
            //            Dunninglevel = row["Dunning level"].ToString(),
            //            Dunningkey = row["Dunning key"].ToString(),
            //            // OffsettingAcctNo = row["Offsetting acct no."].ToString(),
            //            // RelatedInvIsCustomer_Disputed = row["Related Inv. Is Customer-Disputed"].ToString(),
            //            FlowType = row["Flow Type"].ToString(),
            //            MandateReference = row["Mandate Reference"].ToString(),
            //            //RefKeyHeader2 = row["Ref.key (header) 2"].ToString(),
            //            DisputedItem = row["Disputed item"].ToString(),
            //            DocumentArchived = row["Document archived"].ToString(),
            //            Instructionkey1 = row["Instruction key 1"].ToString(),
            //            Instructionkey2 = row["Instruction key 2"].ToString(),
            //            Instructionkey3 = row["Instruction key 3"].ToString(),
            //            Instructionkey4 = row["Instruction key 4"].ToString(),
            //            CaseID = row["Case ID"].ToString(),
            //            TextForPriority = row["Text for Priority"].ToString(),
            //            Mandate = row["Mandate"].ToString(),
            //            // NoName = row[" "].ToString(),
            //            Reversedwith = row["Reversed with"].ToString(),
            //            HouseBank = row["House Bank"].ToString(),
            //            Customer = row["Customer"].ToString(),
            //            Vendor = row["Vendor"].ToString(),
            //            CheckNumberFrom = row["Check number from"].ToString(),
            //            ReferenceKey = row["Reference Key"].ToString(),
            //            ParkedBy = row["Parked by"].ToString(),
            //            UserName = row["User name"].ToString(),
            //            Name1 = row["Name 1"].ToString(), 
            //        });
            //        iSucceRows++;
            //    }
            //    else if (FileType == "SO Detail")
            //    {
            //        entities.SO_Detail_Upload.Add(new SO_Detail_Upload
            //        {
            //            Projectdefinitionlevel0 = row["Project definition(level 0)"].ToString(),
            //            SalesOffice = row["Sales Office"].ToString(),
            //           // SalesDocumentNo = row["Sales Document No."].ToString(),
            //            //SalesOrderItemNo = row["Sales Order Item No."].ToString(),
            //            //Material = row["Material"].ToString(),
            //            //MaterialDescription = row["MaterialDescription"].ToString(),
            //            //QuotationNo = row["QuotationNo"].ToString(),
            //            //QuotationItemNo = row["QuotationItemNo"].ToString(),
            //            //Quotationvalidto = row["Quotationvalidto"].ToString(),
            //            //BillingDocumentNo = row["BillingDocumentNo"].ToString(),
            //            //SalesDocumentType = row["SalesDocumentType"].ToString(),
            //            //TextSalesDocumentType = row["TextSalesDocumentType"].ToString(),
            //            //SalesOrganization = row["SalesOrganization"].ToString(),
            //            //TextSalesOrganization = row["TextSalesOrganization"].ToString(),
            //            //DistributionChannel = row["DistributionChannel"].ToString(),
            //            //TextDistributionChannel = row["TextDistributionChannel"].ToString(),
            //            //TextSalesOffice = row["TextSalesOffice"].ToString(),
            //            //TextSalesGroup = row["TextSalesGroup"].ToString(),
            //            //SalesFU = row["SalesFU"].ToString(),
            //            //POnumber = row["POnumber"].ToString(),
            //            //Version = row["Version"].ToString(),
            //            //Orderreason = row["Orderreason"].ToString(),
            //            //TextOrderreason = row["TextOrderreason"].ToString(),
            //            //SDdocumentcurrency = row["SDdocumentcurrency"].ToString(),
            //            //ConditionGroup1 = row["ConditionGroup1"].ToString(),
            //            //TextConditionGroup1 = row["TextConditionGroup1"].ToString(),
            //            //DeliveryBlockStatusH = row["DeliveryBlockStatusH"].ToString(),
            //            //Currency = row["Currency"].ToString(),
            //            //TextDeliveryBlockStatusH = row["TextDeliveryBlockStatusH"].ToString(),
            //            //BillingBlockStatusH = row["BillingBlockStatusH"].ToString(),
            //            //TextBillingBlockStatusH = row["TextBillingBlockStatusH"].ToString(),
            //            //Soldtoparty = row["Soldtoparty"].ToString(),
            //            //NameSoldtoparty = row["NameSoldtoparty"].ToString(),
            //            //Payer = row["Payer"].ToString(),
            //            //NamePayer = row["NamePayer"].ToString(),
            //            //Billtoparty = row["Billtoparty"].ToString(),
            //            //NameBillingtoparty = row["NameBillingtoparty"].ToString(),
            //            //Shiptoparty = row["Shiptoparty"].ToString(),
            //            //NameShiptoparty = row["NameShiptoparty"].ToString(),
            //            //ContactShip = row["ContactShip"].ToString(),
            //            //Name1ContactShip = row["Name1ContactShip"].ToString(),
            //            //Name2ContactShip = row["Name2ContactShip"].ToString(),
            //            //Name3ContactShip = row["Name3ContactShip"].ToString(),
            //            //TELNUMBERContactShip = row["TELNUMBERContactShip"].ToString(),
            //            //ForwardingAgent = row["ForwardingAgent"].ToString(),
            //            //NameForwardingAgent = row["NameForwardingAgent"].ToString(),
            //            //Consignee = row["Consignee"].ToString(),
            //            //NameConsignee = row["NameConsignee"].ToString(),
            //            //EndUser = row["EndUser"].ToString(),
            //            //NameEndUser = row["NameEndUser"].ToString(),
            //            //Soldtoparty2 = row["Soldtoparty2"].ToString(),
            //            //NameSoldtoparty2 = row["NameSoldtoparty2"].ToString(),
            //            //Soldtoparty3 = row["Soldtoparty3"].ToString(),
            //            //NameSoldtoparty3 = row["NameSoldtoparty3"].ToString(),
            //            //SalesPerson = row["SalesPerson"].ToString(),
            //            //NameSalesPerson = row["NameSalesPerson"].ToString(),
            //            //SalesEngineer = row["SalesEngineer"].ToString(),
            //            //NameSalesEngineer = row["NameSalesEngineer"].ToString(),
            //            //ContentsChecker = row["ContentsChecker"].ToString(),
            //            //Handledby = row["Handledby"].ToString(),
            //            //NameHandledby = row["NameHandledby"].ToString(),
            //            //Approver = row["Approver"].ToString(),
            //            //NameApprover = row["NameApprover"].ToString(),
            //            //ApprovalStatusChangedby = row["ApprovalStatusChangedby"].ToString(),
            //            //NameApprovalStatusChangedby = row["NameApprovalStatusChangedby"].ToString(),
            //            //Exporter = row["Exporter"].ToString(),
            //            //NameExporter = row["NameExporter"].ToString(),
            //            //Importer = row["Importer"].ToString(),
            //            //NameImporter = row["NameImporter"].ToString(),
            //            //SDUserStatus = row["SDUserStatus"].ToString(),
            //            //TextSDUserStatus = row["TextSDUserStatus"].ToString(),


            //        }
            //            );
            //        iSucceRows++;
            //    }

            //    else if (FileType == "Coll Detail")
            //    {
            //        entities.CollectionDetails.Add(new CollectionDetail
            //        {
            //            DocumentNumber = row["DocumentNumber"].ToString(),
            //            Lineitem = row["Line item"].ToString(),
            //            PostingDate = Convert.ToDateTime(row["Posting Date"].ToString()),
            //            DocumentDate = Convert.ToDateTime(row["DocumentDate"].ToString()),
            //            DocumentType = row["DocumentType"].ToString(),
            //            PostingKey = row["PostingKey"].ToString(),
            //            Account = row["Account"].ToString(),
            //            Accountname = row["Accountname"].ToString(),
            //            GLAccount = row["GLAccount"].ToString(),
            //            Reference = row["Reference"].ToString(),
            //            Amountindoccurr = float.Parse( row["Amountindoccurr"].ToString()),
            //            Documentcurrency = row["Documentcurrency"].ToString(),
            //            Effexchangerate = row["Effexchangerate"].ToString(),
            //            Amountinlocalcurrency = float.Parse(row["Amountinlocalcurrency"].ToString()),
            //            LocalCurrency = row["LocalCurrency"].ToString(),
            //            BusinessPlace = row["BusinessPlace"].ToString(),
            //            Taxcode = row["Taxcode"].ToString(),
            //            PurchasingDocument = row["PurchasingDocument"].ToString(),
            //            Item = row["Item"].ToString(),
            //            EntryDate = Convert.ToDateTime(row["EntryDate"].ToString()),
            //            FiscalYear = row["FiscalYear"].ToString(),
            //            Invoicereference = row["Invoicereference"].ToString(),
            //            ReferenceKey = row["ReferenceKey"].ToString(),
            //            Wtaxexemptamount = float.Parse(row["Wtaxexemptamount"].ToString()),
            //            Withhldgtaxbaseamount = float.Parse(row["Withhldgtaxbaseamount"].ToString()),
            //            Withholdingtaxamnt = float.Parse(row["Withholdingtaxamnt"].ToString()),
            //            NoName = row["NoName"].ToString(),
            //            AccountType = row["AccountType"].ToString(),
            //            Acctsrblepledind = row["Acctsrblepledind"].ToString(),
            //            Alternativeaccountno = row["Alternativeaccountno"].ToString(),
            //            Amountinloccurr2 = float.Parse(row["Amountinloccurr2"].ToString()),
            //            Amtinloccurr3 = float.Parse(row["Amtinloccurr3"].ToString()),
            //            Amtinpaymentcurrency = float.Parse(row["Amtinpaymentcurrency"].ToString()),
            //            Arrearsafternetduedate = float.Parse(row["Arrearsafternetduedate"].ToString()),
            //            Arrearsfordiscount1 = float.Parse(row["Arrearsfordiscount1"].ToString()),
            //            Asset = row["Asset"].ToString(),
            //            Assignment = row["Assignment"].ToString(),
            //            BaseUnitofMeasure = row["BaseUnitofMeasure"].ToString(),
            //            BaselinePaymentDte = Convert.ToDateTime(row["EntryDate"].ToString()),
            //            BillExchangeUsage = row["BillExchangeUsage"].ToString(),
            //            BillingDocument = row["BillingDocument"].ToString(),
            //            Branchaccount = row["Branchaccount"].ToString(),
            //            BusinessArea = row["BusinessArea"].ToString(),
            //            CaseID = row["CaseID"].ToString(),
            //            CashdiscamtLC = float.Parse(row["CashdiscamtLC"].ToString()),
            //            Cashdisc1due = row["Cashdisc1due"].ToString(),
            //            Checknumberfrom = row["Checknumberfrom"].ToString(),
            //            Clearedopenitemssymbol = row["Clearedopenitemssymbol"].ToString(),
            //            Clearedopenitemssymbol1 = row["Clearedopenitemssymbol1"].ToString(),
            //            Clearingdate = Convert.ToDateTime(row["Clearingdate"].ToString()),
            //            ClearingDocument = row["ClearingDocument"].ToString(),
            //            ClearingFiscalYear = row["ClearingFiscalYear"].ToString(),
            //            Clearingitem = float.Parse(row["Clearingitem"].ToString()),
            //            Collectiveinvoice = row["Collectiveinvoice"].ToString(),
            //            CompanyCode = row["CompanyCode"].ToString(),
            //            ContractNumber = row["ContractNumber"].ToString(),
            //            ContractType = row["ContractType"].ToString(),
            //            CostCenter = row["CostCenter"].ToString(),
            //            Creditcontrolarea = row["Creditcontrolarea"].ToString(),
            //            Creditcontrolareacurrency = row["Creditcontrolareacurrency"].ToString(),
            //            Currentcashdiscamount = float.Parse(row["Currentcashdiscamount"].ToString()),
            //            Customer = row["Customer"].ToString(),
            //            Days1 = float.Parse(row["Days1"].ToString()),
            //            Days2 = float.Parse(row["Days2"].ToString()),
            //            Daysnet = float.Parse(row["Daysnet"].ToString()),
            //            DebitCreditInd = row["DebitCreditInd"].ToString(),
            //            DirectDebitPrenotification = row["DirectDebitPrenotification"].ToString(),
            //            Discount1duedatesymbol = row["Discount1duedatesymbol"].ToString(),
            //            Discountamount = float.Parse(row["Discountamount"].ToString()),
            //            Discountbaseamount = float.Parse(row["Discountbaseamount"].ToString()),
            //            DiscountPercent1 = float.Parse(row["DiscountPercent1"].ToString()),
            //            DiscountPercent2 = float.Parse(row["DiscountPercent2"].ToString()),
            //            Disputeditem = row["Disputeditem"].ToString(),
            //            Docstatus = row["Docstatus"].ToString(),
            //            Documentarchived = row["Documentarchived"].ToString(),
            //            DocumentHeaderText = row["DocumentHeaderText"].ToString(),
            //            Duenet = row["Duenet"].ToString(),
            //            DunningArea = row["DunningArea"].ToString(),
            //            Dunningblock = row["Dunningblock"].ToString(),
            //            Dunningkey = row["Dunningkey"].ToString(),
            //            Dunninglevel = row["Dunninglevel"].ToString(),
            //            Fixed = row["Fixed"].ToString(),
            //            FlowType = row["FlowType"].ToString(),
            //            Followondoctype = row["Followondoctype"].ToString(),
            //            Generalledgeramount = float.Parse(row["Generalledgeramount"].ToString()),
            //            Generalledgercurrency = row["Generalledgercurrency"].ToString(),
            //            Hedgedamount = float.Parse(row["Hedgedamount"].ToString()),
            //            HouseBank = row["HouseBank"].ToString(),
            //            Instructionkey1 = row["Instructionkey1"].ToString(),
            //            Instructionkey2 = row["Instructionkey2"].ToString(),
            //            Instructionkey3 = row["Instructionkey3"].ToString(),
            //            Instructionkey4 = row["Instructionkey4"].ToString(),
            //            Intcalcnumerator = float.Parse(row["Intcalcnumerator"].ToString()),
            //            Lastdunned = row["Lastdunned"].ToString(),
            //            LineitemID = row["LineitemID"].ToString(),
            //            Localcurrency2 = row["Localcurrency2"].ToString(),
            //            Localcurrency3 = row["Localcurrency3"].ToString(),
            //            Mandate = row["Mandate"].ToString(),
            //            MandateReference = row["MandateReference"].ToString(),
            //            MCARunID = row["MCARunID"].ToString(),
            //            Name1 = row["Name1"].ToString(),
            //            Negativeposting = row["Negativeposting"].ToString(),
            //            Netduedate = Convert.ToDateTime(row["Netduedate"].ToString()),
            //            Pmntcardlineitem = row["Pmntcardlineitem"].ToString(),
            //            Offsettaccounttype = row["Offsettaccounttype"].ToString(),
            //            Offsettingacctno = row["Offsettingacctno"].ToString(),
            //            PaymentBlock = row["PaymentBlock"].ToString(),
            //            Paymentdate = Convert.ToDateTime(row["Paymentdate"].ToString()),
            //            PaymentMethod = row["PaymentMethod"].ToString(),
            //            Paymentorder = row["Paymentorder"].ToString(),
            //            Paymentreference = row["Paymentreference"].ToString(),
            //            Paymentsent = row["Paymentsent"].ToString(),
            //            Plant = row["Plant"].ToString(),
            //            Pmntcurrency = row["Pmntcurrency"].ToString(),
            //            Pmtmethsupplement = row["Pmtmethsupplement"].ToString(),
            //            PostingPeriod = row["PostingPeriod"].ToString(),
            //            Processor = row["Processor"].ToString(),
            //            ProfitCenter = row["ProfitCenter"].ToString(),
            //            Quantity = float.Parse(row["Quantity"].ToString()),
            //            Reasoncode = row["Reasoncode"].ToString(),
            //            Refkeyheader2 = row["Refkeyheader2"].ToString(),
            //            Referencekey1 = row["Referencekey1"].ToString(),
            //            Referencekey2 = row["Referencekey2"].ToString(),
            //            Referencekey3 = row["Referencekey3"].ToString(),
            //            RelatedInvIsCustomerDisputed = row["RelatedInvIsCustomerDisputed"].ToString(),
            //            Reverseclearing = row["Reverseclearing"].ToString(),
            //            Reversedwith = row["Reversedwith"].ToString(),
            //            SalesDocument = row["SalesDocument"].ToString(),
            //            SalesDocumentItem = row["SalesDocumentItem"].ToString(),
            //            ScheduleLineNumber = row["ScheduleLineNumber"].ToString(),
            //            SectionCode = row["SectionCode"].ToString(),
            //            Settlementrun = row["Settlementrun"].ToString(),
            //            SpGLtranstype = row["SpGLtranstype"].ToString(),
            //            SpecialGLind = row["SpecialGLind"].ToString(),
            //            Status = row["Status"].ToString(),
            //            Subnumber = row["Subnumber"].ToString(),
            //            TermsofPayment = row["TermsofPayment"].ToString(),
            //            Text = row["Text"].ToString(),
            //            Sortkey = float.Parse(row["Sortkey"].ToString()),
            //            TextID = row["TextID"].ToString(),
            //            TextforPriority = row["TextforPriority"].ToString(),
            //            Textsexist = row["Textsexist"].ToString(),
            //            TimeofEntry = float.Parse(row["TimeofEntry"].ToString()),
            //            TradingPartner = row["TradingPartner"].ToString(),
            //            //Transaction = row["TradingPartner"].ToString(),
            //            Username = row["Username"].ToString(),
            //            Valuatedamount = float.Parse(row["Valuatedamount"].ToString()),
            //            Valuatedamtloccurr3 = float.Parse(row["Valuatedamtloccurr3"].ToString()),
            //            Valuatedamtloccurr2 = float.Parse(row["Valuatedamtloccurr2"].ToString()),
            //            Valuedate = Convert.ToDateTime(row["Valuedate"].ToString()),
            //            Vendor = row["Username"].ToString(),
            //            WBSelement = row["WBSelement"].ToString(),
            //            Yearmonth = row["Yearmonth"].ToString(),




            //        }
            //            );
            //        iSucceRows++;
            //    }
            //}
            entities.SaveChanges();

            int succRecs = iSucceRows;
            res = succRecs;
            var data = entities.ARR_UploadHistory.Where(x => x.FileNo == fileno).FirstOrDefault();
            if (data != null)
            {
                data.SuccessRecords = succRecs;
                entities.SaveChanges();
            }
            return dtexcel;

        }

        [HttpGet]
        [Route("api/uploadHistory")]
        public ARR_UploadHistory[] uploadHistory()
        {
            DataSet Ds = new DataSet();
            List<ARR_UploadHistory> uploadHistoryList = new List<ARR_UploadHistory>();

            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Flag", 1);
            Ds = _iFileUploadManager.GetUploadHistory("Upload_History", Param, "Upload_History");
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    uploadHistoryList = Ds.Tables[0].AsEnumerable().Select(x => new ARR_UploadHistory
                    {
                        FileNo = x["FileNo"] != DBNull.Value ? Convert.ToInt32(x["FileNo"].ToString()) : 0,
                        FilePath = x["FilePath"] != DBNull.Value ? x["FilePath"].ToString() : "",
                        FileName = x["FileName"] != DBNull.Value ? x["FileName"].ToString() : "",
                        SuccessRecords = x["SuccessRecords"] != DBNull.Value ? Convert.ToInt32(x["SuccessRecords"].ToString()) : 0,
                        FailedRecords = x["FailedRecords"] != DBNull.Value ? Convert.ToInt32(x["FailedRecords"].ToString()) : 0,
                        Status = x["Status"] != DBNull.Value ? x["Status"].ToString() : "",
                        // System_Date = Convert.ToDateTime(x["System_Date"] != DBNull.Value ? x["System_Date"].ToString() : ""),
                        //System_Date = x["System_Date"] != DBNull.Value ? Convert.ToDateTime(x["System_Date"].ToString():""),
                        Uploaded_By = x["Uploaded By"] != DBNull.Value ? x["Uploaded By"].ToString() : "",

                    }).ToList();

                }
            }
            Ds.Dispose();
            return uploadHistoryList.ToArray();
        }


        [HttpGet]
        [Route("api/GetAllUploadHistory")]
        public async Task<List<ARUploadHistoryViewModel>> GetAllUploadHistory()
        {
            var listUploadHistory = await _iFileUploadManager.GetAllUploadHistory();
            var result = listUploadHistory
                .Select(h => new ARUploadHistoryViewModel
                {
                    FileNo = h.FileNo,
                    FilePath = h.FilePath,
                    FileName = h.FileName,
                    SuccessRecords = h.SuccessRecords,
                    FailedRecords = h.FailedRecords,
                    System_Date = string.Format("{0:yyyy-MM-dd hh:mm tt}", h.System_Date),
                    Uploaded_By = h.Uploaded_By,


                }).ToList();
            return result;
        }




        [HttpPost]
        [Route("api/AddUploadHistory")]
        public static bool UpdateUploadHistory(string filePath, string FileName, string fileType)

        {
            Logisticks1Entities entities = new Logisticks1Entities();
            bool status;
            try
            {
                ARR_UploadHistory upload = new ARR_UploadHistory();
                upload.FileName = FileName;
                upload.FilePath = filePath;
                upload.System_Date = DateTime.Now;
                upload.Uploaded_By = "Akhil Reddy";
                upload.FileType = fileType;
                //upload.SuccessRecords = SuccessRecords;
                upload.DelFlag = true;
                //entities.ARR_UploadHistory.Add(new ARR_UploadHistory
                //{
                //    FileName = FileName,
                //    FilePath = filePath,
                //    System_Date = DateTime.Now,
                //    Uploaded_By = "Priti",
                //    FileType = fileType,
                //    SuccessRecords = SuccessRecords,
                //    DelFlag = true
                //});
                entities.ARR_UploadHistory.Add(upload);
                entities.SaveChanges();
                fileno = upload.FileNo;
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                // status = false;
            }
            return status;
        }


        [HttpPost]
        [Route("api/modifyHistory")]
        public void modifyHistory(int fileNo)

        {
            Logisticks1Entities entities = new Logisticks1Entities();

            try
            {
                var result = entities.ARR_UploadHistory.FirstOrDefault(e => e.FileNo == fileNo);
                {

                    result.DelFlag = false;
                }
                entities.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
                // status = false;
            }

        }
        [HttpPost]
        [Route("api/RemoveFileByFileNo")]
        public async Task<ARR_UploadHistory> RemoveFileByFileNo(int fileno)
        {
            ARR_UploadHistory file = new ARR_UploadHistory();
            Logisticks1Entities entity = new Logisticks1Entities();
            try
            {
                var data = entity.ARR_UploadHistory.Where(x => x.FileNo == fileno).FirstOrDefault();
                if (data != null)
                    data.DelFlag = true;

                var data1 = entity.ARR_Master.Where(x => x.Fileno == fileno).ToList();
                entity.ARR_Master.RemoveRange(data1);
                entity.SaveChanges();
                return file;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/DeleteFileByFileNo")]
        public async Task<int> DeleteFileByFileNo(int fileno)
        {
            int id = 0;
            id = await _iFileUploadManager.DeleteFileByFileNo(fileno);
            return id;
        }
        private static string ToValidFileName(string fileName)
        {
            fileName = fileName.ToLower().Replace(" ", "_").Replace("(", "_").Replace(")", "_").Replace("&", "_").Replace("*", "_").Replace("-", "_").Replace("+", "_");
            return string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
