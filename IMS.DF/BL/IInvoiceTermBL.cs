using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface IInvoiceTermBL
    {
        IList<InvoiceTermVM> GetInvoiceTermList();
        InvoiceTermVM AddInvoiceTerm(InvoiceTermVM c);
        InvoiceTermVM EditInvoiceTerm(InvoiceTermVM c);
        int DeleteInvoiceTerm(int InvoiceTermId);
        InvoiceTermVM GetInvoiceTermById(int id);
    }
}
