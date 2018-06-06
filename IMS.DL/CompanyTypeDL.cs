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
    public class CompanyTypeDL : BaseDL, ICompanyTypeDL
    {
        public CompanyTypeVM AddCompanyType(CompanyTypeVM c)
        {
            DB.tblCompanyType CompanyType = IMSDB.tblCompanyTypes.Add(
                new DB.tblCompanyType
                {
                    CompanyType = c.CompanyType,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.CompanyTypeId = CompanyType.CompanyTypeId;
            return c;
        }

        public int DeleteCompanyType(int CompanyTypeId)
        {
            IMSDB.tblCompanyTypes.Remove(IMSDB.tblCompanyTypes.Where(p => p.CompanyTypeId == CompanyTypeId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public CompanyTypeVM EditCompanyType(CompanyTypeVM c)
        {
            DB.tblCompanyType CompanyType = IMSDB.tblCompanyTypes.Find(c.CompanyTypeId);
            CompanyType.CompanyType = c.CompanyType;
            CompanyType.IsActive = c.IsActive;
            IMSDB.Entry(CompanyType).State = EntityState.Modified;
            IMSDB.SaveChanges();
            return c;
        }

        public CompanyTypeVM GetCompanyTypeById(int CompanyTypeId)
        {
            DB.tblCompanyType CompanyType = IMSDB.tblCompanyTypes.Where(p => p.CompanyTypeId == CompanyTypeId).FirstOrDefault();
            return new CompanyTypeVM()
            {
                CompanyTypeId = CompanyType.CompanyTypeId,
                CompanyType = CompanyType.CompanyType,
                IsActive = CompanyType.IsActive
            };

        }

        public IList<CompanyTypeVM> GetCompanyTypeList()
        {
            List<CompanyTypeVM> companyTypeList = new List<CompanyTypeVM>();
            IMSDB.tblCompanyTypes.ToList().ForEach(p => companyTypeList.Add(
                    new CompanyTypeVM()
                    {
                        CompanyTypeId = p.CompanyTypeId,
                        CompanyType = p.CompanyType,
                        IsActive = p.IsActive
                    }
                    ));
            return companyTypeList;
        }
    }
}
