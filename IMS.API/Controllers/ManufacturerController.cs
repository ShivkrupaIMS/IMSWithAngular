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
    public class ManufacturerController : ApiController
    {
        private IManufacturerBL _ManufacturerBL;

        public ManufacturerController(IManufacturerBL ManufacturerBL)
        {
            _ManufacturerBL = ManufacturerBL;
        }

        [HttpPost]
        public ManufacturerVM AddManufacturer(ManufacturerVM c)
        {
            return _ManufacturerBL.AddManufacturer(c);
        }
        [HttpPost]
        public int DeleteManufacturer(ManufacturerVM c)
        {
            return _ManufacturerBL.DeleteManufacturer(c.ManufacturerId);
        }
        [HttpPost]
        public ManufacturerVM EditManufacturer(ManufacturerVM c)
        {
            return _ManufacturerBL.EditManufacturer(c);
        }

        public ManufacturerVM GetManufacturerById(int ManufacturerId)
        {
            return _ManufacturerBL.GetManufacturerById(ManufacturerId);
        }

        public IList<ManufacturerVM> GetManufacturerList()
        {
            return _ManufacturerBL.GetManufacturerList();
        }
    }
}
