using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface ICountryBL
    {
        IList<CountryVM> GetCountryList();
        CountryVM AddCountry(CountryVM c);
        CountryVM EditCountry(CountryVM c);
        int DeleteCountry(int countryId);
        CountryVM GetCountryById(int id);
    }
}
