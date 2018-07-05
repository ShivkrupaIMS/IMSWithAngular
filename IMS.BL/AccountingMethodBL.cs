using IMS.DF.BL;
using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL
{
    public class AccountingMethodBL : IAccountingMethodBL
    {
        private IAccountingMethodDL _AccountingMethodDL;

        public AccountingMethodBL(IAccountingMethodDL AccountingMethodDL)
        {
            _AccountingMethodDL = AccountingMethodDL;
        }

        public AccountingMethodVM AddAccountingMethod(AccountingMethodVM c)
        {
            return _AccountingMethodDL.AddAccountingMethod(c);
        }

        public int DeleteAccountingMethod(int AccountingMethodId)
        {
            return _AccountingMethodDL.DeleteAccountingMethod(AccountingMethodId);
        }

        public AccountingMethodVM EditAccountingMethod(AccountingMethodVM c)
        {
            return _AccountingMethodDL.EditAccountingMethod(c);
        }

        public AccountingMethodVM GetAccountingMethodById(int AccountingMethodId)
        {
            return _AccountingMethodDL.GetAccountingMethodById(AccountingMethodId);
        }

        public IList<AccountingMethodVM> GetAccountingMethodList()
        {
            return _AccountingMethodDL.GetAccountingMethodList();
        }
    }
}
