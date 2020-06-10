using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceModels.DomainModels;
using FinanceModels.FinanceEntity;
using System.DirectoryServices.AccountManagement;

namespace FinanceDA.LoginDA
{
    public class LoginDA : ILoginDA
    {
        Logisticks1Entities obj = new Logisticks1Entities();
        public Newloginmodel validateusercredentails(Newloginmodel model)
        {
            //var session = HttpContext.Current.Session;
            obj.Configuration.ProxyCreationEnabled = false;
            Newloginmodel employee = new Newloginmodel();
            string[] UserCredentials = model.values.Split(',');
            string Id = UserCredentials[0].ToString();
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, UserCredentials[0].Trim());
            if (user != null)
            {
                if (ctx.ValidateCredentials(UserCredentials[0], UserCredentials[1]))
                {
                    var data = obj.ARR_User_Details.Where(li => li.LoginID == Id).FirstOrDefault();
                    if (data != null)
                    {
                        employee.EmployeeNo = data.EmpID;
                        employee.Name = data.EmpName;
                        employee.EMail = data.EMail;
                        employee.Department = data.Department;
                        employee.Division = obj.ARR_UserDescr.Where(x => x.Employeeno == data.EmpID && x.Type == "Division").Select(x => x.Description).ToList();
                        employee.Region = obj.ARR_UserDescr.Where(x => x.Employeeno == data.EmpID && x.Type == "Region").Select(x => x.Description).ToList();
                        employee.Role = data.Role;
                    }
                }
            }
            else if (user == null)
            {
                var data = obj.ARR_User_Details.Where(li => li.LoginID == Id).FirstOrDefault();
                if (data != null)
                {
                    employee.EmployeeNo = data.EmpID;
                    employee.Name = data.EmpName;
                    employee.EMail = data.EMail;
                    employee.Department = data.Department;

                    employee.Role = data.Role;
                }
                //else
                //{
                //    InValidUser();
                //}
            }
            //if (session != null)
            //{
            //    session["name"] = employee.Name;
            //    session["id"] = employee.EmployeeNo.ToString();
            //    string SessionID = session.SessionID;
            //}
            return employee;
        }
    }
}
