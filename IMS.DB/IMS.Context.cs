﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMS.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IMSEntities : DbContext
    {
        public IMSEntities()
            : base("name=IMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCountry> tblCountries { get; set; }
        public virtual DbSet<tblState> tblStates { get; set; }
        public virtual DbSet<tblCity> tblCities { get; set; }
        public virtual DbSet<tblCompanyType> tblCompanyTypes { get; set; }
        public virtual DbSet<tblItemType> tblItemTypes { get; set; }
        public virtual DbSet<tblItemUnit> tblItemUnits { get; set; }
        public virtual DbSet<tblHSNSAC> tblHSNSACs { get; set; }
        public virtual DbSet<tblAccountingMethod> tblAccountingMethods { get; set; }
        public virtual DbSet<tblCustomerType> tblCustomerTypes { get; set; }
        public virtual DbSet<tblGSTRegistrationType> tblGSTRegistrationTypes { get; set; }
        public virtual DbSet<tblInvoiceStatuses> tblInvoiceStatuses { get; set; }
        public virtual DbSet<tblLicenseType> tblLicenseTypes { get; set; }
        public virtual DbSet<tblManufacturer> tblManufacturers { get; set; }
        public virtual DbSet<tblSupplierType> tblSupplierTypes { get; set; }
        public virtual DbSet<tblTaxSlab> tblTaxSlabs { get; set; }
        public virtual DbSet<tblInvoiceTerm> tblInvoiceTerms { get; set; }
        public virtual DbSet<tblInvoiceType> tblInvoiceTypes { get; set; }
        public virtual DbSet<tblCompanyLicenseDetail> tblCompanyLicenseDetails { get; set; }
        public virtual DbSet<tblCompany> tblCompanies { get; set; }
        public virtual DbSet<tblItemLicenseDetail> tblItemLicenseDetails { get; set; }
        public virtual DbSet<tblItem> tblItems { get; set; }
        public virtual DbSet<tblItemDetail> tblItemDetails { get; set; }
    }
}
