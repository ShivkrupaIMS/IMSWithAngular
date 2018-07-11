IMSApp.controller('accountingMethodController',["$scope",  "$location", "$window", "$routeParams", "accountingMethodService",
    function ($scope, $location, $window, $routeParams, accountingMethodService) {
        if ($routeParams.accountingMethodId) {
            accountingMethodService.getAccountingMethod($routeParams.accountingMethodId).then(function (data) {
                $scope.accountingMethod = data.data;
                $scope.editableAccountingMethod = angular.copy($scope.accountingMethod);
                
            }, function (data) {
                alert("An Error has occured while getting AccountingMethod! " + data);
            });
        }
        else {
            $scope.accountingMethod = { accountingMethodId: 0 };
        }

        var getAccountingMethodList = function () {
            //$scope.loading = true;
            accountingMethodService.getAccountingMethodList().then(function (data) {
                $scope.accountingMethodList = data.data;
                $scope.totalItems = $scope.accountingMethodList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting AccountingMethod list! " + data);
            });
        }

        getAccountingMethodList();

        $scope.addNewAccountingMethod = function () {
            $location.path('/newAccountingMethod');
        };

        $scope.updateAccountingMethod = function (id) {
            $location.path('/updateAccountingMethod/' + id);
        };
        
        $scope.deleteAccountingMethod = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    accountingMethodService.deleteAccountingMethod(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getAccountingMethodList();
                        $location.path('/accountingMethod');
                    }, function (data) {
                        alert("An Error has occured while deleting AccountingMethod! " + data);
                    });
                } else {
                    getAccountingMethodList();
                    $location.path('/accountingMethod');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableAccountingMethod.accountingMethodId == undefined) {
                accountingMethodService.insertAccountingMethod($scope.editableAccountingMethod).then(function (data) {
                    alert("Added Successfully!!");
                    getAccountingMethodList();
                    $location.path('/accountingMethod');
                },function (data) {
                    alert("An Error has occured while Adding AccountingMethod! " + data);
                });
            }
            else {
                accountingMethodService.updateAccountingMethod($scope.editableAccountingMethod).then(function (data) {
                    alert("Updated Successfully!!");
                    getAccountingMethodList();
                    $location.path('/accountingMethod');
                }, function (data) {
                    alert("An Error has occured while updating AccountingMethod! " + data);
                });
            }

            $scope.accountingMethod = angular.copy($scope.editableAccountingMethod);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);