IMSApp.controller('invoiceTypeController',["$scope",  "$location", "$window", "$routeParams", "invoiceTypeService",
    function ($scope, $location, $window, $routeParams, invoiceTypeService) {
        if ($routeParams.invoiceTypeId) {
            invoiceTypeService.getInvoiceType($routeParams.invoiceTypeId).then(function (data) {
                $scope.invoiceType = data.data;
                $scope.editableInvoiceType = angular.copy($scope.invoiceType);
                
            }, function (data) {
                alert("An Error has occured while getting InvoiceType! " + data);
            });
        }
        else {
            $scope.invoiceType = { invoiceTypeId: 0 };
        }

        var getInvoiceTypeList = function () {
            //$scope.loading = true;
            invoiceTypeService.getInvoiceTypeList().then(function (data) {
                $scope.invoiceTypeList = data.data;
                $scope.totalItems = $scope.invoiceTypeList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting InvoiceType list! " + data);
            });
        }

        getInvoiceTypeList();

        $scope.addNewInvoiceType = function () {
            $location.path('/newInvoiceType');
        };

        $scope.updateInvoiceType = function (id) {
            $location.path('/updateInvoiceType/' + id);
        };
        
        $scope.deleteInvoiceType = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    invoiceTypeService.deleteInvoiceType(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getInvoiceTypeList();
                        $location.path('/invoiceType');
                    }, function (data) {
                        alert("An Error has occured while deleting InvoiceType! " + data);
                    });
                } else {
                    getInvoiceTypeList();
                    $location.path('/invoiceType');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableInvoiceType.invoiceTypeId == undefined) {
                invoiceTypeService.insertInvoiceType($scope.editableInvoiceType).then(function (data) {
                    alert("Added Successfully!!");
                    getInvoiceTypeList();
                    $location.path('/invoiceType');
                },function (data) {
                    alert("An Error has occured while Adding InvoiceType! " + data);
                });
            }
            else {
                invoiceTypeService.updateInvoiceType($scope.editableInvoiceType).then(function (data) {
                    alert("Updated Successfully!!");
                    getInvoiceTypeList();
                    $location.path('/invoiceType');
                }, function (data) {
                    alert("An Error has occured while updating InvoiceType! " + data);
                });
            }

            $scope.invoiceType = angular.copy($scope.editableInvoiceType);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);