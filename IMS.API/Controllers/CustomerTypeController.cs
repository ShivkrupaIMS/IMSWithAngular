using IMS.DF.BL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS.API.Controllers
{
    public class CustomerTypeController : ApiController
    {
        private ICustomerTypeBL _CustomerTypeBL;

        public CustomerTypeController(ICustomerTypeBL CustomerTypeBL)
        {
            _CustomerTypeBL = CustomerTypeBL;
        }

        [HttpPost]
        public CustomerTypeVM AddCustomerType(CustomerTypeVM c)
        {
            return _CustomerTypeBL.AddCustomerType(c);
        }
        [HttpPost]
        public int DeleteCustomerType(CustomerTypeVM c)
        {
            return _CustomerTypeBL.DeleteCustomerType(c.CustomerTypeId);
        }
        [HttpPost]
        public CustomerTypeVM EditCustomerType(CustomerTypeVM c)
        {
            return _CustomerTypeBL.EditCustomerType(c);
        }

        public CustomerTypeVM GetCustomerTypeById(int CustomerTypeId)
        {
            return _CustomerTypeBL.GetCustomerTypeById(CustomerTypeId);
        }

        public IList<CustomerTypeVM> GetCustomerTypeList()
        {
            return _CustomerTypeBL.GetCustomerTypeList();
        }
    }
}
