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
    public class CompanyDL : BaseDL, ICompanyDL
    {
        public CompanyVM AddCompany(CompanyVM c)
        {
            DB.tblCompany Company = IMSDB.tblCompanies.Add(
                new DB.tblCompany
                {
                    CompanyName = c.CompanyName,
                    Address = c.Address,
                    Phone = c.Phone,
                    Fax = c.Fax,
                    Email= c.Email,
                    Website=c.Website,
                    MobileNo =c.MobileNo,
                    GSTNo = c.GSTNo,
                    CINNo = c.CINNo,
                    PANNo=c.PANNo,
                    PinCode = c.PinCode,
                    CompanyTypeId = c.CompanyType.CompanyTypeId,
                    CountryId = c.Country.CountryId,
                    StateId = c.State.StateId,
                    BookStartDate= c.BookStartDate,
                    FYStartDate = c.FYStartDate,
                    Branch = c.Branch,
                    ContactPerson = c.ContactPerson,                    
                    IsActive = c.IsActive
                });

            c.Licenses.ForEach(p =>
                IMSDB.tblCompanyLicenseDetails.Add(
                    new DB.tblCompanyLicenseDetail
                    {
                        LicenseNo = p.LicenseNo,
                        LicenseTypeId = p.License.LicenseTypeId,
                        ValidFrom = p.ValidFrom,
                        ValidTo = p.ValidTo,
                        IsActive = p.IsActive,
                        tblCompany = Company
                    })
                );
            IMSDB.SaveChanges();
            c.CompanyId = Company.CompanyId;
            return c;
        }

        public int DeleteCompany(int CompanyId)
        {
            IMSDB.tblCompanyLicenseDetails.RemoveRange(IMSDB.tblCompanyLicenseDetails.Where(p => p.CompanyId == CompanyId));
            IMSDB.tblCompanies.Remove(IMSDB.tblCompanies.Where(p => p.CompanyId == CompanyId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public CompanyVM EditCompany(CompanyVM c)
        {
            DB.tblCompany Company = IMSDB.tblCompanies.Find(c.CompanyId);
            if (Company != null)
            {
                IMSDB.tblCompanyLicenseDetails.RemoveRange(IMSDB.tblCompanyLicenseDetails.Where(p => p.CompanyId == c.CompanyId));

                Company.CompanyName = c.CompanyName;
                Company.Address = c.Address;
                Company.Phone = c.Phone;
                Company.Fax = c.Fax;
                Company.Email = c.Email;
                Company.Website = c.Website;
                Company.MobileNo = c.MobileNo;
                Company.GSTNo = c.GSTNo;
                Company.CINNo = c.CINNo;
                Company.PANNo = c.PANNo;
                Company.PinCode = c.PinCode;
                Company.CompanyTypeId = c.CompanyType.CompanyTypeId;
                Company.CountryId = c.Country.CountryId;
                Company.StateId = c.State.StateId;
                Company.BookStartDate = c.BookStartDate;
                Company.FYStartDate = c.FYStartDate;
                Company.Branch = c.Branch;
                Company.ContactPerson = c.ContactPerson;
                Company.IsActive = c.IsActive;

                c.Licenses.ForEach(p =>
                IMSDB.tblCompanyLicenseDetails.Add(
                    new DB.tblCompanyLicenseDetail
                    {
                        LicenseNo = p.LicenseNo,
                        LicenseTypeId = p.License.LicenseTypeId,
                        ValidFrom = p.ValidFrom,
                        ValidTo = p.ValidTo,
                        IsActive = p.IsActive,
                        tblCompany = Company
                    })
                );

                IMSDB.Entry(Company).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public CompanyVM GetCompanyById(int CompanyId)
        {
            DB.tblCompany Company = IMSDB.tblCompanies.Where(p => p.CompanyId == CompanyId).FirstOrDefault();
            if (Company != null)
            {
                return new CompanyVM()
                {
                    CompanyName =Company.CompanyName,
                    Address =Company.Address,
                    Phone =Company.Phone,
                    Fax =Company.Fax,
                    Email =Company.Email,
                    Website =Company.Website,
                    MobileNo =Company.MobileNo,
                    GSTNo =Company.GSTNo,
                    CINNo =Company.CINNo,
                    PANNo =Company.PANNo,
                    PinCode =Company.PinCode,
                    CompanyType =new CompanyTypeVM { CompanyTypeId = Company.tblCompanyType.CompanyTypeId, CompanyType = Company.tblCompanyType.CompanyType, IsActive = Company.tblCompanyType.IsActive },
                    Country = new CountryVM { CountryId = Company.tblCountry.CountryId, CountryName = Company.tblCountry.CountryName, CountryCode = Company.tblCountry.CountryCode, IsActive = Company.tblCountry.IsActive },
                    State = new StateVM { StateId = Company.tblState.StateId, StateName = Company.tblState.StateName, IsActive = Company.tblState.IsActive },
                    BookStartDate = Company.BookStartDate,
                    FYStartDate = Company.FYStartDate,
                    Branch =Company.Branch,
                    ContactPerson =Company.ContactPerson,
                    IsActive =Company.IsActive
                };
            }
            return null;

        }

        public IList<CompanyVM> GetCompanyList()
        {
            List<CompanyVM> CompanyList = new List<CompanyVM>();
            List<DB.tblCompany> companies = IMSDB.tblCompanies.ToList();
            if (companies != null)
            {
                companies.ForEach(Company => CompanyList.Add(
                    new CompanyVM()
                    {
                        CompanyName = Company.CompanyName,
                        Address = Company.Address,
                        Phone = Company.Phone,
                        Fax = Company.Fax,
                        Email = Company.Email,
                        Website = Company.Website,
                        MobileNo = Company.MobileNo,
                        GSTNo = Company.GSTNo,
                        CINNo = Company.CINNo,
                        PANNo = Company.PANNo,
                        PinCode = Company.PinCode,
                        CompanyType = new CompanyTypeVM { CompanyTypeId = Company.tblCompanyType.CompanyTypeId, CompanyType = Company.tblCompanyType.CompanyType, IsActive = Company.tblCompanyType.IsActive },
                        Country = new CountryVM { CountryId = Company.tblCountry.CountryId, CountryName = Company.tblCountry.CountryName, CountryCode = Company.tblCountry.CountryCode, IsActive = Company.tblCountry.IsActive },
                        State = new StateVM { StateId = Company.tblState.StateId, StateName = Company.tblState.StateName, IsActive = Company.tblState.IsActive },
                        BookStartDate = Company.BookStartDate,
                        FYStartDate = Company.FYStartDate,
                        Branch = Company.Branch,
                        ContactPerson = Company.ContactPerson,
                        IsActive = Company.IsActive
                    }
                    ));
            }

            return CompanyList;
        }
    }
}
