using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface IInvoiceStatusBL
    {
        IList<InvoiceStatusVM> GetInvoiceStatusList();
        InvoiceStatusVM AddInvoiceStatus(InvoiceStatusVM c);
        InvoiceStatusVM EditInvoiceStatus(InvoiceStatusVM c);
        int DeleteInvoiceStatus(int InvoiceStatusId);
        InvoiceStatusVM GetInvoiceStatusById(int id);
    }
}
