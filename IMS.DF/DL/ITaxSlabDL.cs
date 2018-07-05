using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface ITaxSlabDL
    {
        IList<TaxSlabVM> GetTaxSlabList();
        TaxSlabVM AddTaxSlab(TaxSlabVM c);
        TaxSlabVM EditTaxSlab(TaxSlabVM c);
        int DeleteTaxSlab(int TaxSlabId);
        TaxSlabVM GetTaxSlabById(int id);
    }
}
