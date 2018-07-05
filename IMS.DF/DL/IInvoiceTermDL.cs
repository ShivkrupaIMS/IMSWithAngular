using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IInvoiceTermDL
    {
        IList<InvoiceTermVM> GetInvoiceTermList();
        InvoiceTermVM AddInvoiceTerm(InvoiceTermVM c);
        InvoiceTermVM EditInvoiceTerm(InvoiceTermVM c);
        int DeleteInvoiceTerm(int InvoiceTermId);
        InvoiceTermVM GetInvoiceTermById(int id);
    }
}
