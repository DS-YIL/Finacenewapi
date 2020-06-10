using System;
using DAL;
using System.DirectoryServices;

using System.DirectoryServices.AccountManagement;

namespace ARReportWebApi.Models
{
    public class LoginModel
    {
        private string sqlQry;    
  
        public bool ValidateUserLoginDetails(string userName,string password,out int iUserID)
        {
            sqlQry = "";
            bool loginFlag = false;
            try
            {
                sqlQry = "SELECT COUNT(1) FROM UserDetails";
                sqlQry = sqlQry + " " + "WHERE [Login Name]='" + userName + "' AND [usr_Password]='" + password + " ' AND DeleteFlag<>'D'";
                sqlQry = sqlQry + " " + "COLLATE SQL_Latin1_General_CP1_CS_AS";

                Object objQty = SqlHelper.SqlExecuteScalar(sqlQry);
                if (objQty != null && DBNull.Value != objQty)
                {
                    if (Convert.ToInt32(objQty) == 1)
                    {
                        loginFlag = true;
                    }
                   
                }
                iUserID = GetUserID(userName);

                return loginFlag;

            }
            catch
            {
                throw;
            }

        }


        // For ActiveDirectory
        public bool ValidateUserCredentialsAgainstAD(string loginName, string password, out int iUserID,out string userName,out bool roleType)
        {
            bool loginFlag = false;
            userName = "";
            iUserID = 0;
            roleType = false;
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, loginName.Trim());
                if (user != null)
                {
                    userName = user.GivenName + " " + user.Surname;
                    iUserID = GetADUserID(loginName);
                    roleType = GetRoleType(loginName);

                    //loginFlag = ctx.ValidateCredentials(loginName, password);
                    if (ctx.ValidateCredentials(loginName, password) && CheckUserActive(iUserID))
                    {
                        loginFlag = true;
                    }
                }
               
                return loginFlag;
            }
            catch { throw; }
        }

        private int GetADUserID(string userName)
        {
            sqlQry = "";
            int usrID = 0;
            try
            {
                sqlQry = "SELECT EmpID FROM ARR_User_Details WHERE LoginID='" + userName + "'";
             
                Object objUserID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objUserID != null && DBNull.Value != objUserID)
                {
                    usrID = Convert.ToInt32(objUserID);

                }
                return usrID;
            }
            catch
            {
                throw;

            }
        }

        private bool GetRoleType(string userName)
        {
            sqlQry = "";
            bool roletype = false;
            try
            {
                sqlQry = "SELECT AdminDashboardAccess FROM ARR_User_Details WHERE LoginID='" + userName + "'";

                Object objActive = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objActive != null && DBNull.Value != objActive)
                {
                    if (Convert.ToInt32(objActive) == 1)
                    {
                        roletype = true;
                    }

                }
                return roletype;
            }
            catch
            {
                throw;

            }
        }
        private int GetUserID(string userName)
        {
            sqlQry = "";
            int usrID = 0;
            try
            {
                sqlQry = "SELECT UserID FROM ARR_User_Details";
                sqlQry = sqlQry + " " + "WHERE [LoginID]='" + userName + "' AND DeleteFlag<>'D'";   
                sqlQry = sqlQry + " " + "COLLATE SQL_Latin1_General_CP1_CS_AS";

                Object objUserID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objUserID != null && DBNull.Value != objUserID)
                {
                    usrID = Convert.ToInt32(objUserID);

                }
                return usrID;
            }
            catch
            {
                throw;

            }
        }

        private bool CheckUserActive(int empID)
        {
            sqlQry = "";
            bool active = false;

            try
            {
                sqlQry = "SELECT COUNt(*) FROM ARR_User_Details WHERE IsActive=1 AND DeleteFlag<>'D' AND EmpID=" + empID;


                Object objActive = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objActive != null && DBNull.Value != objActive)
                {
                    if (Convert.ToInt32(objActive) == 1)
                    {
                        active = true;
                    }

                }
                return active;

            }
            catch { throw; }
        }

        #region  For Dublicate Login

        public bool ValidateUserCredentialsForDublicate(string loginName, string password, out int iUserID, out string userName)
        {
            bool loginFlag = false;
            userName = "";
            iUserID = 0;
            try
            {
                sqlQry = "SELECT COUNT(1) FROM ARR_User_Details";
                sqlQry = sqlQry + " " + "WHERE [LoginID] like '" + loginName.Trim() + "%' AND [EmpID]='" + password + "'";
                sqlQry = sqlQry + " " + "COLLATE SQL_Latin1_General_CP1_CS_AS";

                Object objQty = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objQty != null && DBNull.Value != objQty)
                {
                    if (Convert.ToInt32(objQty) == 1)
                    {
                        loginFlag = true;
                    }

                }

                iUserID = GetADUserID(loginName);
                userName = GetADUserName(loginName);

                //PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, loginName);
                //if (user != null)
                //{
                //    userName = user.GivenName + " " + user.Surname;
                //    loginFlag = ctx.ValidateCredentials(loginName, password);
                //    iUserID = GetADUserID(loginName);
                //}

                return loginFlag;
            }
            catch { throw; }
        }

        private string GetADUserName(string loginName)
        {
            sqlQry = "";
            string userName = "";
            try
            {
                sqlQry = "SELECT EmpName FROM User_Details WHERE LoginID='" + loginName + "'";

                Object objUserID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objUserID != null && DBNull.Value != objUserID)
                {
                    userName = Convert.ToString(objUserID);

                }
                return userName;
            }
            catch
            {
                throw;

            }
        }
        #endregion

        //public bool CheckUserLoginName(string loginName)
        //{
        //    sqlQry = "";
        //    bool existsFlag = false;
        //    try
        //    {
        //        sqlQry = "SELECT COUNT(1) FROM UserDetails";
        //        sqlQry = sqlQry + " " + "WHERE [USER_NAME]='" + loginName + "'";
        //        sqlQry = sqlQry + " " + "COLLATE SQL_Latin1_General_CP1_CS_AS";

        //        Object objQty = SqlHelper.SqlExecuteScalar(sqlQry);
        //        if (objQty != null && DBNull.Value != objQty)
        //        {
        //            if (Convert.ToInt32(objQty) == 1)
        //            {
        //                existsFlag = true;
        //            }

        //        }
        //        return existsFlag;

        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}

    }
}