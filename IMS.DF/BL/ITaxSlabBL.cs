using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface ITaxSlabBL
    {
        IList<TaxSlabVM> GetTaxSlabList();
        TaxSlabVM AddTaxSlab(TaxSlabVM c);
        TaxSlabVM EditTaxSlab(TaxSlabVM c);
        int DeleteTaxSlab(int TaxSlabId);
        TaxSlabVM GetTaxSlabById(int id);
    }
}
