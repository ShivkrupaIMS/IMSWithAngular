IMSApp.controller('invoiceTermController',["$scope",  "$location", "$window", "$routeParams", "invoiceTermService",
    function ($scope, $location, $window, $routeParams, invoiceTermService) {
        if ($routeParams.invoiceTermId) {
            invoiceTermService.getInvoiceTerm($routeParams.invoiceTermId).then(function (data) {
                $scope.invoiceTerm = data.data;
                $scope.editableInvoiceTerm = angular.copy($scope.invoiceTerm);
                
            }, function (data) {
                alert("An Error has occured while getting InvoiceTerm! " + data);
            });
        }
        else {
            $scope.invoiceTerm = { invoiceTermId: 0 };
        }

        var getInvoiceTermList = function () {
            //$scope.loading = true;
            invoiceTermService.getInvoiceTermList().then(function (data) {
                $scope.invoiceTermList = data.data;
                $scope.totalItems = $scope.invoiceTermList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting InvoiceTerm list! " + data);
            });
        }

        getInvoiceTermList();

        $scope.addNewInvoiceTerm = function () {
            $location.path('/newInvoiceTerm');
        };

        $scope.updateInvoiceTerm = function (id) {
            $location.path('/updateInvoiceTerm/' + id);
        };
        
        $scope.deleteInvoiceTerm = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    invoiceTermService.deleteInvoiceTerm(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getInvoiceTermList();
                        $location.path('/invoiceTerm');
                    }, function (data) {
                        alert("An Error has occured while deleting InvoiceTerm! " + data);
                    });
                } else {
                    getInvoiceTermList();
                    $location.path('/invoiceTerm');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableInvoiceTerm.invoiceTermId == undefined) {
                invoiceTermService.insertInvoiceTerm($scope.editableInvoiceTerm).then(function (data) {
                    alert("Added Successfully!!");
                    getInvoiceTermList();
                    $location.path('/invoiceTerm');
                },function (data) {
                    alert("An Error has occured while Adding InvoiceTerm! " + data);
                });
            }
            else {
                invoiceTermService.updateInvoiceTerm($scope.editableInvoiceTerm).then(function (data) {
                    alert("Updated Successfully!!");
                    getInvoiceTermList();
                    $location.path('/invoiceTerm');
                }, function (data) {
                    alert("An Error has occured while updating InvoiceTerm! " + data);
                });
            }

            $scope.invoiceTerm = angular.copy($scope.editableInvoiceTerm);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);