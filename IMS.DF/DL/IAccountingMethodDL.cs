using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IAccountingMethodDL
    {
        IList<AccountingMethodVM> GetAccountingMethodList();
        AccountingMethodVM AddAccountingMethod(AccountingMethodVM c);
        AccountingMethodVM EditAccountingMethod(AccountingMethodVM c);
        int DeleteAccountingMethod(int AccountingMethodId);
        AccountingMethodVM GetAccountingMethodById(int id);
    }
}
