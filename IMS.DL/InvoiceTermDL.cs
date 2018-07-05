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
    public class InvoiceTermDL : BaseDL, IInvoiceTermDL
    {
        public InvoiceTermVM AddInvoiceTerm(InvoiceTermVM c)
        {
            DB.tblInvoiceTerm InvoiceTerm = IMSDB.tblInvoiceTerms.Add(
                new DB.tblInvoiceTerm
                {
                    InvoiceTerm = c.InvoiceTerm,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.InvoiceTermId = InvoiceTerm.InvoiceTermId;
            return c;
        }

        public int DeleteInvoiceTerm(int InvoiceTermId)
        {
            IMSDB.tblInvoiceTerms.Remove(IMSDB.tblInvoiceTerms.Where(p => p.InvoiceTermId == InvoiceTermId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public InvoiceTermVM EditInvoiceTerm(InvoiceTermVM c)
        {
            DB.tblInvoiceTerm InvoiceTerm = IMSDB.tblInvoiceTerms.Find(c.InvoiceTermId);
            if (InvoiceTerm != null)
            {
                InvoiceTerm.InvoiceTerm = c.InvoiceTerm;
                InvoiceTerm.IsActive = c.IsActive;
                IMSDB.Entry(InvoiceTerm).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public InvoiceTermVM GetInvoiceTermById(int InvoiceTermId)
        {
            DB.tblInvoiceTerm InvoiceTerm = IMSDB.tblInvoiceTerms.Where(p => p.InvoiceTermId == InvoiceTermId).FirstOrDefault();
            if (InvoiceTerm != null)
            {
                return new InvoiceTermVM()
                {
                    InvoiceTermId = InvoiceTerm.InvoiceTermId,
                    InvoiceTerm = InvoiceTerm.InvoiceTerm,
                    IsActive = InvoiceTerm.IsActive
                };
            }

            return null;
        }

        public IList<InvoiceTermVM> GetInvoiceTermList()
        {
            List<InvoiceTermVM> InvoiceTermList = new List<InvoiceTermVM>();
            List<DB.tblInvoiceTerm> InvoiceTerms = IMSDB.tblInvoiceTerms.ToList();
            if (InvoiceTerms != null)
            {
                InvoiceTerms.ForEach(p => InvoiceTermList.Add(
                    new InvoiceTermVM()
                    {
                        InvoiceTermId = p.InvoiceTermId,
                        InvoiceTerm = p.InvoiceTerm,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return InvoiceTermList;
        }
    }
}
