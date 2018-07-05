using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IGSTRegistrationTypeDL
    {
        IList<GSTRegistrationTypeVM> GetGSTRegistrationTypeList();
        GSTRegistrationTypeVM AddGSTRegistrationType(GSTRegistrationTypeVM c);
        GSTRegistrationTypeVM EditGSTRegistrationType(GSTRegistrationTypeVM c);
        int DeleteGSTRegistrationType(int GSTRegistrationTypeId);
        GSTRegistrationTypeVM GetGSTRegistrationTypeById(int id);
    }
}
