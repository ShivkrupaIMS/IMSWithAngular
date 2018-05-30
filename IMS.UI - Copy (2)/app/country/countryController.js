IMSApp.controller('countryController',["$scope", "$window", "$routeParams", "countryService",
    function ($scope, $window, $routeParams, countryService) {
        if ($routeParams.id)
        {
            countryService.getCountry($routeParams.id).then(function (data) {
                alert(data);
                $scope.country = data;
                //$scope.customers.push(data);
            },function (data) {
                alert("An Error has occured while Adding Country! " + data);
                //$scope.loading = false;
            });
        }
        else
            $scope.country = { id: 0 };

        $scope.editableCountry = angular.copy($scope.country);
        
        $scope.submitForm = function () {
            if ($scope.editableCountry.id == 0) {
                countryService.insertCountry($scope.editableCountry).then(function (data) {
                    alert("Added Successfully!!");
                    //$scope.customers.push(data);
                },function (data) {
                    alert("An Error has occured while Adding Country! " + data);
                    //$scope.loading = false;
                });
            }
            else {
                countryService.updateCountry($scope.editableCountry).then(function (data) {
                    alert("Added Successfully!!");
                    //$scope.customers.push(data);
                }, function (data) {
                    alert("An Error has occured while Adding Country! " + data);
                    //$scope.loading = false;
                });
            }

            $scope.country = angular.copy($scope.editableCountry);
            $window.history.back();
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
    }]);