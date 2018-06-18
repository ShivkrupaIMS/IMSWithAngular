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
    public class LicenseTypeDL : BaseDL, ILicenseTypeDL
    {
        public LicenseTypeVM AddLicenseType(LicenseTypeVM c)
        {
            DB.tblLicenseType LicenseType = IMSDB.tblLicenseTypes.Add(
                new DB.tblLicenseType
                {
                    LicenseType = c.LicenseType,
                    Description = c.Description,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.LicenseTypeId = LicenseType.LicenseTypeId;
            return c;
        }

        public int DeleteLicenseType(int LicenseTypeId)
        {
            IMSDB.tblLicenseTypes.Remove(IMSDB.tblLicenseTypes.Where(p => p.LicenseTypeId == LicenseTypeId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public LicenseTypeVM EditLicenseType(LicenseTypeVM c)
        {
            DB.tblLicenseType LicenseType = IMSDB.tblLicenseTypes.Find(c.LicenseTypeId);
            if (LicenseType != null)
            {
                LicenseType.LicenseType = c.LicenseType;
                LicenseType.Description = c.Description;
                LicenseType.IsActive = c.IsActive;
                IMSDB.Entry(LicenseType).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public LicenseTypeVM GetLicenseTypeById(int LicenseTypeId)
        {
            DB.tblLicenseType LicenseType = IMSDB.tblLicenseTypes.Where(p => p.LicenseTypeId == LicenseTypeId).FirstOrDefault();
            if (LicenseType != null)
            {
                return new LicenseTypeVM()
                {
                    LicenseTypeId = LicenseType.LicenseTypeId,
                    LicenseType = LicenseType.LicenseType,
                    Description = LicenseType.Description,
                    IsActive = LicenseType.IsActive
                };
            }

            return null;
        }

        public IList<LicenseTypeVM> GetLicenseTypeList()
        {
            List<LicenseTypeVM> LicenseTypeList = new List<LicenseTypeVM>();
            List<DB.tblLicenseType> LicenseTypes = IMSDB.tblLicenseTypes.ToList();
            if (LicenseTypes != null)
            {
                LicenseTypes.ForEach(p => LicenseTypeList.Add(
                    new LicenseTypeVM()
                    {
                        LicenseTypeId = p.LicenseTypeId,
                        LicenseType = p.LicenseType,
                        Description = p.Description,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return LicenseTypeList;
        }
    }
}
