using FinanceModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceBA.LoginBA
{
   public interface ILoginBA
    {
        Newloginmodel validateusercredentails(Newloginmodel model);
    }
}
