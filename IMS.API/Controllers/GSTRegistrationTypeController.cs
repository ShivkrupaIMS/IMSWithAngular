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
    public class GSTRegistrationTypeController : ApiController
    {
        private IGSTRegistrationTypeBL _GSTRegistrationTypeBL;

        public GSTRegistrationTypeController(IGSTRegistrationTypeBL GSTRegistrationTypeBL)
        {
            _GSTRegistrationTypeBL = GSTRegistrationTypeBL;
        }

        [HttpPost]
        public GSTRegistrationTypeVM AddGSTRegistrationType(GSTRegistrationTypeVM c)
        {
            return _GSTRegistrationTypeBL.AddGSTRegistrationType(c);
        }
        [HttpPost]
        public int DeleteGSTRegistrationType(GSTRegistrationTypeVM c)
        {
            return _GSTRegistrationTypeBL.DeleteGSTRegistrationType(c.GSTRegistrationTypeId);
        }
        [HttpPost]
        public GSTRegistrationTypeVM EditGSTRegistrationType(GSTRegistrationTypeVM c)
        {
            return _GSTRegistrationTypeBL.EditGSTRegistrationType(c);
        }

        public GSTRegistrationTypeVM GetGSTRegistrationTypeById(int GSTRegistrationTypeId)
        {
            return _GSTRegistrationTypeBL.GetGSTRegistrationTypeById(GSTRegistrationTypeId);
        }

        public IList<GSTRegistrationTypeVM> GetGSTRegistrationTypeList()
        {
            return _GSTRegistrationTypeBL.GetGSTRegistrationTypeList();
        }
    }
}
