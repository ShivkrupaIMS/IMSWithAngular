using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL
{
    public class CustomerTypeDL : BaseDL, ICustomerTypeDL
    {
        public CustomerTypeVM AddCustomerType(CustomerTypeVM c)
        {
            DB.tblCustomerType CustomerType = IMSDB.tblCustomerTypes.Add(
                new DB.tblCustomerType
                {
                    CustomerType = c.CustomerType,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.CustomerTypeId = CustomerType.CustomerTypeId;
            return c;
        }

        public int DeleteCustomerType(int CustomerTypeId)
        {
            IMSDB.tblCustomerTypes.Remove(IMSDB.tblCustomerTypes.Where(p => p.CustomerTypeId == CustomerTypeId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public CustomerTypeVM EditCustomerType(CustomerTypeVM c)
        {
            DB.tblCustomerType CustomerType = IMSDB.tblCustomerTypes.Find(c.CustomerTypeId);
            if (CustomerType != null)
            {
                CustomerType.CustomerType = c.CustomerType;
                CustomerType.IsActive = c.IsActive;
                IMSDB.Entry(CustomerType).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public CustomerTypeVM GetCustomerTypeById(int CustomerTypeId)
        {
            DB.tblCustomerType CustomerType = IMSDB.tblCustomerTypes.Where(p => p.CustomerTypeId == CustomerTypeId).FirstOrDefault();
            if (CustomerType != null)
            {
                return new CustomerTypeVM()
                {
                    CustomerTypeId = CustomerType.CustomerTypeId,
                    CustomerType = CustomerType.CustomerType,
                    IsActive = CustomerType.IsActive
                };
            }

            return null;
        }

        public IList<CustomerTypeVM> GetCustomerTypeList()
        {
            List<CustomerTypeVM> CustomerTypeList = new List<CustomerTypeVM>();
            List<DB.tblCustomerType> CustomerTypes = IMSDB.tblCustomerTypes.ToList();
            if (CustomerTypes != null)
            {
                CustomerTypes.ForEach(p => CustomerTypeList.Add(
                    new CustomerTypeVM()
                    {
                        CustomerTypeId = p.CustomerTypeId,
                        CustomerType = p.CustomerType,
                        IsActive = p.IsActive
                    }
                    ));
            }

            return CustomerTypeList;
        }
    }
}
