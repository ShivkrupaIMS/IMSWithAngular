using IMS.DF.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.VM;
using IMS.DF.DL;

namespace IMS.BL
{
    public class CountryBL : ICountryBL
    {
        private ICountryDL _countryDL;

        public CountryBL(ICountryDL countryDL)
        {
            _countryDL = countryDL;
        }

        public CountryVM AddCountry(CountryVM c)
        {
           return _countryDL.AddCountry(c);
        }

        public int DeleteCountry(int countryId)
        {
            return _countryDL.DeleteCountry(countryId);
        }

        public CountryVM EditCountry(CountryVM c)
        {
           return _countryDL.EditCountry(c);
        }

        public CountryVM GetCountryById(int countryId)
        {
            return _countryDL.GetCountryById(countryId);
        }

        public IList<CountryVM> GetCountryList()
        {
            return _countryDL.GetCountryList();
        }
    }
}
