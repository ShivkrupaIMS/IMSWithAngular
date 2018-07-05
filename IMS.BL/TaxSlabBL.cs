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
    public class TaxSlabBL : ITaxSlabBL
    {
        private ITaxSlabDL _TaxSlabDL;

        public TaxSlabBL(ITaxSlabDL TaxSlabDL)
        {
            _TaxSlabDL = TaxSlabDL;
        }

        public TaxSlabVM AddTaxSlab(TaxSlabVM c)
        {
            return _TaxSlabDL.AddTaxSlab(c);
        }

        public int DeleteTaxSlab(int TaxSlabId)
        {
            return _TaxSlabDL.DeleteTaxSlab(TaxSlabId);
        }

        public TaxSlabVM EditTaxSlab(TaxSlabVM c)
        {
            return _TaxSlabDL.EditTaxSlab(c);
        }

        public TaxSlabVM GetTaxSlabById(int TaxSlabId)
        {
            return _TaxSlabDL.GetTaxSlabById(TaxSlabId);
        }

        public IList<TaxSlabVM> GetTaxSlabList()
        {
            return _TaxSlabDL.GetTaxSlabList();
        }
    }
}
