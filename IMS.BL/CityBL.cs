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
    public class CityBL:ICityBL
    {
        private ICityDL _CityDL;

        public CityBL(ICityDL CityDL)
        {
            _CityDL = CityDL;
        }

        public CityVM AddCity(CityVM c)
        {
            return _CityDL.AddCity(c);
        }

        public int DeleteCity(int CityId)
        {
            return _CityDL.DeleteCity(CityId);
        }

        public CityVM EditCity(CityVM c)
        {
            return _CityDL.EditCity(c);
        }

        public CityVM GetCityById(int CityId)
        {
            return _CityDL.GetCityById(CityId);
        }

        public IList<CityVM> GetCityList()
        {
            return _CityDL.GetCityList();
        }
    }
}
