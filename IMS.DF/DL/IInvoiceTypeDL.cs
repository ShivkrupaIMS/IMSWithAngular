using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IInvoiceTypeDL
    {
        IList<InvoiceTypeVM> GetInvoiceTypeList();
        InvoiceTypeVM AddInvoiceType(InvoiceTypeVM c);
        InvoiceTypeVM EditInvoiceType(InvoiceTypeVM c);
        int DeleteInvoiceType(int InvoiceTypeId);
        InvoiceTypeVM GetInvoiceTypeById(int id);
    }
}
