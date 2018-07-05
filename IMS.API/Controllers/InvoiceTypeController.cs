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
    public class InvoiceTypeController : ApiController
    {
        private IInvoiceTypeBL _InvoiceTypeBL;

        public InvoiceTypeController(IInvoiceTypeBL InvoiceTypeBL)
        {
            _InvoiceTypeBL = InvoiceTypeBL;
        }

        [HttpPost]
        public InvoiceTypeVM AddInvoiceType(InvoiceTypeVM c)
        {
            return _InvoiceTypeBL.AddInvoiceType(c);
        }
        [HttpPost]
        public int DeleteInvoiceType(InvoiceTypeVM c)
        {
            return _InvoiceTypeBL.DeleteInvoiceType(c.InvoiceTypeId);
        }
        [HttpPost]
        public InvoiceTypeVM EditInvoiceType(InvoiceTypeVM c)
        {
            return _InvoiceTypeBL.EditInvoiceType(c);
        }

        public InvoiceTypeVM GetInvoiceTypeById(int InvoiceTypeId)
        {
            return _InvoiceTypeBL.GetInvoiceTypeById(InvoiceTypeId);
        }

        public IList<InvoiceTypeVM> GetInvoiceTypeList()
        {
            return _InvoiceTypeBL.GetInvoiceTypeList();
        }
    }
}
