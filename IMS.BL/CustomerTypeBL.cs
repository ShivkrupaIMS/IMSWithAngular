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
    public class CustomerTypeBL : ICustomerTypeBL
    {
        private ICustomerTypeDL _CustomerTypeDL;

        public CustomerTypeBL(ICustomerTypeDL CustomerTypeDL)
        {
            _CustomerTypeDL = CustomerTypeDL;
        }

        public CustomerTypeVM AddCustomerType(CustomerTypeVM c)
        {
            return _CustomerTypeDL.AddCustomerType(c);
        }

        public int DeleteCustomerType(int CustomerTypeId)
        {
            return _CustomerTypeDL.DeleteCustomerType(CustomerTypeId);
        }

        public CustomerTypeVM EditCustomerType(CustomerTypeVM c)
        {
            return _CustomerTypeDL.EditCustomerType(c);
        }

        public CustomerTypeVM GetCustomerTypeById(int CustomerTypeId)
        {
            return _CustomerTypeDL.GetCustomerTypeById(CustomerTypeId);
        }

        public IList<CustomerTypeVM> GetCustomerTypeList()
        {
            return _CustomerTypeDL.GetCustomerTypeList();
        }
    }
}
