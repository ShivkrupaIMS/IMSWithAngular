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
    public class InvoiceController : ApiController
    {
        private IInvoiceBL _InvoiceBL;

        public InvoiceController(IInvoiceBL InvoiceBL)
        {
            _InvoiceBL = InvoiceBL;
        }

        [HttpPost]
        public InvoiceVM AddInvoice(InvoiceVM c)
        {
            return _InvoiceBL.AddInvoice(c);
        }
        [HttpPost]
        public int DeleteInvoice(InvoiceVM c)
        {
            return _InvoiceBL.DeleteInvoice(c.InvoiceId);
        }
        [HttpPost]
        public InvoiceVM EditInvoice(InvoiceVM c)
        {
            return _InvoiceBL.EditInvoice(c);
        }

        public InvoiceVM GetInvoiceById(int InvoiceId)
        {
            return _InvoiceBL.GetInvoiceById(InvoiceId);
        }

        public IList<InvoiceVM> GetInvoiceList()
        {
            return _InvoiceBL.GetInvoiceList();
        }
    }
}
