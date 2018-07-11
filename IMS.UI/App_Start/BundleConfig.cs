﻿using System.Web;
using System.Web.Optimization;

namespace IMS.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.slim.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/popper.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      //"~/Content/ui-bootstrap-csp.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/scripts/angular-ui/ui-bootstrap-tpls.js"));


            bundles.Add(new ScriptBundle("~/bundles/mycustomjs").Include(
                      "~/app/IMSApp.js",
                      "~/app/loadingDirective.js",
                      "~/app/country/countryService.js",
                      "~/app/country/countryController.js",
                      "~/app/country/countryDirective.js",
                      "~/app/state/stateService.js",
                      "~/app/state/stateController.js",
                      "~/app/state/stateDirective.js",
                      "~/app/city/cityService.js",
                      "~/app/city/cityController.js",
                      "~/app/city/cityDirective.js",
                      "~/app/itemType/itemTypeService.js",
                      "~/app/itemType/itemTypeController.js",
                      "~/app/itemType/itemTypeDirective.js",
                      "~/app/invoiceStatus/invoiceStatusService.js",
                      "~/app/invoiceStatus/invoiceStatusController.js",
                      "~/app/invoiceStatus/invoiceStatusDirective.js",
                       "~/app/gstRegistrationType/gstRegistrationTypeService.js",
                      "~/app/gstRegistrationType/gstRegistrationTypeController.js",
                      "~/app/gstRegistrationType/gstRegistrationTypeDirective.js",
                      "~/app/licenseType/licenseTypeService.js",
                      "~/app/licenseType/licenseTypeController.js",
                      "~/app/licenseType/licenseTypeDirective.js",
                      "~/app/taxSlab/taxSlabService.js",
                      "~/app/taxSlab/taxSlabController.js",
                      "~/app/taxSlab/taxSlabDirective.js",
                      "~/app/invoiceTerm/invoiceTermService.js",
                      "~/app/invoiceTerm/invoiceTermController.js",
                      "~/app/invoiceTerm/invoiceTermDirective.js",
                      "~/app/customerType/customerTypeService.js",
                      "~/app/customerType/customerTypeController.js",
                      "~/app/customerType/customerTypeDirective.js",
                      "~/app/homeController.js"
                      ));
        }
    }
}
