using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface ISupplierTypeDL
    {
        IList<SupplierTypeVM> GetSupplierTypeList();
        SupplierTypeVM AddSupplierType(SupplierTypeVM c);
        SupplierTypeVM EditSupplierType(SupplierTypeVM c);
        int DeleteSupplierType(int SupplierTypeId);
        SupplierTypeVM GetSupplierTypeById(int id);
    }
}
