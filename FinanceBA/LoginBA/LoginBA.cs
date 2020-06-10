using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceModels.DomainModels;
using FinanceDA.LoginDA;

namespace FinanceBA.LoginBA
{
    public class LoginBA : ILoginBA
    {
        private readonly ILoginDA _loginda;
        public LoginBA(ILoginDA loginDA)
        {
            this._loginda = loginDA;
        }
        public Newloginmodel validateusercredentails(Newloginmodel model)
        {
           return this._loginda.validateusercredentails(model);
        }
    }
}
