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
    public class SupplierTypeDL : BaseDL, ISupplierTypeDL
    {
        public SupplierTypeVM AddSupplierType(SupplierTypeVM c)
        {
            DB.tblSupplierType SupplierType = IMSDB.tblSupplierTypes.Add(
                new DB.tblSupplierType
                {
                    SupplierType = c.SupplierType,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.SupplierTypeId = SupplierType.SupplierTypeId;
            return c;
        }

        public int DeleteSupplierType(int SupplierTypeId)
        {
            IMSDB.tblSupplierTypes.Remove(IMSDB.tblSupplierTypes.Where(p => p.SupplierTypeId == SupplierTypeId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public SupplierTypeVM EditSupplierType(SupplierTypeVM c)
        {
            DB.tblSupplierType SupplierType = IMSDB.tblSupplierTypes.Find(c.SupplierTypeId);
            if (SupplierType != null)
            {
                SupplierType.SupplierType = c.SupplierType;
                SupplierType.IsActive = c.IsActive;
                IMSDB.Entry(SupplierType).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public SupplierTypeVM GetSupplierTypeById(int SupplierTypeId)
        {
            DB.tblSupplierType SupplierType = IMSDB.tblSupplierTypes.Where(p => p.SupplierTypeId == SupplierTypeId).FirstOrDefault();
            if (SupplierType != null)
            {
                return new SupplierTypeVM()
                {
                    SupplierTypeId = SupplierType.SupplierTypeId,
                    SupplierType = SupplierType.SupplierType,
                    IsActive = SupplierType.IsActive
                };
            }

            return null;
        }

        public IList<SupplierTypeVM> GetSupplierTypeList()
        {
            List<SupplierTypeVM> SupplierTypeList = new List<SupplierTypeVM>();
            List<DB.tblSupplierType> SupplierTypes = IMSDB.tblSupplierTypes.ToList();
            if (SupplierTypes != null)
            {
                SupplierTypes.ForEach(p => SupplierTypeList.Add(
                    new SupplierTypeVM()
                    {
                        SupplierTypeId = p.SupplierTypeId,
                        SupplierType = p.SupplierType,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return SupplierTypeList;
        }
    }
}
