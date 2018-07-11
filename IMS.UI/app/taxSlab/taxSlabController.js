IMSApp.controller('taxSlabController',["$scope",  "$location", "$window", "$routeParams", "taxSlabService",
    function ($scope, $location, $window, $routeParams, taxSlabService) {
        if ($routeParams.taxSlabId) {
            taxSlabService.getTaxSlab($routeParams.taxSlabId).then(function (data) {
                $scope.taxSlab = data.data;
                $scope.editableTaxSlab = angular.copy($scope.taxSlab);
                
            }, function (data) {
                alert("An Error has occured while getting TaxSlab! " + data);
            });
        }
        else {
            $scope.taxSlab = { taxSlabId: 0 };
        }

        var getTaxSlabList = function () {
            //$scope.loading = true;
            taxSlabService.getTaxSlabList().then(function (data) {
                $scope.taxSlabList = data.data;
                $scope.totalItems = $scope.taxSlabList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting TaxSlab list! " + data);
            });
        }

        getTaxSlabList();

        $scope.addNewTaxSlab = function () {
            $location.path('/newTaxSlab');
        };

        $scope.updateTaxSlab = function (id) {
            $location.path('/updateTaxSlab/' + id);
        };
        
        $scope.deleteTaxSlab = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    taxSlabService.deleteTaxSlab(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getTaxSlabList();
                        $location.path('/taxSlab');
                    }, function (data) {
                        alert("An Error has occured while deleting TaxSlab! " + data);
                    });
                } else {
                    getTaxSlabList();
                    $location.path('/taxSlab');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableTaxSlab.taxSlabId == undefined) {
                taxSlabService.insertTaxSlab($scope.editableTaxSlab).then(function (data) {
                    alert("Added Successfully!!");
                    getTaxSlabList();
                    $location.path('/taxSlab');
                },function (data) {
                    alert("An Error has occured while Adding TaxSlab! " + data);
                });
            }
            else {
                taxSlabService.updateTaxSlab($scope.editableTaxSlab).then(function (data) {
                    alert("Updated Successfully!!");
                    getTaxSlabList();
                    $location.path('/taxSlab');
                }, function (data) {
                    alert("An Error has occured while updating TaxSlab! " + data);
                });
            }

            $scope.taxSlab = angular.copy($scope.editableTaxSlab);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);