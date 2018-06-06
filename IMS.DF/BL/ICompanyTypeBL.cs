using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface ICompanyTypeBL
    {
        IList<CompanyTypeVM> GetCompanyTypeList();
        CompanyTypeVM AddCompanyType(CompanyTypeVM c);
        CompanyTypeVM EditCompanyType(CompanyTypeVM c);
        int DeleteCompanyType(int CompanyTypeId);
        CompanyTypeVM GetCompanyTypeById(int id);
    }
}
