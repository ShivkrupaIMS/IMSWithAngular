IMSApp.controller('countryController',["$scope", "$window", "$routeParams", "countryService",
    function ($scope, $window, $routeParams, countryService) {
        if ($routeParams.id)
            $scope.country = countryService.getCountry($routeParams.id);
        else
            $scope.country = { id: 0 };

        $scope.editableCountry = angular.copy($scope.country);

        $scope.submitForm = function () {
            if ($scope.editableCountry.id == 0) {
                countryService.insertCountry($scope.editableCountry);
            }
            else {
                countryService.updateCountry($scope.editableCountry);
            }

            $scope.country = angular.copy($scope.editableCountry);
            $window.history.back();
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
    }]);