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
    public class InvoiceTermBL : IInvoiceTermBL
    {
        private IInvoiceTermDL _InvoiceTermDL;

        public InvoiceTermBL(IInvoiceTermDL InvoiceTermDL)
        {
            _InvoiceTermDL = InvoiceTermDL;
        }

        public InvoiceTermVM AddInvoiceTerm(InvoiceTermVM c)
        {
            return _InvoiceTermDL.AddInvoiceTerm(c);
        }

        public int DeleteInvoiceTerm(int InvoiceTermId)
        {
            return _InvoiceTermDL.DeleteInvoiceTerm(InvoiceTermId);
        }

        public InvoiceTermVM EditInvoiceTerm(InvoiceTermVM c)
        {
            return _InvoiceTermDL.EditInvoiceTerm(c);
        }

        public InvoiceTermVM GetInvoiceTermById(int InvoiceTermId)
        {
            return _InvoiceTermDL.GetInvoiceTermById(InvoiceTermId);
        }

        public IList<InvoiceTermVM> GetInvoiceTermList()
        {
            return _InvoiceTermDL.GetInvoiceTermList();
        }
    }
}
