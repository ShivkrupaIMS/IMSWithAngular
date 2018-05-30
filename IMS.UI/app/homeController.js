IMSApp.controller("HomeController",["$scope", "$location", "countryService",
    function ($scope, $location, countryService) {
    $scope.addNewCountry = function () {
        $location.path('/newCountry');
    };

    $scope.updateCountry = function (id) {
        $location.path('/updateCountry/' + id);
    };

    $scope.getCountryList = function () {
        $location.path('/country');
    };
}]);