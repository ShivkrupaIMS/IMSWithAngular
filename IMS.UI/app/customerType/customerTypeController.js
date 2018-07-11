IMSApp.controller('customerTypeController',["$scope",  "$location", "$window", "$routeParams", "customerTypeService",
    function ($scope, $location, $window, $routeParams, customerTypeService) {
        if ($routeParams.customerTypeId) {
            customerTypeService.getCustomerType($routeParams.customerTypeId).then(function (data) {
                $scope.customerType = data.data;
                $scope.editableCustomerType = angular.copy($scope.customerType);
                
            }, function (data) {
                alert("An Error has occured while getting CustomerType! " + data);
            });
        }
        else {
            $scope.customerType = { customerTypeId: 0 };
        }

        var getCustomerTypeList = function () {
            //$scope.loading = true;
            customerTypeService.getCustomerTypeList().then(function (data) {
                $scope.customerTypeList = data.data;
                $scope.totalItems = $scope.customerTypeList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting CustomerType list! " + data);
            });
        }

        getCustomerTypeList();

        $scope.addNewCustomerType = function () {
            $location.path('/newCustomerType');
        };

        $scope.updateCustomerType = function (id) {
            $location.path('/updateCustomerType/' + id);
        };
        
        $scope.deleteCustomerType = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    customerTypeService.deleteCustomerType(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getCustomerTypeList();
                        $location.path('/customerType');
                    }, function (data) {
                        alert("An Error has occured while deleting CustomerType! " + data);
                    });
                } else {
                    getCustomerTypeList();
                    $location.path('/customerType');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableCustomerType.customerTypeId == undefined) {
                customerTypeService.insertCustomerType($scope.editableCustomerType).then(function (data) {
                    alert("Added Successfully!!");
                    getCustomerTypeList();
                    $location.path('/customerType');
                },function (data) {
                    alert("An Error has occured while Adding CustomerType! " + data);
                });
            }
            else {
                customerTypeService.updateCustomerType($scope.editableCustomerType).then(function (data) {
                    alert("Updated Successfully!!");
                    getCustomerTypeList();
                    $location.path('/customerType');
                }, function (data) {
                    alert("An Error has occured while updating CustomerType! " + data);
                });
            }

            $scope.customerType = angular.copy($scope.editableCustomerType);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);