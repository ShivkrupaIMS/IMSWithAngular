﻿var IMSApp = angular.module('IMSApp', ['ngRoute', 'ui.bootstrap']);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider
        .when("/home", {
            templateUrl: "app/Home.html",
            controller: "HomeController"
        })
        .when("/country", {
            templateUrl: "/app/country/countryList.html",
            controller: "countryController"
        })
        .when("/newCountry", {
            templateUrl: "/app/country/country.html",
            controller: "countryController"
        })
        .when("/updateCountry/:countryId", {
            templateUrl: "/app/country/country.html",
            controller: "countryController"
        })
        .when("/state", {
            templateUrl: "/app/state/stateList.html",
            controller: "stateController"
        })
        .when("/newState", {
            templateUrl: "/app/state/state.html",
            controller: "stateController"
        })
        .when("/updateState/:stateId", {
            templateUrl: "/app/state/state.html",
            controller: "stateController"
        })
        .when("/city", {
            templateUrl: "/app/city/cityList.html",
            controller: "cityController"
        })
        .when("/newCity", {
            templateUrl: "/app/city/city.html",
            controller: "cityController"
        })
        .when("/updateCity/:cityId", {
            templateUrl: "/app/city/city.html",
            controller: "cityController"
        })
        .when("/itemType", {
            templateUrl: "/app/itemType/itemTypeList.html",
            controller: "itemTypeController"
        })
        .when("/newItemType", {
            templateUrl: "/app/itemType/itemType.html",
            controller: "itemTypeController"
        })
        .when("/updateItemType/:itemTypeId", {
            templateUrl: "/app/itemType/itemType.html",
            controller: "itemTypeController"
        })
        .when("/licenseType", {
            templateUrl: "/app/licenseType/licenseTypeList.html",
            controller: "licenseTypeController"
        })
        .when("/newLicenseType", {
            templateUrl: "/app/licenseType/licenseType.html",
            controller: "licenseTypeController"
        })
        .when("/updateLicenseType/:licenseTypeId", {
            templateUrl: "/app/licenseType/licenseType.html",
            controller: "licenseTypeController"
        })
        .when("/taxSlab", {
            templateUrl: "/app/taxSlab/taxSlabList.html",
            controller: "taxSlabController"
        })
        .when("/newTaxSlab", {
            templateUrl: "/app/taxSlab/taxSlab.html",
            controller: "taxSlabController"
        })
        .when("/updateTaxSlab/:taxSlabId", {
            templateUrl: "/app/taxSlab/taxSlab.html",
            controller: "taxSlabController"
        })
        .when("/customerType", {
            templateUrl: "/app/customerType/customerTypeList.html",
            controller: "customerTypeController"
        })
        .when("/newCustomerType", {
            templateUrl: "/app/customerType/customerType.html",
            controller: "customerTypeController"
        })
        .when("/updateCustomerType/:customerTypeId", {
            templateUrl: "/app/customerType/customerType.html",
            controller: "customerTypeController"
        })
        .when("/invoiceStatus", {
            templateUrl: "/app/invoiceStatus/invoiceStatusList.html",
            controller: "invoiceStatusController"
        })
        .when("/newInvoiceStatus", {
            templateUrl: "/app/invoiceStatus/invoiceStatus.html",
            controller: "invoiceStatusController"
        })
        .when("/updateInvoiceStatus/:invoiceStatusId", {
            templateUrl: "/app/invoiceStatus/invoiceStatus.html",
            controller: "invoiceStatusController"
        })
        .when("/invoiceTerm", {
            templateUrl: "/app/invoiceTerm/invoiceTermList.html",
            controller: "invoiceTermController"
        })
        .when("/newInvoiceTerm", {
            templateUrl: "/app/invoiceTerm/invoiceTerm.html",
            controller: "invoiceTermController"
        })
        .when("/updateInvoiceTerm/:invoiceTermId", {
            templateUrl: "/app/invoiceTerm/invoiceTerm.html",
            controller: "invoiceTermController"
        })
        .when("/gstRegistrationType", {
            templateUrl: "/app/gstRegistrationType/gstRegistrationTypeList.html",
            controller: "gstRegistrationTypeController"
        })
        .when("/newGSTRegistrationType", {
            templateUrl: "/app/gstRegistrationType/gstRegistrationType.html",
            controller: "gstRegistrationTypeController"
        })
        .when("/updateGSTRegistrationType/:gstRegistrationTypeId", {
            templateUrl: "/app/gstRegistrationType/gstRegistrationType.html",
            controller: "gstRegistrationTypeController"
        })
        .otherwise({
            redirectTo: "/home"
        });
}

configFunction.$inject = ['$routeProvider', '$httpProvider'];
IMSApp.config(configFunction);