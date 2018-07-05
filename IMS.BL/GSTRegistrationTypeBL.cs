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
    public class GSTRegistrationTypeBL : IGSTRegistrationTypeBL
    {
        private IGSTRegistrationTypeDL _GSTRegistrationTypeDL;

        public GSTRegistrationTypeBL(IGSTRegistrationTypeDL GSTRegistrationTypeDL)
        {
            _GSTRegistrationTypeDL = GSTRegistrationTypeDL;
        }

        public GSTRegistrationTypeVM AddGSTRegistrationType(GSTRegistrationTypeVM c)
        {
            return _GSTRegistrationTypeDL.AddGSTRegistrationType(c);
        }

        public int DeleteGSTRegistrationType(int GSTRegistrationTypeId)
        {
            return _GSTRegistrationTypeDL.DeleteGSTRegistrationType(GSTRegistrationTypeId);
        }

        public GSTRegistrationTypeVM EditGSTRegistrationType(GSTRegistrationTypeVM c)
        {
            return _GSTRegistrationTypeDL.EditGSTRegistrationType(c);
        }

        public GSTRegistrationTypeVM GetGSTRegistrationTypeById(int GSTRegistrationTypeId)
        {
            return _GSTRegistrationTypeDL.GetGSTRegistrationTypeById(GSTRegistrationTypeId);
        }

        public IList<GSTRegistrationTypeVM> GetGSTRegistrationTypeList()
        {
            return _GSTRegistrationTypeDL.GetGSTRegistrationTypeList();
        }
    }
}
