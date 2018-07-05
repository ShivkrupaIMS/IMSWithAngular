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
    public class InvoiceTermController : ApiController
    {
        private IInvoiceTermBL _InvoiceTermBL;

        public InvoiceTermController(IInvoiceTermBL InvoiceTermBL)
        {
            _InvoiceTermBL = InvoiceTermBL;
        }

        [HttpPost]
        public InvoiceTermVM AddInvoiceTerm(InvoiceTermVM c)
        {
            return _InvoiceTermBL.AddInvoiceTerm(c);
        }
        [HttpPost]
        public int DeleteInvoiceTerm(InvoiceTermVM c)
        {
            return _InvoiceTermBL.DeleteInvoiceTerm(c.InvoiceTermId);
        }
        [HttpPost]
        public InvoiceTermVM EditInvoiceTerm(InvoiceTermVM c)
        {
            return _InvoiceTermBL.EditInvoiceTerm(c);
        }

        public InvoiceTermVM GetInvoiceTermById(int InvoiceTermId)
        {
            return _InvoiceTermBL.GetInvoiceTermById(InvoiceTermId);
        }

        public IList<InvoiceTermVM> GetInvoiceTermList()
        {
            return _InvoiceTermBL.GetInvoiceTermList();
        }
    }
}
