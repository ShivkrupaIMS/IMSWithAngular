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
    public class InvoiceStatusController : ApiController
    {
        private IInvoiceStatusBL _InvoiceStatusBL;

        public InvoiceStatusController(IInvoiceStatusBL InvoiceStatusBL)
        {
            _InvoiceStatusBL = InvoiceStatusBL;
        }

        [HttpPost]
        public InvoiceStatusVM AddInvoiceStatus(InvoiceStatusVM c)
        {
            return _InvoiceStatusBL.AddInvoiceStatus(c);
        }
        [HttpPost]
        public int DeleteInvoiceStatus(InvoiceStatusVM c)
        {
            return _InvoiceStatusBL.DeleteInvoiceStatus(c.InvoiceStatusId);
        }
        [HttpPost]
        public InvoiceStatusVM EditInvoiceStatus(InvoiceStatusVM c)
        {
            return _InvoiceStatusBL.EditInvoiceStatus(c);
        }

        public InvoiceStatusVM GetInvoiceStatusById(int InvoiceStatusId)
        {
            return _InvoiceStatusBL.GetInvoiceStatusById(InvoiceStatusId);
        }

        public IList<InvoiceStatusVM> GetInvoiceStatusList()
        {
            return _InvoiceStatusBL.GetInvoiceStatusList();
        }
    }
}
