IMSApp.controller('supplierTypeController',["$scope",  "$location", "$window", "$routeParams", "supplierTypeService",
    function ($scope, $location, $window, $routeParams, supplierTypeService) {
        if ($routeParams.supplierTypeId) {
            supplierTypeService.getSupplierType($routeParams.supplierTypeId).then(function (data) {
                $scope.supplierType = data.data;
                $scope.editableSupplierType = angular.copy($scope.supplierType);
                
            }, function (data) {
                alert("An Error has occured while getting SupplierType! " + data);
            });
        }
        else {
            $scope.supplierType = { supplierTypeId: 0 };
        }

        var getSupplierTypeList = function () {
            //$scope.loading = true;
            supplierTypeService.getSupplierTypeList().then(function (data) {
                $scope.supplierTypeList = data.data;
                $scope.totalItems = $scope.supplierTypeList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting SupplierType list! " + data);
            });
        }

        getSupplierTypeList();

        $scope.addNewSupplierType = function () {
            $location.path('/newSupplierType');
        };

        $scope.updateSupplierType = function (id) {
            $location.path('/updateSupplierType/' + id);
        };
        
        $scope.deleteSupplierType = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    supplierTypeService.deleteSupplierType(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getSupplierTypeList();
                        $location.path('/supplierType');
                    }, function (data) {
                        alert("An Error has occured while deleting SupplierType! " + data);
                    });
                } else {
                    getSupplierTypeList();
                    $location.path('/supplierType');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableSupplierType.supplierTypeId == undefined) {
                supplierTypeService.insertSupplierType($scope.editableSupplierType).then(function (data) {
                    alert("Added Successfully!!");
                    getSupplierTypeList();
                    $location.path('/supplierType');
                },function (data) {
                    alert("An Error has occured while Adding SupplierType! " + data);
                });
            }
            else {
                supplierTypeService.updateSupplierType($scope.editableSupplierType).then(function (data) {
                    alert("Updated Successfully!!");
                    getSupplierTypeList();
                    $location.path('/supplierType');
                }, function (data) {
                    alert("An Error has occured while updating SupplierType! " + data);
                });
            }

            $scope.supplierType = angular.copy($scope.editableSupplierType);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);