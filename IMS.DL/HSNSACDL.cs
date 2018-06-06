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
    public class HSNSACDL : BaseDL, IHSNSACDL
    {
        public HSNSACVM AddHSNSAC(HSNSACVM c)
        {
            DB.tblHSNSAC HSNSAC = IMSDB.tblHSNSACs.Add(
                new DB.tblHSNSAC
                {
                    HSNSACNo = c.HSNSACNo,
                    TaxRate = c.TaxRate,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.HSNSACId = HSNSAC.HSNSACId;
            return c;
        }

        public int DeleteHSNSAC(int HSNSACId)
        {
            IMSDB.tblHSNSACs.Remove(IMSDB.tblHSNSACs.Where(p => p.HSNSACId == HSNSACId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public HSNSACVM EditHSNSAC(HSNSACVM c)
        {
            DB.tblHSNSAC HSNSAC = IMSDB.tblHSNSACs.Find(c.HSNSACId);
            HSNSAC.TaxRate = c.TaxRate;
            HSNSAC.HSNSACNo = c.HSNSACNo;
            HSNSAC.IsActive = c.IsActive;
            IMSDB.Entry(HSNSAC).State = EntityState.Modified;
            IMSDB.SaveChanges();
            return c;
        }

        public HSNSACVM GetHSNSACById(int HSNSACId)
        {
            DB.tblHSNSAC HSNSAC = IMSDB.tblHSNSACs.Where(p => p.HSNSACId == HSNSACId).FirstOrDefault();
            return new HSNSACVM()
            {
                HSNSACId = HSNSAC.HSNSACId,
                TaxRate = HSNSAC.TaxRate,
                HSNSACNo = HSNSAC.HSNSACNo,
                IsActive = HSNSAC.IsActive
            };

        }

        public IList<HSNSACVM> GetHSNSACList()
        {
            List<HSNSACVM> HSNSACList = new List<HSNSACVM>();
            IMSDB.tblHSNSACs.ToList().ForEach(p => HSNSACList.Add(
                    new HSNSACVM()
                    {
                        HSNSACId = p.HSNSACId,
                        TaxRate = p.TaxRate,
                        HSNSACNo = p.HSNSACNo,
                        IsActive = p.IsActive
                    }
                    ));
            return HSNSACList;
        }
    }
}
