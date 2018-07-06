using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface ICompanyDL
    {
        IList<CompanyVM> GetCompanyList();
        CompanyVM AddCompany(CompanyVM c);
        CompanyVM EditCompany(CompanyVM c);
        int DeleteCompany(int CompanyId);
        CompanyVM GetCompanyById(int id);
    }
}
