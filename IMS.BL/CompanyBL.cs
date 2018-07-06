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
    public class CompanyBL : ICompanyBL
    {
        private ICompanyDL _CompanyDL;

        public CompanyBL(ICompanyDL CompanyDL)
        {
            _CompanyDL = CompanyDL;
        }

        public CompanyVM AddCompany(CompanyVM c)
        {
            return _CompanyDL.AddCompany(c);
        }

        public int DeleteCompany(int CompanyId)
        {
            return _CompanyDL.DeleteCompany(CompanyId);
        }

        public CompanyVM EditCompany(CompanyVM c)
        {
            return _CompanyDL.EditCompany(c);
        }

        public CompanyVM GetCompanyById(int CompanyId)
        {
            return _CompanyDL.GetCompanyById(CompanyId);
        }

        public IList<CompanyVM> GetCompanyList()
        {
            return _CompanyDL.GetCompanyList();
        }
    }
}
