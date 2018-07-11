IMSApp.controller('itemUnitController',["$scope",  "$location", "$window", "$routeParams", "itemUnitService",
    function ($scope, $location, $window, $routeParams, itemUnitService) {
        if ($routeParams.itemUnitId) {
            itemUnitService.getItemUnit($routeParams.itemUnitId).then(function (data) {
                $scope.itemUnit = data.data;
                $scope.editableItemUnit = angular.copy($scope.itemUnit);
                
            }, function (data) {
                alert("An Error has occured while getting ItemUnit! " + data);
            });
        }
        else {
            $scope.itemUnit = { itemUnitId: 0 };
        }

        var getItemUnitList = function () {
            //$scope.loading = true;
            itemUnitService.getItemUnitList().then(function (data) {
                $scope.itemUnitList = data.data;
                $scope.totalItems = $scope.itemUnitList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting ItemUnit list! " + data);
            });
        }

        getItemUnitList();

        $scope.addNewItemUnit = function () {
            $location.path('/newItemUnit');
        };

        $scope.updateItemUnit = function (id) {
            $location.path('/updateItemUnit/' + id);
        };
        
        $scope.deleteItemUnit = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    itemUnitService.deleteItemUnit(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getItemUnitList();
                        $location.path('/itemUnit');
                    }, function (data) {
                        alert("An Error has occured while deleting ItemUnit! " + data);
                    });
                } else {
                    getItemUnitList();
                    $location.path('/itemUnit');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableItemUnit.itemUnitId == undefined) {
                itemUnitService.insertItemUnit($scope.editableItemUnit).then(function (data) {
                    alert("Added Successfully!!");
                    getItemUnitList();
                    $location.path('/itemUnit');
                },function (data) {
                    alert("An Error has occured while Adding ItemUnit! " + data);
                });
            }
            else {
                itemUnitService.updateItemUnit($scope.editableItemUnit).then(function (data) {
                    alert("Updated Successfully!!");
                    getItemUnitList();
                    $location.path('/itemUnit');
                }, function (data) {
                    alert("An Error has occured while updating ItemUnit! " + data);
                });
            }

            $scope.itemUnit = angular.copy($scope.editableItemUnit);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);