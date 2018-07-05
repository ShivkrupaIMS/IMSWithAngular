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
    public class SupplierTypeController : ApiController
    {
        private ISupplierTypeBL _SupplierTypeBL;

        public SupplierTypeController(ISupplierTypeBL SupplierTypeBL)
        {
            _SupplierTypeBL = SupplierTypeBL;
        }

        [HttpPost]
        public SupplierTypeVM AddSupplierType(SupplierTypeVM c)
        {
            return _SupplierTypeBL.AddSupplierType(c);
        }
        [HttpPost]
        public int DeleteSupplierType(SupplierTypeVM c)
        {
            return _SupplierTypeBL.DeleteSupplierType(c.SupplierTypeId);
        }
        [HttpPost]
        public SupplierTypeVM EditSupplierType(SupplierTypeVM c)
        {
            return _SupplierTypeBL.EditSupplierType(c);
        }

        public SupplierTypeVM GetSupplierTypeById(int SupplierTypeId)
        {
            return _SupplierTypeBL.GetSupplierTypeById(SupplierTypeId);
        }

        public IList<SupplierTypeVM> GetSupplierTypeList()
        {
            return _SupplierTypeBL.GetSupplierTypeList();
        }
    }
}
