using IMS.DF.BL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS.API.Controllers
{
    public class CityController : ApiController
    {
        private ICityBL _CityBL;

        public CityController(ICityBL CityBL)
        {
            _CityBL = CityBL;
        }

        [HttpPost]
        public CityVM AddCity(CityVM c)
        {
            return _CityBL.AddCity(c);
        }
        [HttpPost]
        public int DeleteCity(CityVM c)
        {
            return _CityBL.DeleteCity(c.CityId);
        }
        [HttpPost]
        public CityVM EditCity(CityVM c)
        {
            return _CityBL.EditCity(c);
        }

        public CityVM GetCityById(int CityId)
        {
            return _CityBL.GetCityById(CityId);
        }

        public IList<CityVM> GetCityList()
        {
            return _CityBL.GetCityList();
        }
    }
}
