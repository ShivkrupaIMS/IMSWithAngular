IMSApp.controller('invoiceStatusController',["$scope",  "$location", "$window", "$routeParams", "invoiceStatusService",
    function ($scope, $location, $window, $routeParams, invoiceStatusService) {
        if ($routeParams.invoiceStatusId) {
            invoiceStatusService.getInvoiceStatus($routeParams.invoiceStatusId).then(function (data) {
                $scope.invoiceStatus = data.data;
                $scope.editableInvoiceStatus = angular.copy($scope.invoiceStatus);
                
            }, function (data) {
                alert("An Error has occured while getting InvoiceStatus! " + data);
            });
        }
        else {
            $scope.invoiceStatus = { invoiceStatusId: 0 };
        }

        var getInvoiceStatusList = function () {
            //$scope.loading = true;
            invoiceStatusService.getInvoiceStatusList().then(function (data) {
                $scope.invoiceStatusList = data.data;
                $scope.totalItems = $scope.invoiceStatusList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting InvoiceStatus list! " + data);
            });
        }

        getInvoiceStatusList();

        $scope.addNewInvoiceStatus = function () {
            $location.path('/newInvoiceStatus');
        };

        $scope.updateInvoiceStatus = function (id) {
            $location.path('/updateInvoiceStatus/' + id);
        };
        
        $scope.deleteInvoiceStatus = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    invoiceStatusService.deleteInvoiceStatus(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getInvoiceStatusList();
                        $location.path('/invoiceStatus');
                    }, function (data) {
                        alert("An Error has occured while deleting InvoiceStatus! " + data);
                    });
                } else {
                    getInvoiceStatusList();
                    $location.path('/invoiceStatus');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableInvoiceStatus.invoiceStatusId == undefined) {
                invoiceStatusService.insertInvoiceStatus($scope.editableInvoiceStatus).then(function (data) {
                    alert("Added Successfully!!");
                    getInvoiceStatusList();
                    $location.path('/invoiceStatus');
                },function (data) {
                    alert("An Error has occured while Adding InvoiceStatus! " + data);
                });
            }
            else {
                invoiceStatusService.updateInvoiceStatus($scope.editableInvoiceStatus).then(function (data) {
                    alert("Updated Successfully!!");
                    getInvoiceStatusList();
                    $location.path('/invoiceStatus');
                }, function (data) {
                    alert("An Error has occured while updating InvoiceStatus! " + data);
                });
            }

            $scope.invoiceStatus = angular.copy($scope.editableInvoiceStatus);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);