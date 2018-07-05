using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface ICustomerTypeDL
    {
        IList<CustomerTypeVM> GetCustomerTypeList();
        CustomerTypeVM AddCustomerType(CustomerTypeVM c);
        CustomerTypeVM EditCustomerType(CustomerTypeVM c);
        int DeleteCustomerType(int CustomerTypeId);
        CustomerTypeVM GetCustomerTypeById(int id);
    }
}
