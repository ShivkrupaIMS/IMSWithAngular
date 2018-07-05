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
    public class TaxSlabController : ApiController
    {
        private ITaxSlabBL _TaxSlabBL;

        public TaxSlabController(ITaxSlabBL TaxSlabBL)
        {
            _TaxSlabBL = TaxSlabBL;
        }

        [HttpPost]
        public TaxSlabVM AddTaxSlab(TaxSlabVM c)
        {
            return _TaxSlabBL.AddTaxSlab(c);
        }
        [HttpPost]
        public int DeleteTaxSlab(TaxSlabVM c)
        {
            return _TaxSlabBL.DeleteTaxSlab(c.TaxSlabId);
        }
        [HttpPost]
        public TaxSlabVM EditTaxSlab(TaxSlabVM c)
        {
            return _TaxSlabBL.EditTaxSlab(c);
        }

        public TaxSlabVM GetTaxSlabById(int TaxSlabId)
        {
            return _TaxSlabBL.GetTaxSlabById(TaxSlabId);
        }

        public IList<TaxSlabVM> GetTaxSlabList()
        {
            return _TaxSlabBL.GetTaxSlabList();
        }
    }
}
