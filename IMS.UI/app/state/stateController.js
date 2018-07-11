IMSApp.controller('stateController',["$scope",  "$location", "$window", "$routeParams", "stateService", "countryService",
function ($scope, $location, $window, $routeParams, stateService,countryService) {

    var getStateList = function () {
            $scope.loading = true;
            stateService.getStateList().then(function (data) {
                $scope.stateList = data.data;
                $scope.totalItems = $scope.stateList.length;
                 $scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting state list! " + data);
            });
        }

        var getCountryList = function () {
            countryService.getCountryList().then(function (data) {
                $scope.countryList = data.data;
            }, function (data) {
                alert("An Error has occured while getting Country list! " + data);
            });
        }


        getStateList();
        getCountryList();

        //alert(JSON.stringify($scope.stateList));

        if ($routeParams.stateId) {
            stateService.getState($routeParams.stateId).then(function (data) {
                $scope.state = data.data;
                //$scope.customers.push(data);
                $scope.editableState = angular.copy($scope.state);
                $scope.countryValue = angular.copy($scope.state.country);
            }, function (data) {
                alert("An Error has occured while getting state! " + data);
                //$scope.loading = false;
            });
        }
        else {
            $scope.state = { stateId: 0, country: {} };
            //$scope.stateList = getstateList();
            $scope.countryValue = null;
        }

        $scope.addNewState = function () {
            $location.path('/newState');
        };

        $scope.updateState = function (id) {
            $location.path('/updateState/' + id);
        };
        
        $scope.deleteState = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    stateService.deleteState(id).then(function (data) {
                        alert("deleted Successfully!!");
                        //$scope.customers.push(data);
                        getStateList();
                        $location.path('/state');
                    }, function (data) {
                        alert("An Error has occured while deleting state! " + data);
                        //$scope.loading = false;
                    });
                } else {
                    getStateList();
                    $location.path('/state');
                }
               
            }
        };

        //$scope.stateList = function () {
        //    stateService.getstateList().then(function (data) {
        //        return data.data;
        //    }, function (data) {
        //        alert("An Error has occured while getting state list! " + data);
        //    });
        //}
        //alert($scope.state);
        $scope.submitForm = function () {
            $scope.editableState.country = { countryId: $scope.countryValue.countryId }; // = angular.copy($scope.countryValue);// {countryId : $scope.countryValue.countryId, countryName : $scope.countryValue.countryName, isActive: $scope.countryValue.isActive};
            if ($scope.editableState.stateId == undefined) {
                stateService.insertState($scope.editableState).then(function (data) {
                    alert("Added Successfully!!");
                    //$scope.customers.push(data);
                    getStateList();
                    $location.path('/state');
                },function (data) {
                    alert("An Error has occured while Adding state! " + data);
                    //$scope.loading = false;
                });
            }
            else {
                stateService.updateState($scope.editableState).then(function (data) {
                    alert("Updated Successfully!!");
                    getStateList();
                    $location.path('/state');
                    //$scope.customers.push(data);
                }, function (data) {
                    alert("An Error has occured while updating state! " + data);
                    //$scope.loading = false;
                });
            }

            $scope.state = angular.copy($scope.editableState);
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