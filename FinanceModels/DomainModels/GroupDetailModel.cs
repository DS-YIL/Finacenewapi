using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;

namespace ARReportWebApi.Models
{
    public class GroupDetailModel
    {
        private string sqlQry = "";
        //DataTable dtValues = new DataTable();
        bool saveFlag = false;

        public bool CheckGroupName(string groupName)
        {
            sqlQry = "";
            bool existsFlag = false;
            try
            {
                sqlQry = "SELECT COUNT(1) FROM [GroupDetails]";
                sqlQry = sqlQry + " " + "WHERE [Group Name]='" + groupName + "'";
                //sqlQry = sqlQry + " " + "COLLATE SQL_Latin1_General_CP1_CS_AS";

                Object objQty = SqlHelper.SqlExecuteScalar(sqlQry);
                if (objQty != null && DBNull.Value != objQty)
                {
                    if (Convert.ToInt32(objQty) == 1)
                    {
                        existsFlag = true;
                    }

                }
                return existsFlag;

            }
            catch
            {
                throw;
            }

        }


        public DataTable GetGroupDetailsByName(string groupName)
        {
            sqlQry = "";
            DataTable dtGroups = new DataTable();

            try
            {

                sqlQry = @"SELECT GroupID ,[Group Name] AS GroupName,[Group Description] AS GrpDesc FROM [GroupDetails]";

                sqlQry = sqlQry + " " + "WHERE [Group Name] LIKE '%" + groupName + "%' AND DeleteFlag<>'D'";
                dtGroups = SqlHelper.SqlExecuteDataTable(sqlQry);
                return dtGroups;

            }
            catch { throw; }
        }



        public bool CreateGroup(List<GroupModel> lstGroupModel)
        {
            sqlQry = "";
            int iRoleID = 0;
            try
            {
                foreach (var GroupItem in lstGroupModel)
                {

                    iRoleID = CreateRolesForGroups(GroupItem.RoleItemIDs);

                    sqlQry = "INSERT INTO [dbo].[GroupDetails]";
                    sqlQry = sqlQry + " " + "([GroupID] ,[Group Name],[Group Description],[RoleID],CreatedDate,CreatedBy)";
                    sqlQry = sqlQry + " " + "VALUES(";

                    sqlQry = sqlQry + " " + GetLatestGroupID();

                    if (!string.IsNullOrEmpty(GroupItem.GroupName))
                    {
                        sqlQry = sqlQry + " " + ",'" + GroupItem.GroupName + "'";
                    }
                    else
                    {
                        sqlQry = sqlQry + " " + ",NULL";
                    }

                    if (!string.IsNullOrEmpty(GroupItem.GroupName))
                    {
                        sqlQry = sqlQry + " " + ",'" + GroupItem.GroupDesc + "'";
                    }
                    else
                    {
                        sqlQry = sqlQry + " " + ",NULL";
                    }
                  
                    sqlQry = sqlQry + " " + "," + iRoleID + "";
                    sqlQry = sqlQry + " " + ",GETDATE()";

                    if (!string.IsNullOrEmpty(GroupItem.UserName))
                    {
                        sqlQry = sqlQry + " " + ",'" + GroupItem.UserName + "'";
                    }
                    else
                    {
                        sqlQry = sqlQry + " " + ",NULL";
                    }

                    sqlQry = sqlQry + " " + ")";

                    SqlHelper.SqlExecuteNonQuery(sqlQry);
                    saveFlag = true;
                }
                return saveFlag;
            }
            catch
            {
                throw;
            }
        }


        public bool UpdateGroup(List<GroupModel> lstGroupModel, int groupID)
        {
            sqlQry = "";
            int roleID = 0;
            //string strRoleIDs = "";

            try
            {
                foreach (var GroupItem in lstGroupModel)
                {

                    if (!string.IsNullOrEmpty(GroupItem.RoleItemIDs))
                    {

                        roleID = GetRoleIDFromGroup(groupID);

                        UpdateRolesForGroups(GroupItem.RoleItemIDs, roleID);
                    }

                    sqlQry = "UPDATE [dbo].[GroupDetails] SET";

                    if (!string.IsNullOrEmpty(GroupItem.GroupName))
                    {
                        sqlQry = sqlQry + " " + "[Group Name] = '" + GroupItem.GroupName + "'";
                    }
                    if (!string.IsNullOrEmpty(GroupItem.GroupDesc))
                    {
                        sqlQry = sqlQry + " " + ",[Group Description] = '" + GroupItem.GroupDesc + "'";
                    }
                    if (!string.IsNullOrEmpty(GroupItem.UserName))
                    {
                        sqlQry = sqlQry + " " + ",[ModifiedBy] = '" + GroupItem.UserName + "'";
                    }
                    
                    sqlQry = sqlQry + " " + ",[ModifiedDate] = GETDATE()";
                    
                    //if (UserItem.Status.HasValue)
                    //{
                    //    sqlQry = sqlQry + " " + ",[RoleID] = " + UserItem.Status;
                    //}

                    sqlQry = sqlQry + " " + "WHERE GroupID=" + groupID;

                    SqlHelper.SqlExecuteNonQuery(sqlQry);
                    saveFlag = true;

                }

                return saveFlag;

            }
            catch { throw; }
        }


