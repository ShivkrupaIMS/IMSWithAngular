using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface ICityDL
    {
        IList<CityVM> GetCityList();
        CityVM AddCity(CityVM c);
        CityVM EditCity(CityVM c);
        int DeleteCity(int CityId);
        CityVM GetCityById(int id);
    }
}
