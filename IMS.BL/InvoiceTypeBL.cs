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
    public class InvoiceTypeBL : IInvoiceTypeBL
    {
        private IInvoiceTypeDL _InvoiceTypeDL;

        public InvoiceTypeBL(IInvoiceTypeDL InvoiceTypeDL)
        {
            _InvoiceTypeDL = InvoiceTypeDL;
        }

        public InvoiceTypeVM AddInvoiceType(InvoiceTypeVM c)
        {
            return _InvoiceTypeDL.AddInvoiceType(c);
        }

        public int DeleteInvoiceType(int InvoiceTypeId)
        {
            return _InvoiceTypeDL.DeleteInvoiceType(InvoiceTypeId);
        }

        public InvoiceTypeVM EditInvoiceType(InvoiceTypeVM c)
        {
            return _InvoiceTypeDL.EditInvoiceType(c);
        }

        public InvoiceTypeVM GetInvoiceTypeById(int InvoiceTypeId)
        {
            return _InvoiceTypeDL.GetInvoiceTypeById(InvoiceTypeId);
        }

        public IList<InvoiceTypeVM> GetInvoiceTypeList()
        {
            return _InvoiceTypeDL.GetInvoiceTypeList();
        }
    }
}
