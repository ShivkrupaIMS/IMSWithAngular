using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IManufacturerDL
    {
        IList<ManufacturerVM> GetManufacturerList();
        ManufacturerVM AddManufacturer(ManufacturerVM c);
        ManufacturerVM EditManufacturer(ManufacturerVM c);
        int DeleteManufacturer(int ManufacturerId);
        ManufacturerVM GetManufacturerById(int id);
    }
}
