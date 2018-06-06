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
    public class HSNSACController : ApiController
    {
        private IHSNSACBL _HSNSACBL;

        public HSNSACController(IHSNSACBL HSNSACBL)
        {
            _HSNSACBL = HSNSACBL;
        }

        [HttpPost]
        public HSNSACVM AddHSNSAC(HSNSACVM c)
        {
            return _HSNSACBL.AddHSNSAC(c);
        }
        [HttpPost]
        public int DeleteHSNSAC(HSNSACVM c)
        {
            return _HSNSACBL.DeleteHSNSAC(c.HSNSACId);
        }
        [HttpPost]
        public HSNSACVM EditHSNSAC(HSNSACVM c)
        {
            return _HSNSACBL.EditHSNSAC(c);
        }

        public HSNSACVM GetHSNSACById(int HSNSACId)
        {
            return _HSNSACBL.GetHSNSACById(HSNSACId);
        }

        public IList<HSNSACVM> GetHSNSACList()
        {
            return _HSNSACBL.GetHSNSACList();
        }
    }
}
