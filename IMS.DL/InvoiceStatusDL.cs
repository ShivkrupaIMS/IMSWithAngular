using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL
{
    public class InvoiceStatusDL : BaseDL, IInvoiceStatusDL
    {
        public InvoiceStatusVM AddInvoiceStatus(InvoiceStatusVM c)
        {
            DB.tblInvoiceStatuses InvoiceStatus = IMSDB.tblInvoiceStatuses.Add(
                new DB.tblInvoiceStatuses
                {
                    InvoiceStatus = c.InvoiceStatus,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.InvoiceStatusId = InvoiceStatus.InvoiceStatusId;
            return c;
        }

        public int DeleteInvoiceStatus(int InvoiceStatusId)
        {
            IMSDB.tblInvoiceStatuses.Remove(IMSDB.tblInvoiceStatuses.Where(p => p.InvoiceStatusId == InvoiceStatusId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public InvoiceStatusVM EditInvoiceStatus(InvoiceStatusVM c)
        {
            DB.tblInvoiceStatuses InvoiceStatus = IMSDB.tblInvoiceStatuses.Find(c.InvoiceStatusId);
            if (InvoiceStatus != null)
            {
                InvoiceStatus.InvoiceStatus = c.InvoiceStatus;
                InvoiceStatus.IsActive = c.IsActive;
                IMSDB.Entry(InvoiceStatus).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public InvoiceStatusVM GetInvoiceStatusById(int InvoiceStatusId)
        {
            DB.tblInvoiceStatuses InvoiceStatus = IMSDB.tblInvoiceStatuses.Where(p => p.InvoiceStatusId == InvoiceStatusId).FirstOrDefault();
            if (InvoiceStatus != null)
            {
                return new InvoiceStatusVM()
                {
                    InvoiceStatusId = InvoiceStatus.InvoiceStatusId,
                    InvoiceStatus = InvoiceStatus.InvoiceStatus,
                    IsActive = InvoiceStatus.IsActive
                };
            }

            return null;
        }

        public IList<InvoiceStatusVM> GetInvoiceStatusList()
        {
            List<InvoiceStatusVM> InvoiceStatusList = new List<InvoiceStatusVM>();
            List<DB.tblInvoiceStatuses> InvoiceStatuss = IMSDB.tblInvoiceStatuses.ToList();
            if (InvoiceStatuss != null)
            {
                InvoiceStatuss.ForEach(p => InvoiceStatusList.Add(
                    new InvoiceStatusVM()
                    {
                        InvoiceStatusId = p.InvoiceStatusId,
                        InvoiceStatus = p.InvoiceStatus,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return InvoiceStatusList;
        }
    }
}
