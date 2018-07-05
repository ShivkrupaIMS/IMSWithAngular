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
    public class InvoiceStatusBL : IInvoiceStatusBL
    {
        private IInvoiceStatusDL _InvoiceStatusDL;

        public InvoiceStatusBL(IInvoiceStatusDL InvoiceStatusDL)
        {
            _InvoiceStatusDL = InvoiceStatusDL;
        }

        public InvoiceStatusVM AddInvoiceStatus(InvoiceStatusVM c)
        {
            return _InvoiceStatusDL.AddInvoiceStatus(c);
        }

        public int DeleteInvoiceStatus(int InvoiceStatusId)
        {
            return _InvoiceStatusDL.DeleteInvoiceStatus(InvoiceStatusId);
        }

        public InvoiceStatusVM EditInvoiceStatus(InvoiceStatusVM c)
        {
            return _InvoiceStatusDL.EditInvoiceStatus(c);
        }

        public InvoiceStatusVM GetInvoiceStatusById(int InvoiceStatusId)
        {
            return _InvoiceStatusDL.GetInvoiceStatusById(InvoiceStatusId);
        }

        public IList<InvoiceStatusVM> GetInvoiceStatusList()
        {
            return _InvoiceStatusDL.GetInvoiceStatusList();
        }
    }
}
