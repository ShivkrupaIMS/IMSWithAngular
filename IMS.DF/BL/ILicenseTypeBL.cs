using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface ILicenseTypeBL
    {
        IList<LicenseTypeVM> GetLicenseTypeList();
        LicenseTypeVM AddLicenseType(LicenseTypeVM c);
        LicenseTypeVM EditLicenseType(LicenseTypeVM c);
        int DeleteLicenseType(int LicenseTypeId);
        LicenseTypeVM GetLicenseTypeById(int id);
    }
}
