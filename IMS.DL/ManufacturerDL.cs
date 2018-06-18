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
    public class ManufacturerDL : BaseDL, IManufacturerDL
    {
        public ManufacturerVM AddManufacturer(ManufacturerVM c)
        {
            DB.tblManufacturer Manufacturer = IMSDB.tblManufacturers.Add(
                new DB.tblManufacturer
                {
                    ManufacturerName = c.ManufacturerName,
                    Description = c.Description,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.ManufacturerId = Manufacturer.ManufacturerId;
            return c;
        }

        public int DeleteManufacturer(int ManufacturerId)
        {
            IMSDB.tblManufacturers.Remove(IMSDB.tblManufacturers.Where(p => p.ManufacturerId == ManufacturerId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public ManufacturerVM EditManufacturer(ManufacturerVM c)
        {
            DB.tblManufacturer Manufacturer = IMSDB.tblManufacturers.Find(c.ManufacturerId);
            if (Manufacturer != null)
            {
                Manufacturer.ManufacturerName = c.ManufacturerName;
                Manufacturer.Description = c.Description;
                Manufacturer.IsActive = c.IsActive;
                IMSDB.Entry(Manufacturer).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public ManufacturerVM GetManufacturerById(int ManufacturerId)
        {
            DB.tblManufacturer Manufacturer = IMSDB.tblManufacturers.Where(p => p.ManufacturerId == ManufacturerId).FirstOrDefault();
            if (Manufacturer != null)
            {
                return new ManufacturerVM()
                {
                    ManufacturerId = Manufacturer.ManufacturerId,
                    ManufacturerName = Manufacturer.ManufacturerName,
                    Description = Manufacturer.Description,
                    IsActive = Manufacturer.IsActive
                };
            }

            return null;
        }

        public IList<ManufacturerVM> GetManufacturerList()
        {
            List<ManufacturerVM> ManufacturerList = new List<ManufacturerVM>();
            List<DB.tblManufacturer> Manufacturers = IMSDB.tblManufacturers.ToList();
            if (Manufacturers != null)
            {
                Manufacturers.ForEach(p => ManufacturerList.Add(
                    new ManufacturerVM()
                    {
                        ManufacturerId = p.ManufacturerId,
                        ManufacturerName = p.ManufacturerName,
                        Description = p.Description,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return ManufacturerList;
        }
    }
}
