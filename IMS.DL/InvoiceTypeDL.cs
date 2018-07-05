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
    public class InvoiceTypeDL : BaseDL, IInvoiceTypeDL
    {
        public InvoiceTypeVM AddInvoiceType(InvoiceTypeVM c)
        {
            DB.tblInvoiceType InvoiceType = IMSDB.tblInvoiceTypes.Add(
                new DB.tblInvoiceType
                {
                    InvoiceType = c.InvoiceType,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.InvoiceTypeId = InvoiceType.InvoiceTypeId;
            return c;
        }

        public int DeleteInvoiceType(int InvoiceTypeId)
        {
            IMSDB.tblInvoiceTypes.Remove(IMSDB.tblInvoiceTypes.Where(p => p.InvoiceTypeId == InvoiceTypeId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public InvoiceTypeVM EditInvoiceType(InvoiceTypeVM c)
        {
            DB.tblInvoiceType InvoiceType = IMSDB.tblInvoiceTypes.Find(c.InvoiceTypeId);
            if (InvoiceType != null)
            {
                InvoiceType.InvoiceType = c.InvoiceType;
                InvoiceType.IsActive = c.IsActive;
                IMSDB.Entry(InvoiceType).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public InvoiceTypeVM GetInvoiceTypeById(int InvoiceTypeId)
        {
            DB.tblInvoiceType InvoiceType = IMSDB.tblInvoiceTypes.Where(p => p.InvoiceTypeId == InvoiceTypeId).FirstOrDefault();
            if (InvoiceType != null)
            {
                return new InvoiceTypeVM()
                {
                    InvoiceTypeId = InvoiceType.InvoiceTypeId,
                    InvoiceType = InvoiceType.InvoiceType,
                    IsActive = InvoiceType.IsActive
                };
            }

            return null;
        }

        public IList<InvoiceTypeVM> GetInvoiceTypeList()
        {
            List<InvoiceTypeVM> InvoiceTypeList = new List<InvoiceTypeVM>();
            List<DB.tblInvoiceType> InvoiceTypes = IMSDB.tblInvoiceTypes.ToList();
            if (InvoiceTypes != null)
            {
                InvoiceTypes.ForEach(p => InvoiceTypeList.Add(
                    new InvoiceTypeVM()
                    {
                        InvoiceTypeId = p.InvoiceTypeId,
                        InvoiceType = p.InvoiceType,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return InvoiceTypeList;
        }
    }
}
