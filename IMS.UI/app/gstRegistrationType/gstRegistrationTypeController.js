IMSApp.controller('gstRegistrationTypeController',["$scope",  "$location", "$window", "$routeParams", "gstRegistrationTypeService",
    function ($scope, $location, $window, $routeParams, gstRegistrationTypeService) {
        if ($routeParams.gstRegistrationTypeId) {
            gstRegistrationTypeService.getGSTRegistrationType($routeParams.gstRegistrationTypeId).then(function (data) {
                $scope.gstRegistrationType = data.data;
                $scope.editableGSTRegistrationType = angular.copy($scope.gstRegistrationType);
                
            }, function (data) {
                alert("An Error has occured while getting GSTRegistrationType! " + data);
            });
        }
        else {
            $scope.gstRegistrationType = { gstRegistrationTypeId: 0 };
        }

        var getGSTRegistrationTypeList = function () {
            //$scope.loading = true;
            gstRegistrationTypeService.getGSTRegistrationTypeList().then(function (data) {
                $scope.gstRegistrationTypeList = data.data;
                $scope.totalItems = $scope.gstRegistrationTypeList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting GSTRegistrationType list! " + data);
            });
        }

        getGSTRegistrationTypeList();

        $scope.addNewGSTRegistrationType = function () {
            $location.path('/newGSTRegistrationType');
        };

        $scope.updateGSTRegistrationType = function (id) {
            $location.path('/updateGSTRegistrationType/' + id);
        };
        
        $scope.deleteGSTRegistrationType = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    gstRegistrationTypeService.deleteGSTRegistrationType(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getGSTRegistrationTypeList();
                        $location.path('/gstRegistrationType');
                    }, function (data) {
                        alert("An Error has occured while deleting GSTRegistrationType! " + data);
                    });
                } else {
                    getGSTRegistrationTypeList();
                    $location.path('/gstRegistrationType');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableGSTRegistrationType.gstRegistrationTypeId == undefined) {
                gstRegistrationTypeService.insertGSTRegistrationType($scope.editableGSTRegistrationType).then(function (data) {
                    alert("Added Successfully!!");
                    getGSTRegistrationTypeList();
                    $location.path('/gstRegistrationType');
                },function (data) {
                    alert("An Error has occured while Adding GSTRegistrationType! " + data);
                });
            }
            else {
                gstRegistrationTypeService.updateGSTRegistrationType($scope.editableGSTRegistrationType).then(function (data) {
                    alert("Updated Successfully!!");
                    getGSTRegistrationTypeList();
                    $location.path('/gstRegistrationType');
                }, function (data) {
                    alert("An Error has occured while updating GSTRegistrationType! " + data);
                });
            }

            $scope.gstRegistrationType = angular.copy($scope.editableGSTRegistrationType);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; 

    }]);