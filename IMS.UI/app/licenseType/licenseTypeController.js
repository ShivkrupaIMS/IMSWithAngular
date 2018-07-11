IMSApp.controller('licenseTypeController',["$scope",  "$location", "$window", "$routeParams", "licenseTypeService",
    function ($scope, $location, $window, $routeParams, licenseTypeService) {
        if ($routeParams.licenseTypeId) {
            licenseTypeService.getLicenseType($routeParams.licenseTypeId).then(function (data) {
                $scope.licenseType = data.data;
                $scope.editableLicenseType = angular.copy($scope.licenseType);
                
            }, function (data) {
                alert("An Error has occured while getting LicenseType! " + data);
            });
        }
        else {
            $scope.licenseType = { licenseTypeId: 0 };
        }

        var getLicenseTypeList = function () {
            //$scope.loading = true;
            licenseTypeService.getLicenseTypeList().then(function (data) {
                $scope.licenseTypeList = data.data;
                $scope.totalItems = $scope.licenseTypeList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting LicenseType list! " + data);
            });
        }

        getLicenseTypeList();

        $scope.addNewLicenseType = function () {
            $location.path('/newLicenseType');
        };

        $scope.updateLicenseType = function (id) {
            $location.path('/updateLicenseType/' + id);
        };
        
        $scope.deleteLicenseType = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    licenseTypeService.deleteLicenseType(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getLicenseTypeList();
                        $location.path('/licenseType');
                    }, function (data) {
                        alert("An Error has occured while deleting LicenseType! " + data);
                    });
                } else {
                    getLicenseTypeList();
                    $location.path('/licenseType');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableLicenseType.licenseTypeId == undefined) {
                licenseTypeService.insertLicenseType($scope.editableLicenseType).then(function (data) {
                    alert("Added Successfully!!");
                    getLicenseTypeList();
                    $location.path('/licenseType');
                },function (data) {
                    alert("An Error has occured while Adding LicenseType! " + data);
                });
            }
            else {
                licenseTypeService.updateLicenseType($scope.editableLicenseType).then(function (data) {
                    alert("Updated Successfully!!");
                    getLicenseTypeList();
                    $location.path('/licenseType');
                }, function (data) {
                    alert("An Error has occured while updating LicenseType! " + data);
                });
            }

            $scope.licenseType = angular.copy($scope.editableLicenseType);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);