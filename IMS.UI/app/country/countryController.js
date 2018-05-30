IMSApp.controller('countryController',["$scope",  "$location", "$window", "$routeParams", "countryService",
    function ($scope, $location, $window, $routeParams, countryService) {
        if ($routeParams.countryId) {
            countryService.getCountry($routeParams.countryId).then(function (data) {
                $scope.country = data.data;
                //$scope.customers.push(data);
                $scope.editableCountry = angular.copy($scope.country);
                
            }, function (data) {
                alert("An Error has occured while getting Country! " + data);
                //$scope.loading = false;
            });
        }
        else {
            $scope.country = { countryId: 0 };
            //$scope.countryList = getCountryList();
        }

        var getCountryList = function () {
            countryService.getCountryList().then(function (data) {
                $scope.countryList = data.data;
            }, function (data) {
                alert("An Error has occured while getting Country list! " + data);
            });
        }

        getCountryList();
        //alert(JSON.stringify($scope.countryList));

        $scope.addNewCountry = function () {
            $location.path('/newCountry');
        };

        $scope.updateCountry = function (id) {
            $location.path('/updateCountry/' + id);
        };
        
        //$scope.countryList = function () {
        //    countryService.getCountryList().then(function (data) {
        //        return data.data;
        //    }, function (data) {
        //        alert("An Error has occured while getting Country list! " + data);
        //    });
        //}
        //alert($scope.country);
        $scope.submitForm = function () {
            
            if ($scope.editableCountry.countryId == undefined) {
                alert("add" + $scope.editableCountry.countryId);
                countryService.insertCountry($scope.editableCountry).then(function (data) {
                    alert("Added Successfully!!");
                    //$scope.customers.push(data);
                },function (data) {
                    alert("An Error has occured while Adding Country! " + data);
                    //$scope.loading = false;
                });
            }
            else {
                alert("update" + $scope.editableCountry.countryId);
                countryService.updateCountry($scope.editableCountry).then(function (data) {
                    alert("Updated Successfully!!");
                    //$scope.customers.push(data);
                }, function (data) {
                    alert("An Error has occured while updating Country! " + data);
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