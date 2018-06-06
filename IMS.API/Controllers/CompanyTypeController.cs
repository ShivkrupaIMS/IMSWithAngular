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
    public class CompanyTypeController : ApiController
    {
        private ICompanyTypeBL _CompanyTypeBL;

        public CompanyTypeController(ICompanyTypeBL CompanyTypeBL)
        {
            _CompanyTypeBL = CompanyTypeBL;
        }

        [HttpPost]
        public CompanyTypeVM AddCompanyType(CompanyTypeVM c)
        {
            return _CompanyTypeBL.AddCompanyType(c);
        }
        [HttpPost]
        public int DeleteCompanyType(CompanyTypeVM c)
        {
            return _CompanyTypeBL.DeleteCompanyType(c.CompanyTypeId);
        }
        [HttpPost]
        public CompanyTypeVM EditCompanyType(CompanyTypeVM c)
        {
            return _CompanyTypeBL.EditCompanyType(c);
        }

        public CompanyTypeVM GetCompanyTypeById(int CompanyTypeId)
        {
            return _CompanyTypeBL.GetCompanyTypeById(CompanyTypeId);
        }

        public IList<CompanyTypeVM> GetCompanyTypeList()
        {
            return _CompanyTypeBL.GetCompanyTypeList();
        }
    }
}
