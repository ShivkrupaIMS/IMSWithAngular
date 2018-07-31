using IMS.DF.BL;
using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL
{
    public class InvoiceBL : IInvoiceBL
    {
        private IInvoiceDL _InvoiceDL;

        public InvoiceBL(IInvoiceDL InvoiceDL)
        {
            _InvoiceDL = InvoiceDL;
        }

        public InvoiceVM AddInvoice(InvoiceVM c)
        {
            return _InvoiceDL.AddInvoice(c);
        }

        public int DeleteInvoice(int InvoiceId)
        {
            return _InvoiceDL.DeleteInvoice(InvoiceId);
        }

        public InvoiceVM EditInvoice(InvoiceVM c)
        {
            return _InvoiceDL.EditInvoice(c);
        }

        public InvoiceVM GetInvoiceById(int InvoiceId)
        {
            return _InvoiceDL.GetInvoiceById(InvoiceId);
        }

        public IList<InvoiceVM> GetInvoiceList()
        {
            return _InvoiceDL.GetInvoiceList();
        }
    }
}
