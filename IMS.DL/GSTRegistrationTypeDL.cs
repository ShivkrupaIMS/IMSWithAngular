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
    public class GSTRegistrationTypeDL : BaseDL, IGSTRegistrationTypeDL
    {
        public GSTRegistrationTypeVM AddGSTRegistrationType(GSTRegistrationTypeVM c)
        {
            DB.tblGSTRegistrationType GSTRegistrationType = IMSDB.tblGSTRegistrationTypes.Add(
                new DB.tblGSTRegistrationType
                {
                    GSTRegistrationType = c.GSTRegistrationType,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.GSTRegistrationTypeId = GSTRegistrationType.GSTRegistrationTypeId;
            return c;
        }

        public int DeleteGSTRegistrationType(int GSTRegistrationTypeId)
        {
            IMSDB.tblGSTRegistrationTypes.Remove(IMSDB.tblGSTRegistrationTypes.Where(p => p.GSTRegistrationTypeId == GSTRegistrationTypeId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public GSTRegistrationTypeVM EditGSTRegistrationType(GSTRegistrationTypeVM c)
        {
            DB.tblGSTRegistrationType GSTRegistrationType = IMSDB.tblGSTRegistrationTypes.Find(c.GSTRegistrationTypeId);
            if (GSTRegistrationType != null)
            {
                GSTRegistrationType.GSTRegistrationType = c.GSTRegistrationType;
                GSTRegistrationType.IsActive = c.IsActive;
                IMSDB.Entry(GSTRegistrationType).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public GSTRegistrationTypeVM GetGSTRegistrationTypeById(int GSTRegistrationTypeId)
        {
            DB.tblGSTRegistrationType GSTRegistrationType = IMSDB.tblGSTRegistrationTypes.Where(p => p.GSTRegistrationTypeId == GSTRegistrationTypeId).FirstOrDefault();
            if (GSTRegistrationType != null)
            {
                return new GSTRegistrationTypeVM()
                {
                    GSTRegistrationTypeId = GSTRegistrationType.GSTRegistrationTypeId,
                    GSTRegistrationType = GSTRegistrationType.GSTRegistrationType,
                    IsActive = GSTRegistrationType.IsActive
                };
            }

            return null;
        }

        public IList<GSTRegistrationTypeVM> GetGSTRegistrationTypeList()
        {
            List<GSTRegistrationTypeVM> GSTRegistrationTypeList = new List<GSTRegistrationTypeVM>();
            List<DB.tblGSTRegistrationType> GSTRegistrationTypes = IMSDB.tblGSTRegistrationTypes.ToList();
            if (GSTRegistrationTypes != null)
            {
                GSTRegistrationTypes.ForEach(p => GSTRegistrationTypeList.Add(
                    new GSTRegistrationTypeVM()
                    {
                        GSTRegistrationTypeId = p.GSTRegistrationTypeId,
                        GSTRegistrationType = p.GSTRegistrationType,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return GSTRegistrationTypeList;
        }
    }
}
