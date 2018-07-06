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
    public class CompanyController : ApiController
    {
        private ICompanyBL _CompanyBL;

        public CompanyController(ICompanyBL CompanyBL)
        {
            _CompanyBL = CompanyBL;
        }

        [HttpPost]
        public CompanyVM AddCompany(CompanyVM c)
        {
            return _CompanyBL.AddCompany(c);
        }
        [HttpPost]
        public int DeleteCompany(CompanyVM c)
        {
            return _CompanyBL.DeleteCompany(c.CompanyId);
        }
        [HttpPost]
        public CompanyVM EditCompany(CompanyVM c)
        {
            return _CompanyBL.EditCompany(c);
        }

        public CompanyVM GetCompanyById(int CompanyId)
        {
            return _CompanyBL.GetCompanyById(CompanyId);
        }

        public IList<CompanyVM> GetCompanyList()
        {
            return _CompanyBL.GetCompanyList();
        }
    }
}
