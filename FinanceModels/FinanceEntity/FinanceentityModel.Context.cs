﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Logisticks1Entities : DbContext
    {
        public Logisticks1Entities()
            : base("name=Logisticks1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessRoleItem> AccessRoleItems { get; set; }
        public virtual DbSet<AccessRole> AccessRoles { get; set; }
        public virtual DbSet<ARDetail> ARDetails { get; set; }
        public virtual DbSet<ARR_ErrorLog> ARR_ErrorLog { get; set; }
        public virtual DbSet<ARR_Master> ARR_Master { get; set; }
        public virtual DbSet<ARR_MonthCollectionTarget> ARR_MonthCollectionTarget { get; set; }
        public virtual DbSet<ARR_UploadHistory> ARR_UploadHistory { get; set; }
        public virtual DbSet<ARR_User_Details> ARR_User_Details { get; set; }
        public virtual DbSet<CollectionDetail> CollectionDetails { get; set; }
        public virtual DbSet<CustMaster> CustMasters { get; set; }
        public virtual DbSet<FileUpload> FileUploads { get; set; }
        public virtual DbSet<GroupDetail> GroupDetails { get; set; }
        public virtual DbSet<NEWDEPENTRY> NEWDEPENTRies { get; set; }
        public virtual DbSet<NEWDEPMAIN> NEWDEPMAINs { get; set; }
        public virtual DbSet<NewMenu> NewMenus { get; set; }
        public virtual DbSet<SO_Detail_Upload> SO_Detail_Upload { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User_Details> User_Details { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<AgingOrder> AgingOrders { get; set; }
        public virtual DbSet<ARR_MonthlyCollection> ARR_MonthlyCollection { get; set; }
        public virtual DbSet<ARR_MonthlyCollectionTracking> ARR_MonthlyCollectionTracking { get; set; }
        public virtual DbSet<ARR_Remarks> ARR_Remarks { get; set; }
        public virtual DbSet<ARR_UserDescr> ARR_UserDescr { get; set; }
        public virtual DbSet<BankMaster> BankMasters { get; set; }
        public virtual DbSet<DsoMaster> DsoMasters { get; set; }
        public virtual DbSet<excel> excels { get; set; }
        public virtual DbSet<RegMaster> RegMasters { get; set; }
        public virtual DbSet<UploadHistory> UploadHistories { get; set; }
        public virtual DbSet<arrbureport> arrbureports { get; set; }
        public virtual DbSet<Collection_View> Collection_View { get; set; }
        public virtual DbSet<sampleview> sampleviews { get; set; }
    
        [DbFunction("Logisticks1Entities", "GetTokenizeValue")]
        public virtual IQueryable<GetTokenizeValue_Result> GetTokenizeValue(string strCSVString)
        {
            var strCSVStringParameter = strCSVString != null ?
                new ObjectParameter("strCSVString", strCSVString) :
                new ObjectParameter("strCSVString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetTokenizeValue_Result>("[Logisticks1Entities].[GetTokenizeValue](@strCSVString)", strCSVStringParameter);
        }
    
        [DbFunction("Logisticks1Entities", "splitstring")]
        public virtual IQueryable<splitstring_Result> splitstring(string stringToSplit)
        {
            var stringToSplitParameter = stringToSplit != null ?
                new ObjectParameter("stringToSplit", stringToSplit) :
                new ObjectParameter("stringToSplit", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<splitstring_Result>("[Logisticks1Entities].[splitstring](@stringToSplit)", stringToSplitParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int Sp_ARRGenerateSummaryReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_ARRGenerateSummaryReport");
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<SP_GetMenuData_Result> SP_GetMenuData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetMenuData_Result>("SP_GetMenuData");
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<System.Guid>> SqlQueryNotificationStoredProcedure_0c0fc1cf_2cf9_4ed8_8f41_873133382495()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("SqlQueryNotificationStoredProcedure_0c0fc1cf_2cf9_4ed8_8f41_873133382495");
        }
    
        public virtual ObjectResult<Upload_History_Result> Upload_History(Nullable<int> flag)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Upload_History_Result>("Upload_History", flagParameter);
        }
    
        public virtual ObjectResult<USP_AdminDashboard_Result> USP_AdminDashboard(Nullable<int> flag)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_AdminDashboard_Result>("USP_AdminDashboard", flagParameter);
        }
    
        public virtual int USP_AdminDashboard_V2(Nullable<int> flag, Nullable<int> month, Nullable<int> year, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_AdminDashboard_V2", flagParameter, monthParameter, yearParameter, fromDateParameter, toDateParameter);
        }
    
        public virtual int USP_AdminDashboard_V3(Nullable<int> flag)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_AdminDashboard_V3", flagParameter);
        }
    
        public virtual int USP_Aging(Nullable<int> flag, Nullable<int> employeeNo, string division, string region, Nullable<int> month, Nullable<int> year, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, string gDivision, string gRegion)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var employeeNoParameter = employeeNo.HasValue ?
                new ObjectParameter("EmployeeNo", employeeNo) :
                new ObjectParameter("EmployeeNo", typeof(int));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            var gDivisionParameter = gDivision != null ?
                new ObjectParameter("GDivision", gDivision) :
                new ObjectParameter("GDivision", typeof(string));
    
            var gRegionParameter = gRegion != null ?
                new ObjectParameter("GRegion", gRegion) :
                new ObjectParameter("GRegion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_Aging", flagParameter, employeeNoParameter, divisionParameter, regionParameter, monthParameter, yearParameter, fromDateParameter, toDateParameter, gDivisionParameter, gRegionParameter);
        }
    
        public virtual int USP_ARDetail(Nullable<int> flag)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_ARDetail", flagParameter);
        }
    
        public virtual int USP_ARR_ErrorLog(Nullable<int> flag, Nullable<int> logID, string pageName, string methodName, string errorMessage, string innerException, string stackTrace, string sessionUser)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var logIDParameter = logID.HasValue ?
                new ObjectParameter("LogID", logID) :
                new ObjectParameter("LogID", typeof(int));
    
            var pageNameParameter = pageName != null ?
                new ObjectParameter("PageName", pageName) :
                new ObjectParameter("PageName", typeof(string));
    
            var methodNameParameter = methodName != null ?
                new ObjectParameter("MethodName", methodName) :
                new ObjectParameter("MethodName", typeof(string));
    
            var errorMessageParameter = errorMessage != null ?
                new ObjectParameter("ErrorMessage", errorMessage) :
                new ObjectParameter("ErrorMessage", typeof(string));
    
            var innerExceptionParameter = innerException != null ?
                new ObjectParameter("InnerException", innerException) :
                new ObjectParameter("InnerException", typeof(string));
    
            var stackTraceParameter = stackTrace != null ?
                new ObjectParameter("StackTrace", stackTrace) :
                new ObjectParameter("StackTrace", typeof(string));
    
            var sessionUserParameter = sessionUser != null ?
                new ObjectParameter("SessionUser", sessionUser) :
                new ObjectParameter("SessionUser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_ARR_ErrorLog", flagParameter, logIDParameter, pageNameParameter, methodNameParameter, errorMessageParameter, innerExceptionParameter, stackTraceParameter, sessionUserParameter);
        }
    
        public virtual ObjectResult<USP_ARR_Master_Result> USP_ARR_Master(Nullable<int> flag, string customerName, string customerCode, string region, string division, string invoiceNo, string regionS, string divisionS, string projectManager, Nullable<int> projectManagerID, string month, string year, Nullable<int> employeeno)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var customerCodeParameter = customerCode != null ?
                new ObjectParameter("CustomerCode", customerCode) :
                new ObjectParameter("CustomerCode", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            var regionSParameter = regionS != null ?
                new ObjectParameter("RegionS", regionS) :
                new ObjectParameter("RegionS", typeof(string));
    
            var divisionSParameter = divisionS != null ?
                new ObjectParameter("DivisionS", divisionS) :
                new ObjectParameter("DivisionS", typeof(string));
    
            var projectManagerParameter = projectManager != null ?
                new ObjectParameter("ProjectManager", projectManager) :
                new ObjectParameter("ProjectManager", typeof(string));
    
            var projectManagerIDParameter = projectManagerID.HasValue ?
                new ObjectParameter("ProjectManagerID", projectManagerID) :
                new ObjectParameter("ProjectManagerID", typeof(int));
    
            var monthParameter = month != null ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(string));
    
            var yearParameter = year != null ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(string));
    
            var employeenoParameter = employeeno.HasValue ?
                new ObjectParameter("Employeeno", employeeno) :
                new ObjectParameter("Employeeno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_ARR_Master_Result>("USP_ARR_Master", flagParameter, customerNameParameter, customerCodeParameter, regionParameter, divisionParameter, invoiceNoParameter, regionSParameter, divisionSParameter, projectManagerParameter, projectManagerIDParameter, monthParameter, yearParameter, employeenoParameter);
        }
    
        public virtual ObjectResult<Usp_Dsodivisiondata_Result> Usp_Dsodivisiondata(string region)
        {
            var regionParameter = region != null ?
                new ObjectParameter("region", region) :
                new ObjectParameter("region", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Usp_Dsodivisiondata_Result>("Usp_Dsodivisiondata", regionParameter);
        }
    
        public virtual int USP_Dsoregiondata(string division)
        {
            var divisionParameter = division != null ?
                new ObjectParameter("division", division) :
                new ObjectParameter("division", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_Dsoregiondata", divisionParameter);
        }
    
        public virtual ObjectResult<USP_FileUpload_Result> USP_FileUpload(Nullable<int> flag, string customerName, string customerCode, string region, string division, string invoiceNo, string regionS, string divisionS, string projectManager, Nullable<int> projectManagerID, string month, string year)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var customerCodeParameter = customerCode != null ?
                new ObjectParameter("CustomerCode", customerCode) :
                new ObjectParameter("CustomerCode", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            var regionSParameter = regionS != null ?
                new ObjectParameter("RegionS", regionS) :
                new ObjectParameter("RegionS", typeof(string));
    
            var divisionSParameter = divisionS != null ?
                new ObjectParameter("DivisionS", divisionS) :
                new ObjectParameter("DivisionS", typeof(string));
    
            var projectManagerParameter = projectManager != null ?
                new ObjectParameter("ProjectManager", projectManager) :
                new ObjectParameter("ProjectManager", typeof(string));
    
            var projectManagerIDParameter = projectManagerID.HasValue ?
                new ObjectParameter("ProjectManagerID", projectManagerID) :
                new ObjectParameter("ProjectManagerID", typeof(int));
    
            var monthParameter = month != null ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(string));
    
            var yearParameter = year != null ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_FileUpload_Result>("USP_FileUpload", flagParameter, customerNameParameter, customerCodeParameter, regionParameter, divisionParameter, invoiceNoParameter, regionSParameter, divisionSParameter, projectManagerParameter, projectManagerIDParameter, monthParameter, yearParameter);
        }
    
        public virtual int USP_GenerateReport(Nullable<int> flag, string customerName, string customerCode, string region, string division, string invoiceNo, string regionS, string divisionS, string projectManager, Nullable<int> projectManagerID, string month, string year, string selectedValue, string txtSaleOrderNo, string txtDocNo, string txtInvoiceNo, string txtCustpono, string txtProjectId, string txtCustomerCode, string agingCritria)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var customerCodeParameter = customerCode != null ?
                new ObjectParameter("CustomerCode", customerCode) :
                new ObjectParameter("CustomerCode", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            var regionSParameter = regionS != null ?
                new ObjectParameter("RegionS", regionS) :
                new ObjectParameter("RegionS", typeof(string));
    
            var divisionSParameter = divisionS != null ?
                new ObjectParameter("DivisionS", divisionS) :
                new ObjectParameter("DivisionS", typeof(string));
    
            var projectManagerParameter = projectManager != null ?
                new ObjectParameter("ProjectManager", projectManager) :
                new ObjectParameter("ProjectManager", typeof(string));
    
            var projectManagerIDParameter = projectManagerID.HasValue ?
                new ObjectParameter("ProjectManagerID", projectManagerID) :
                new ObjectParameter("ProjectManagerID", typeof(int));
    
            var monthParameter = month != null ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(string));
    
            var yearParameter = year != null ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(string));
    
            var selectedValueParameter = selectedValue != null ?
                new ObjectParameter("SelectedValue", selectedValue) :
                new ObjectParameter("SelectedValue", typeof(string));
    
            var txtSaleOrderNoParameter = txtSaleOrderNo != null ?
                new ObjectParameter("txtSaleOrderNo", txtSaleOrderNo) :
                new ObjectParameter("txtSaleOrderNo", typeof(string));
    
            var txtDocNoParameter = txtDocNo != null ?
                new ObjectParameter("txtDocNo", txtDocNo) :
                new ObjectParameter("txtDocNo", typeof(string));
    
            var txtInvoiceNoParameter = txtInvoiceNo != null ?
                new ObjectParameter("txtInvoiceNo", txtInvoiceNo) :
                new ObjectParameter("txtInvoiceNo", typeof(string));
    
            var txtCustponoParameter = txtCustpono != null ?
                new ObjectParameter("txtCustpono", txtCustpono) :
                new ObjectParameter("txtCustpono", typeof(string));
    
            var txtProjectIdParameter = txtProjectId != null ?
                new ObjectParameter("txtProjectId", txtProjectId) :
                new ObjectParameter("txtProjectId", typeof(string));
    
            var txtCustomerCodeParameter = txtCustomerCode != null ?
                new ObjectParameter("txtCustomerCode", txtCustomerCode) :
                new ObjectParameter("txtCustomerCode", typeof(string));
    
            var agingCritriaParameter = agingCritria != null ?
                new ObjectParameter("AgingCritria", agingCritria) :
                new ObjectParameter("AgingCritria", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_GenerateReport", flagParameter, customerNameParameter, customerCodeParameter, regionParameter, divisionParameter, invoiceNoParameter, regionSParameter, divisionSParameter, projectManagerParameter, projectManagerIDParameter, monthParameter, yearParameter, selectedValueParameter, txtSaleOrderNoParameter, txtDocNoParameter, txtInvoiceNoParameter, txtCustponoParameter, txtProjectIdParameter, txtCustomerCodeParameter, agingCritriaParameter);
        }
    
        public virtual ObjectResult<string> USP_GetRegionDivisionPmCustomerName(Nullable<int> flag, Nullable<int> employeeno, Nullable<int> empID)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var employeenoParameter = employeeno.HasValue ?
                new ObjectParameter("Employeeno", employeeno) :
                new ObjectParameter("Employeeno", typeof(int));
    
            var empIDParameter = empID.HasValue ?
                new ObjectParameter("EmpID", empID) :
                new ObjectParameter("EmpID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_GetRegionDivisionPmCustomerName", flagParameter, employeenoParameter, empIDParameter);
        }
    
        public virtual int USP_LastOneYearCollection(Nullable<int> flag, string dEPOSITDATE, Nullable<int> employeeNo)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var dEPOSITDATEParameter = dEPOSITDATE != null ?
                new ObjectParameter("DEPOSITDATE", dEPOSITDATE) :
                new ObjectParameter("DEPOSITDATE", typeof(string));
    
            var employeeNoParameter = employeeNo.HasValue ?
                new ObjectParameter("EmployeeNo", employeeNo) :
                new ObjectParameter("EmployeeNo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_LastOneYearCollection", flagParameter, dEPOSITDATEParameter, employeeNoParameter);
        }
    
        public virtual ObjectResult<USP_LastSixMonthCollection_Result> USP_LastSixMonthCollection(Nullable<int> flag)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_LastSixMonthCollection_Result>("USP_LastSixMonthCollection", flagParameter);
        }
    
        public virtual ObjectResult<USP_LastSixMonthCollection_V2_Result> USP_LastSixMonthCollection_V2(Nullable<int> flag, Nullable<int> employeeNo, string division, string region, Nullable<int> month, Nullable<int> year, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, string gDivision, string gRegion, Nullable<int> selectedMonth, Nullable<System.DateTime> lastSixMonthDate)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var employeeNoParameter = employeeNo.HasValue ?
                new ObjectParameter("EmployeeNo", employeeNo) :
                new ObjectParameter("EmployeeNo", typeof(int));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            var gDivisionParameter = gDivision != null ?
                new ObjectParameter("GDivision", gDivision) :
                new ObjectParameter("GDivision", typeof(string));
    
            var gRegionParameter = gRegion != null ?
                new ObjectParameter("GRegion", gRegion) :
                new ObjectParameter("GRegion", typeof(string));
    
            var selectedMonthParameter = selectedMonth.HasValue ?
                new ObjectParameter("SelectedMonth", selectedMonth) :
                new ObjectParameter("SelectedMonth", typeof(int));
    
            var lastSixMonthDateParameter = lastSixMonthDate.HasValue ?
                new ObjectParameter("LastSixMonthDate", lastSixMonthDate) :
                new ObjectParameter("LastSixMonthDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_LastSixMonthCollection_V2_Result>("USP_LastSixMonthCollection_V2", flagParameter, employeeNoParameter, divisionParameter, regionParameter, monthParameter, yearParameter, fromDateParameter, toDateParameter, gDivisionParameter, gRegionParameter, selectedMonthParameter, lastSixMonthDateParameter);
        }
    
        public virtual ObjectResult<USP_Menu_Result> USP_Menu(Nullable<int> flag)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_Menu_Result>("USP_Menu", flagParameter);
        }
    
        public virtual ObjectResult<USP_MonthlyCashIn_Result> USP_MonthlyCashIn(Nullable<int> flag, string division, string month, string year)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var monthParameter = month != null ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(string));
    
            var yearParameter = year != null ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_MonthlyCashIn_Result>("USP_MonthlyCashIn", flagParameter, divisionParameter, monthParameter, yearParameter);
        }
    
        public virtual int USP_PieChart(Nullable<int> flag, string division, string month, string year, string fromDate, string toDate, string type)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var monthParameter = month != null ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(string));
    
            var yearParameter = year != null ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(string));
    
            var fromDateParameter = fromDate != null ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(string));
    
            var toDateParameter = toDate != null ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_PieChart", flagParameter, divisionParameter, monthParameter, yearParameter, fromDateParameter, toDateParameter, typeParameter);
        }
    
        public virtual int USP_PieChart_V2(Nullable<int> flag, string division, string month, string year, string fromDate, string toDate, string type)
        {
            var flagParameter = flag.HasValue ?
                new ObjectParameter("Flag", flag) :
                new ObjectParameter("Flag", typeof(int));
    
            var divisionParameter = division != null ?
                new ObjectParameter("Division", division) :
                new ObjectParameter("Division", typeof(string));
    
            var monthParameter = month != null ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(string));
    
            var yearParameter = year != null ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(string));
    
            var fromDateParameter = fromDate != null ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(string));
    
            var toDateParameter = toDate != null ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_PieChart_V2", flagParameter, divisionParameter, monthParameter, yearParameter, fromDateParameter, toDateParameter, typeParameter);
        }
    }
}
