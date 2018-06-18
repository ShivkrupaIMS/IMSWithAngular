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
    public class LicenseTypeController : ApiController
    {
        private ILicenseTypeBL _LicenseTypeBL;

        public LicenseTypeController(ILicenseTypeBL LicenseTypeBL)
        {
            _LicenseTypeBL = LicenseTypeBL;
        }

        [HttpPost]
        public LicenseTypeVM AddLicenseType(LicenseTypeVM c)
        {
            return _LicenseTypeBL.AddLicenseType(c);
        }
        [HttpPost]
        public int DeleteLicenseType(LicenseTypeVM c)
        {
            return _LicenseTypeBL.DeleteLicenseType(c.LicenseTypeId);
        }
        [HttpPost]
        public LicenseTypeVM EditLicenseType(LicenseTypeVM c)
        {
            return _LicenseTypeBL.EditLicenseType(c);
        }

        public LicenseTypeVM GetLicenseTypeById(int LicenseTypeId)
        {
            return _LicenseTypeBL.GetLicenseTypeById(LicenseTypeId);
        }

        public IList<LicenseTypeVM> GetLicenseTypeList()
        {
            return _LicenseTypeBL.GetLicenseTypeList();
        }
    }
}
