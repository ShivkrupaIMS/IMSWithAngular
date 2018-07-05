using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL
{
    public class AccountingMethodDL : BaseDL, IAccountingMethodDL
    {
        public AccountingMethodVM AddAccountingMethod(AccountingMethodVM c)
        {
            DB.tblAccountingMethod AccountingMethod = IMSDB.tblAccountingMethods.Add(
                new DB.tblAccountingMethod
                {
                    AccountingMethod = c.AccountingMethod,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.AccountingMethodId = AccountingMethod.AccountingMethodId;
            return c;
        }

        public int DeleteAccountingMethod(int AccountingMethodId)
        {
            IMSDB.tblAccountingMethods.Remove(IMSDB.tblAccountingMethods.Where(p => p.AccountingMethodId == AccountingMethodId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public AccountingMethodVM EditAccountingMethod(AccountingMethodVM c)
        {
            DB.tblAccountingMethod AccountingMethod = IMSDB.tblAccountingMethods.Find(c.AccountingMethodId);
            if (AccountingMethod != null)
            {
                AccountingMethod.AccountingMethod = c.AccountingMethod;
                AccountingMethod.IsActive = c.IsActive;
                IMSDB.Entry(AccountingMethod).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public AccountingMethodVM GetAccountingMethodById(int AccountingMethodId)
        {
            DB.tblAccountingMethod AccountingMethod = IMSDB.tblAccountingMethods.Where(p => p.AccountingMethodId == AccountingMethodId).FirstOrDefault();
            if (AccountingMethod != null)
            {
                return new AccountingMethodVM()
                {
                    AccountingMethodId = AccountingMethod.AccountingMethodId,
                    AccountingMethod = AccountingMethod.AccountingMethod,
                    IsActive = AccountingMethod.IsActive
                };
            }

            return null;
        }

        public IList<AccountingMethodVM> GetAccountingMethodList()
        {
            List<AccountingMethodVM> AccountingMethodList = new List<AccountingMethodVM>();
            List<DB.tblAccountingMethod> AccountingMethods = IMSDB.tblAccountingMethods.ToList();
            if (AccountingMethods != null)
            {
                AccountingMethods.ForEach(p => AccountingMethodList.Add(
                    new AccountingMethodVM()
                    {
                        AccountingMethodId = p.AccountingMethodId,
                        AccountingMethod = p.AccountingMethod,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return AccountingMethodList;
        }
    }
}
