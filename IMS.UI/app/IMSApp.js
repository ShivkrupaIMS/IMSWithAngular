var IMSApp = angular.module('IMSApp', ['ngRoute', 'ui.bootstrap']);

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
        .otherwise({
            redirectTo: "/home"
        });
}

configFunction.$inject = ['$routeProvider', '$httpProvider'];
IMSApp.config(configFunction);