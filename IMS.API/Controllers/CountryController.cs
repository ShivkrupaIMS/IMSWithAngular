using IMS.DF.BL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IMS.API.Controllers
{
    
    public class CountryController : ApiController
    {
        private ICountryBL _countryBL;

        public CountryController(ICountryBL countryBL)
        {
            _countryBL = countryBL;
        }

        [HttpPost]
        public CountryVM AddCountry(CountryVM c)
        {
            return _countryBL.AddCountry(c);
        }
        [HttpPost]
        public int DeleteCountry(CountryVM c)
        {
            return _countryBL.DeleteCountry(c.CountryId);
        }
        [HttpPost]
        public CountryVM EditCountry(CountryVM c )
        {
            return _countryBL.EditCountry(c);
        }

        public CountryVM GetCountryById(int countryId)
        {
            return _countryBL.GetCountryById(countryId);
        }

        public IList<CountryVM> GetCountryList()
        {
            return _countryBL.GetCountryList();
        }
    }
}