        public bool DeleteGroup(int groupID, string userName)
        {
            sqlQry = "";
            try
            {
                sqlQry = "UPDATE [dbo].[GroupDetails] SET DeleteFlag='D', [ModifiedBy]='" + userName + "', ModifiedDate=GETDATE() WHERE GroupID=" + groupID;
                SqlHelper.SqlExecuteNonQuery(sqlQry);
                saveFlag = true;
                return saveFlag;

            }
            catch
            {
                throw;
            }
        }


        private int CreateRolesForGroups(string roleIDs)
        {
            sqlQry = "";
            int iRoleID = 0;

            try
            {
                iRoleID = GetLatestRoleID();
                sqlQry = "INSERT INTO [dbo].[AccessRoles]";

                sqlQry = sqlQry + " " + "([RoleID],[RoleItemIDs])";
                sqlQry = sqlQry + " " + "VALUES(";

                sqlQry = sqlQry + " " + iRoleID;

                sqlQry = sqlQry + " " + ",'" + roleIDs + "'";               

                sqlQry = sqlQry + " " + ")";

                SqlHelper.SqlExecuteNonQuery(sqlQry);

                return iRoleID;
            }
            catch { throw; }
        }

        private void UpdateRolesForGroups(string roleIDs,int roleID)
        {         
            sqlQry = "";

            try
            {
                sqlQry = "UPDATE [dbo].[AccessRoles] SET ";
                sqlQry = sqlQry + " " + "[RoleItemIDs] = '" + roleIDs + "'";
                sqlQry = sqlQry + " " + "WHERE [RoleID]=" + roleID;
                
                SqlHelper.SqlExecuteNonQuery(sqlQry);

               
            }
            catch { throw; }
        }

        private int GetLatestGroupID()
        {
            sqlQry = "";
            int grpID = 0;

            try
            {
                sqlQry = @"SELECT MAX(GroupID) FROM [GroupDetails]";

                Object objGrpID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objGrpID != null && DBNull.Value != objGrpID)
                {
                    grpID = Convert.ToInt32(objGrpID);

                }


                return grpID + 1;
            }
            catch
            {
                throw;
            }

        }

        

