using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceModels.FinanceEntity;
using FinanceBA.LoginBA;
using FinanceModels.DomainModels;

namespace Finacenewapi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginBA _login;
        public LoginController(ILoginBA logins)
        {
            this._login = logins;
        }
        [HttpPost]
        [Route("api/validateusercredentails")]
        public IHttpActionResult validateusercredentails(Newloginmodel model)
        {
            return Ok(this._login.validateusercredentails(model));
        }
    }
}
