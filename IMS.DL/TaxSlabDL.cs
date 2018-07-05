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
    public class TaxSlabDL : BaseDL, ITaxSlabDL
    {
        public TaxSlabVM AddTaxSlab(TaxSlabVM c)
        {
            DB.tblTaxSlab TaxSlab = IMSDB.tblTaxSlabs.Add(
                new DB.tblTaxSlab
                {
                    TaxSlab = c.TaxSlab,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.TaxSlabId = TaxSlab.TaxSlabId;
            return c;
        }

        public int DeleteTaxSlab(int TaxSlabId)
        {
            IMSDB.tblTaxSlabs.Remove(IMSDB.tblTaxSlabs.Where(p => p.TaxSlabId == TaxSlabId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public TaxSlabVM EditTaxSlab(TaxSlabVM c)
        {
            DB.tblTaxSlab TaxSlab = IMSDB.tblTaxSlabs.Find(c.TaxSlabId);
            if (TaxSlab != null)
            {
                TaxSlab.TaxSlab = c.TaxSlab;
                TaxSlab.IsActive = c.IsActive;
                IMSDB.Entry(TaxSlab).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public TaxSlabVM GetTaxSlabById(int TaxSlabId)
        {
            DB.tblTaxSlab TaxSlab = IMSDB.tblTaxSlabs.Where(p => p.TaxSlabId == TaxSlabId).FirstOrDefault();
            if (TaxSlab != null)
            {
                return new TaxSlabVM()
                {
                    TaxSlabId = TaxSlab.TaxSlabId,
                    TaxSlab = TaxSlab.TaxSlab,
                    IsActive = TaxSlab.IsActive
                };
            }

            return null;
        }

        public IList<TaxSlabVM> GetTaxSlabList()
        {
            List<TaxSlabVM> TaxSlabList = new List<TaxSlabVM>();
            List<DB.tblTaxSlab> TaxSlabs = IMSDB.tblTaxSlabs.ToList();
            if (TaxSlabs != null)
            {
                TaxSlabs.ForEach(p => TaxSlabList.Add(
                    new TaxSlabVM()
                    {
                        TaxSlabId = p.TaxSlabId,
                        TaxSlab = p.TaxSlab,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return TaxSlabList;
        }
    }
}
