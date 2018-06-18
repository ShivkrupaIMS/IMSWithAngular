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
    class LicenseTypeBL : ILicenseTypeBL
    {
        private ILicenseTypeDL _LicenseTypeDL;

        public LicenseTypeBL(ILicenseTypeDL LicenseTypeDL)
        {
            _LicenseTypeDL = LicenseTypeDL;
        }

        public LicenseTypeVM AddLicenseType(LicenseTypeVM c)
        {
            return _LicenseTypeDL.AddLicenseType(c);
        }

        public int DeleteLicenseType(int LicenseTypeId)
        {
            return _LicenseTypeDL.DeleteLicenseType(LicenseTypeId);
        }

        public LicenseTypeVM EditLicenseType(LicenseTypeVM c)
        {
            return _LicenseTypeDL.EditLicenseType(c);
        }

        public LicenseTypeVM GetLicenseTypeById(int LicenseTypeId)
        {
            return _LicenseTypeDL.GetLicenseTypeById(LicenseTypeId);
        }

        public IList<LicenseTypeVM> GetLicenseTypeList()
        {
            return _LicenseTypeDL.GetLicenseTypeList();
        }
    }
}
