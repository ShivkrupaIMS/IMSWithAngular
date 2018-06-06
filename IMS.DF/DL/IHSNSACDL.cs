using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IHSNSACDL
    {
        IList<HSNSACVM> GetHSNSACList();
        HSNSACVM AddHSNSAC(HSNSACVM c);
        HSNSACVM EditHSNSAC(HSNSACVM c);
        int DeleteHSNSAC(int HSNSACId);
        HSNSACVM GetHSNSACById(int id);
    }
}
