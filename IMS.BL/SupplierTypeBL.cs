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
    public class SupplierTypeBL : ISupplierTypeBL
    {
        private ISupplierTypeDL _SupplierTypeDL;

        public SupplierTypeBL(ISupplierTypeDL SupplierTypeDL)
        {
            _SupplierTypeDL = SupplierTypeDL;
        }

        public SupplierTypeVM AddSupplierType(SupplierTypeVM c)
        {
            return _SupplierTypeDL.AddSupplierType(c);
        }

        public int DeleteSupplierType(int SupplierTypeId)
        {
            return _SupplierTypeDL.DeleteSupplierType(SupplierTypeId);
        }

        public SupplierTypeVM EditSupplierType(SupplierTypeVM c)
        {
            return _SupplierTypeDL.EditSupplierType(c);
        }

        public SupplierTypeVM GetSupplierTypeById(int SupplierTypeId)
        {
            return _SupplierTypeDL.GetSupplierTypeById(SupplierTypeId);
        }

        public IList<SupplierTypeVM> GetSupplierTypeList()
        {
            return _SupplierTypeDL.GetSupplierTypeList();
        }
    }
}
