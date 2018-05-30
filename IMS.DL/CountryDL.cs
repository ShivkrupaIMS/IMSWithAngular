using IMS.DF.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.VM;
using System.Data.Entity;

namespace IMS.DL
{
    public class CountryDL :BaseDL, ICountryDL
    {
        public CountryVM AddCountry(CountryVM c)
        {
            DB.tblCountry country = IMSDB.tblCountries.Add(
                new DB.tblCountry
                {
                    CountryCode = c.CountryCode,
                    CountryName = c.CountryName,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.CountryId = country.CountryId;
            return c;
        }

        public int DeleteCountry(int countryId)
        {
            IMSDB.tblCountries.Remove(IMSDB.tblCountries.Where(p => p.CountryId == countryId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public CountryVM EditCountry(CountryVM c)
        {
            DB.tblCountry country = IMSDB.tblCountries.Find(c.CountryId);
            country.CountryName = c.CountryName;
            country.CountryCode = c.CountryCode;
            country.IsActive = c.IsActive;
            IMSDB.Entry(country).State = EntityState.Modified;
            IMSDB.SaveChanges();
            return c;
        }

        public CountryVM GetCountryById(int countryId)
        {
           DB.tblCountry country = IMSDB.tblCountries.Where(p => p.CountryId == countryId).FirstOrDefault();
            return new CountryVM()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                CountryCode = country.CountryCode,
                IsActive = country.IsActive
            };
                    
        }

        public IList<CountryVM> GetCountryList()
        {
            List<CountryVM> countryList = new List<CountryVM>();
            IMSDB.tblCountries.ToList().ForEach(p => countryList.Add(
                    new CountryVM()
                    {
                        CountryId = p.CountryId,
                        CountryName = p.CountryName,
                        CountryCode = p.CountryCode,
                        IsActive = p.IsActive
                    }
                    ));
            return countryList;
        }
    }
}
