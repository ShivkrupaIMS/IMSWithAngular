IMSApp.controller('cityController',["$scope",  "$location", "$window", "$routeParams", "cityService", "stateService",
function ($scope, $location, $window, $routeParams, cityService,stateService) {

    var getCityList = function () {
            $scope.loading = true;
            cityService.getCityList().then(function (data) {
                $scope.cityList = data.data;
                $scope.totalItems = $scope.cityList.length;
                 $scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting city list! " + data);
            });
        }

        var getStateList = function () {
            stateService.getStateList().then(function (data) {
                $scope.stateList = data.data;
            }, function (data) {
                alert("An Error has occured while getting State list! " + data);
            });
        }


        getCityList();
        getStateList();

        //alert(JSON.stringify($scope.cityList));

        if ($routeParams.cityId) {
            cityService.getCity($routeParams.cityId).then(function (data) {
                $scope.city = data.data;
                //$scope.customers.push(data);
                $scope.editableCity = angular.copy($scope.city);
                $scope.stateValue = angular.copy($scope.city.state);
            }, function (data) {
                alert("An Error has occured while getting city! " + data);
                //$scope.loading = false;
            });
        }
        else {
            $scope.city = { cityId: 0, state: {} };
            //$scope.cityList = getcityList();
            $scope.stateValue = null;
        }

        $scope.addNewCity = function () {
            $location.path('/newCity');
        };

        $scope.updateCity = function (id) {
            $location.path('/updateCity/' + id);
        };
        
        $scope.deleteCity = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    cityService.deleteCity(id).then(function (data) {
                        alert("deleted Successfully!!");
                        //$scope.customers.push(data);
                        getCityList();
                        $location.path('/city');
                    }, function (data) {
                        alert("An Error has occured while deleting city! " + data);
                        //$scope.loading = false;
                    });
                } else {
                    getCityList();
                    $location.path('/city');
                }
               
            }
        };

        //$scope.cityList = function () {
        //    cityService.getcityList().then(function (data) {
        //        return data.data;
        //    }, function (data) {
        //        alert("An Error has occured while getting city list! " + data);
        //    });
        //}
        //alert($scope.city);
        $scope.submitForm = function () {
            $scope.editableCity.state = { stateId: $scope.stateValue.stateId }; // = angular.copy($scope.stateValue);// {stateId : $scope.stateValue.stateId, stateName : $scope.stateValue.stateName, isActive: $scope.stateValue.isActive};
            if ($scope.editableCity.cityId == undefined) {
                cityService.insertCity($scope.editableCity).then(function (data) {
                    alert("Added Successfully!!");
                    //$scope.customers.push(data);
                    getCityList();
                    $location.path('/city');
                },function (data) {
                    alert("An Error has occured while Adding city! " + data);
                    //$scope.loading = false;
                });
            }
            else {
                cityService.updateCity($scope.editableCity).then(function (data) {
                    alert("Updated Successfully!!");
                    getCityList();
                    $location.path('/city');
                    //$scope.customers.push(data);
                }, function (data) {
                    alert("An Error has occured while updating city! " + data);
                    //$scope.loading = false;
                });
            }

            $scope.city = angular.copy($scope.editableCity);
            $scope.loading = true;
            //$window.history.back();
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };

        $scope.currentPage = 1;
        $scope.itemsPerPage = 2;
        $scope.maxSize = 5;
    }]);