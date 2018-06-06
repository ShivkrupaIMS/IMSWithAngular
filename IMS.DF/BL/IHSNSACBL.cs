using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface IHSNSACBL
    {
        IList<HSNSACVM> GetHSNSACList();
        HSNSACVM AddHSNSAC(HSNSACVM c);
        HSNSACVM EditHSNSAC(HSNSACVM c);
        int DeleteHSNSAC(int HSNSACId);
        HSNSACVM GetHSNSACById(int id);
    }
}
