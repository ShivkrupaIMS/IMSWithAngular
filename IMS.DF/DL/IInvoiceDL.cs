using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IInvoiceDL
    {
        IList<InvoiceVM> GetInvoiceList();
        InvoiceVM AddInvoice(InvoiceVM c);
        InvoiceVM EditInvoice(InvoiceVM c);
        int DeleteInvoice(int InvoiceId);
        InvoiceVM GetInvoiceById(int id);
    }
}
