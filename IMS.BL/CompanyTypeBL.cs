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
    public class CompanyTypeBL:ICompanyTypeBL
    {
        private ICompanyTypeDL _CompanyTypeDL;

        public CompanyTypeBL(ICompanyTypeDL CompanyTypeDL)
        {
            _CompanyTypeDL = CompanyTypeDL;
        }

        public CompanyTypeVM AddCompanyType(CompanyTypeVM c)
        {
            return _CompanyTypeDL.AddCompanyType(c);
        }

        public int DeleteCompanyType(int CompanyTypeId)
        {
            return _CompanyTypeDL.DeleteCompanyType(CompanyTypeId);
        }

        public CompanyTypeVM EditCompanyType(CompanyTypeVM c)
        {
            return _CompanyTypeDL.EditCompanyType(c);
        }

        public CompanyTypeVM GetCompanyTypeById(int CompanyTypeId)
        {
            return _CompanyTypeDL.GetCompanyTypeById(CompanyTypeId);
        }

        public IList<CompanyTypeVM> GetCompanyTypeList()
        {
            return _CompanyTypeDL.GetCompanyTypeList();
        }
    }
}
