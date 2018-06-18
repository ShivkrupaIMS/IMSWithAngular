using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL
{
    public class CityDL : BaseDL, ICityDL
    {
        public CityVM AddCity(CityVM c)
        {
            DB.tblCity City = IMSDB.tblCities.Add(
                new DB.tblCity
                {
                    //CityCode = c.CityCode,
                    CityName = c.CityName,
                    StateId = c.State.StateId,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.CityId = City.CityId;
            return c;
        }

        public int DeleteCity(int CityId)
        {
            IMSDB.tblCities.Remove(IMSDB.tblCities.Where(p => p.CityId == CityId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public CityVM EditCity(CityVM c)
        {
            DB.tblCity City = IMSDB.tblCities.Find(c.CityId);
            if (City != null)
            {
                City.CityName = c.CityName;
                City.StateId = c.State.StateId;
                //City.CityCode = c.CityCode;
                City.IsActive = c.IsActive;
                IMSDB.Entry(City).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public CityVM GetCityById(int CityId)
        {
            DB.tblCity City = IMSDB.tblCities.Where(p => p.CityId == CityId).FirstOrDefault();
            if (City != null)
            {
                return new CityVM()
                {
                    CityId = City.CityId,
                    CityName = City.CityName,
                    //CityCode = City.CityCode,
                    State = new StateVM { StateId = City.tblState.StateId, StateName = City.tblState.StateName, IsActive = City.tblState.IsActive },
                    IsActive = City.IsActive
                };
            }

            return null;
        }

        public IList<CityVM> GetCityList()
        {
            List<CityVM> CityList = new List<CityVM>();
            List<DB.tblCity> cities = IMSDB.tblCities.ToList();
            if (cities != null)
            {
                cities.ForEach(p => CityList.Add(
                    new CityVM()
                    {
                        CityId = p.CityId,
                        CityName = p.CityName,
                        //CityCode = p.CityCode,
                        State = new StateVM { StateId = p.tblState.StateId, StateName = p.tblState.StateName, IsActive = p.tblState.IsActive },
                        IsActive = p.IsActive
                    }
                    ));
            }
            
            return CityList;
        }
    }
}
