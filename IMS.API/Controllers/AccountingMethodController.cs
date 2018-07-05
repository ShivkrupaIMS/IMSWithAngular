using IMS.DF.BL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS.API.Controllers
{
    public class AccountingMethodController : ApiController
    {
        private IAccountingMethodBL _AccountingMethodBL;

        public AccountingMethodController(IAccountingMethodBL AccountingMethodBL)
        {
            _AccountingMethodBL = AccountingMethodBL;
        }

        [HttpPost]
        public AccountingMethodVM AddAccountingMethod(AccountingMethodVM c)
        {
            return _AccountingMethodBL.AddAccountingMethod(c);
        }
        [HttpPost]
        public int DeleteAccountingMethod(AccountingMethodVM c)
        {
            return _AccountingMethodBL.DeleteAccountingMethod(c.AccountingMethodId);
        }
        [HttpPost]
        public AccountingMethodVM EditAccountingMethod(AccountingMethodVM c)
        {
            return _AccountingMethodBL.EditAccountingMethod(c);
        }

        public AccountingMethodVM GetAccountingMethodById(int AccountingMethodId)
        {
            return _AccountingMethodBL.GetAccountingMethodById(AccountingMethodId);
        }

        public IList<AccountingMethodVM> GetAccountingMethodList()
        {
            return _AccountingMethodBL.GetAccountingMethodList();
        }
    }
}
