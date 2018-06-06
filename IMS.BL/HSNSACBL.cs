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
    public class HSNSACBL:IHSNSACBL
    {
        private IHSNSACDL _HSNSACDL;

        public HSNSACBL(IHSNSACDL HSNSACDL)
        {
            _HSNSACDL = HSNSACDL;
        }

        public HSNSACVM AddHSNSAC(HSNSACVM c)
        {
            return _HSNSACDL.AddHSNSAC(c);
        }

        public int DeleteHSNSAC(int HSNSACId)
        {
            return _HSNSACDL.DeleteHSNSAC(HSNSACId);
        }

        public HSNSACVM EditHSNSAC(HSNSACVM c)
        {
            return _HSNSACDL.EditHSNSAC(c);
        }

        public HSNSACVM GetHSNSACById(int HSNSACId)
        {
            return _HSNSACDL.GetHSNSACById(HSNSACId);
        }

        public IList<HSNSACVM> GetHSNSACList()
        {
            return _HSNSACDL.GetHSNSACList();
        }
    }
}
