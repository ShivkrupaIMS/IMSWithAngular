IMSApp.controller('manufacturerController',["$scope",  "$location", "$window", "$routeParams", "manufacturerService",
    function ($scope, $location, $window, $routeParams, manufacturerService) {
        if ($routeParams.manufacturerId) {
            manufacturerService.getManufacturer($routeParams.manufacturerId).then(function (data) {
                $scope.manufacturer = data.data;
                $scope.editableManufacturer = angular.copy($scope.manufacturer);
                
            }, function (data) {
                alert("An Error has occured while getting Manufacturer! " + data);
            });
        }
        else {
            $scope.manufacturer = { manufacturerId: 0 };
        }

        var getManufacturerList = function () {
            //$scope.loading = true;
            manufacturerService.getManufacturerList().then(function (data) {
                $scope.manufacturerList = data.data;
                $scope.totalItems = $scope.manufacturerList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting Manufacturer list! " + data);
            });
        }

        getManufacturerList();

        $scope.addNewManufacturer = function () {
            $location.path('/newManufacturer');
        };

        $scope.updateManufacturer = function (id) {
            $location.path('/updateManufacturer/' + id);
        };
        
        $scope.deleteManufacturer = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    manufacturerService.deleteManufacturer(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getManufacturerList();
                        $location.path('/manufacturer');
                    }, function (data) {
                        alert("An Error has occured while deleting Manufacturer! " + data);
                    });
                } else {
                    getManufacturerList();
                    $location.path('/manufacturer');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableManufacturer.manufacturerId == undefined) {
                manufacturerService.insertManufacturer($scope.editableManufacturer).then(function (data) {
                    alert("Added Successfully!!");
                    getManufacturerList();
                    $location.path('/manufacturer');
                },function (data) {
                    alert("An Error has occured while Adding Manufacturer! " + data);
                });
            }
            else {
                manufacturerService.updateManufacturer($scope.editableManufacturer).then(function (data) {
                    alert("Updated Successfully!!");
                    getManufacturerList();
                    $location.path('/manufacturer');
                }, function (data) {
                    alert("An Error has occured while updating Manufacturer! " + data);
                });
            }

            $scope.manufacturer = angular.copy($scope.editableManufacturer);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);