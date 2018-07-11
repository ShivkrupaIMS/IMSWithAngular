// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace IMS.API.DependencyResolution {
    using BL;
    using DF.BL;
    using DF.DL;
    using DL;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.Assembly("IMS.DL");
                    scan.Assembly("IMS.BL");
                });
            For<ICountryDL>().Use<CountryDL>();
            For<ICountryBL>().Use<CountryBL>();
            For<IStateDL>().Use<StateDL>();
            For<IStateBL>().Use<StateBL>();
            For<ICityDL>().Use<CityDL>();
            For<ICityBL>().Use<CityBL>();
            For<IItemTypeDL>().Use<ItemTypeDL>();
            For<IItemTypeBL>().Use<ItemTypeBL>();
            For<IItemUnitDL>().Use<ItemUnitDL>();
            For<IItemUnitBL>().Use<ItemUnitBL>();
            For<ICompanyTypeDL>().Use<CompanyTypeDL>();
            For<ICompanyTypeBL>().Use<CompanyTypeBL>();
            For<IHSNSACDL>().Use<HSNSACDL>();
            For<IHSNSACBL>().Use<HSNSACBL>();
            For<ILicenseTypeBL>().Use<LicenseTypeBL>();
            For<ILicenseTypeDL>().Use<LicenseTypeDL>();
            For<IAccountingMethodBL>().Use<AccountingMethodBL>();
            For<IAccountingMethodDL>().Use<AccountingMethodDL>();
            For<ICompanyBL>().Use<CompanyBL>();
            For<ICompanyDL>().Use<CompanyDL>();
            For<ICustomerTypeBL>().Use<CustomerTypeBL>();
            For<ICustomerTypeDL>().Use<CustomerTypeDL>();
            For<IGSTRegistrationTypeBL>().Use<GSTRegistrationTypeBL>();
            For<IGSTRegistrationTypeDL>().Use<GSTRegistrationTypeDL>();
            For<IInvoiceStatusBL>().Use<InvoiceStatusBL>();
            For<IInvoiceStatusDL>().Use<InvoiceStatusDL>();
            For<IInvoiceTermBL>().Use<InvoiceTermBL>();
            For<IInvoiceTermDL>().Use<InvoiceTermDL>();
            For<IInvoiceTypeBL>().Use<InvoiceTypeBL>();
            For<IInvoiceTypeDL>().Use<InvoiceTypeDL>();
            For<IItemBL>().Use<ItemBL>();
            For<IItemDL>().Use<ItemDL>();
            For<IManufacturerBL>().Use<ManufacturerBL>();
            For<IManufacturerDL>().Use<ManufacturerDL>();
            For<ISupplierTypeBL>().Use<SupplierTypeBL>();
            For<ISupplierTypeDL>().Use<SupplierTypeDL>();
            For<ITaxSlabBL>().Use<TaxSlabBL>();
            For<ITaxSlabDL>().Use<TaxSlabDL>();
        }

        #endregion
    }
}