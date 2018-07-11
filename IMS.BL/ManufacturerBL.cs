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
    public class ManufacturerBL : IManufacturerBL
    {
        private IManufacturerDL _ManufacturerDL;

        public ManufacturerBL(IManufacturerDL ManufacturerDL)
        {
            _ManufacturerDL = ManufacturerDL;
        }

        public ManufacturerVM AddManufacturer(ManufacturerVM c)
        {
            return _ManufacturerDL.AddManufacturer(c);
        }

        public int DeleteManufacturer(int ManufacturerId)
        {
            return _ManufacturerDL.DeleteManufacturer(ManufacturerId);
        }

        public ManufacturerVM EditManufacturer(ManufacturerVM c)
        {
            return _ManufacturerDL.EditManufacturer(c);
        }

        public ManufacturerVM GetManufacturerById(int ManufacturerId)
        {
            return _ManufacturerDL.GetManufacturerById(ManufacturerId);
        }

        public IList<ManufacturerVM> GetManufacturerList()
        {
            return _ManufacturerDL.GetManufacturerList();
        }
    }
}