        private int GetLatestRoleID()
        {
            sqlQry = "";
            int roleID = 0;

            try
            {
                sqlQry = @"SELECT MAX([RoleID]) FROM [AccessRoles]";

                Object objRoleID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objRoleID != null && DBNull.Value != objRoleID)
                {
                    roleID = Convert.ToInt32(objRoleID);

                }


                return roleID + 1;
            }
            catch
            {
                throw;
            }

        }

        public DataTable GetGroupDetails()
        {
            DataTable dtGroupItems = new DataTable();
            sqlQry = "";

            try
            {
                sqlQry = @"SELECT GroupID ,[Group Name] AS GroupName FROM [GroupDetails] WHERE DeleteFlag<>'D'";

                dtGroupItems = SqlHelper.SqlExecuteDataTable(sqlQry);

                return dtGroupItems;
            }
            catch { throw; }
        }


        public DataTable GetRoleItems()
        {
            DataTable dtRoleItems = new DataTable();
            sqlQry = "";

            try
            {
                sqlQry = @"SELECT [RoleId],[Role Item Name] AS RoleName FROM AccessRoleItems";

                dtRoleItems = SqlHelper.SqlExecuteDataTable(sqlQry);

                return dtRoleItems;
            }
            catch { throw; }
        }

        private int GetRoleIDFromGroup(int groupID)
        {
            sqlQry = "";
            int roleID = 0;

            try
            {
                sqlQry = @"SELECT RoleID FROM [GroupDetails] WHERE GroupID=" + groupID + "AND DeleteFlag<>'D'";

                Object objRoleID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objRoleID != null && DBNull.Value != objRoleID)
                {
                    roleID = Convert.ToInt32(objRoleID);

                }


                return roleID;
            }
            catch
            {
                throw;
            }
        }

        private string GetRoleItemIDS(int groupID)
        {
            sqlQry = "";
            string roleIDs = "";
            int roleID = 0;

            try
            {
                roleID = GetRoleIDFromGroup(groupID);

                sqlQry = "";

                sqlQry = @"SELECT RoleItemIDs FROM [AccessRoles] WHERE RoleID=" + roleID;

                Object objRoleID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objRoleID != null && DBNull.Value != objRoleID)
                {
                    roleIDs = Convert.ToString(objRoleID);

                }

                return roleIDs;

               // return roleID + 1;
            }
            catch
            {
                throw;
            }
        }

        private int GetGroupIDFromUser(int userID)
        {
            sqlQry = "";
            int groupID = 0;

            try
            {
                //sqlQry = @"SELECT GroupID From [UserDetails] WHERE UserID=" + userID;
                sqlQry = @"SELECT GroupID From User_Details WHERE EmpID=" + userID;

                Object objGroupID = SqlHelper.SqlExecuteScalar(sqlQry);

                if (objGroupID != null && DBNull.Value != objGroupID)
                {
                    groupID = Convert.ToInt32(objGroupID);

                }


                return groupID;
            }
            catch
            {
                throw;
            }
        }

        public string GetAccessMenuCodeInUserLevel(int userID)
        {
            string roleIDs = "";
            sqlQry = "";
            int grpID = 0;
            string menuCodes = "";

            try
            {
                grpID = GetGroupIDFromUser(userID);
                roleIDs = GetRoleItemIDS(grpID);
                if (roleIDs != null && roleIDs != "")
                {
                    sqlQry = "";
                    sqlQry = "SELECT STUFF((SELECT ',' + CONVERT(VARCHAR(50),MenuCode)";
                    sqlQry = sqlQry + " " + "FROM AccessRoleItems where RoleId in (";
                    sqlQry = sqlQry + roleIDs + ")";
                    sqlQry = sqlQry + " " + "FOR XML PATH('')) ,1,1,'') AS code";

                    Object objMenuCodes = SqlHelper.SqlExecuteScalar(sqlQry);

                    if (objMenuCodes != null && DBNull.Value != objMenuCodes)
                    {
                        menuCodes = Convert.ToString(objMenuCodes);

                    }
                }

                return menuCodes;
            }
            catch { throw; }
        }
        public DataTable GetRoleItemsByGroup(int groupID)
        {
            DataTable dtRoleItems = new DataTable();
            string roleIDs = "";
            sqlQry = "";

            try
            {
                roleIDs = GetRoleItemIDS(groupID);

                sqlQry = @"SELECT [RoleId],[Role Item Name] AS RoleName FROM AccessRoleItems WHERE RoleID IN (" + roleIDs + ")";

                dtRoleItems = SqlHelper.SqlExecuteDataTable(sqlQry);

                return dtRoleItems;
            }
            catch { throw; }
        }

        public bool ValidateUserRole(int userID,string key)
        {
            bool validFlag = false;
            int iGrpID = 0;
            string strRoleIDs;

            sqlQry = "";

            try {

                iGrpID = GetGroupIDFromUser(userID);
                strRoleIDs = GetRoleItemIDS(iGrpID);

                sqlQry = "SELECT COUNT(*) FROM AccessRoleItems";
                sqlQry = sqlQry + " " + "WHERE [RoleId] IN (" + strRoleIDs;
                sqlQry = sqlQry + " " + ") AND [ROle Item Name]='" + key + "'";


                Object objBool = SqlHelper.SqlExecuteScalar(sqlQry);

                if (Convert.ToInt32(objBool) >0)
                {
                    validFlag = true;
                }


                return validFlag;

            }
            catch { throw; }
        }

        public bool ValidateMenuRole(int userID, string menuCode)
        {          
            string strMenuCodes;
            bool validFlag = false;

            sqlQry = "";

            try
            {

                strMenuCodes = GetAccessMenuCodeInUserLevel(userID);

                if (strMenuCodes.Contains("," + menuCode + ","))
                {
                    validFlag= true;
                }

                //Object objBool = SqlHelper.SqlExecuteScalar(sqlQry);

                //if (Convert.ToInt32(objBool) > 0)
                //{
                //    validFlag = true;
                //}


                return validFlag;

            }
            catch { throw; }
        }

    }


    public class GroupModel
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public string RoleItemIDs { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
    }
}