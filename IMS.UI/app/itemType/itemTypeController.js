IMSApp.controller('itemTypeController',["$scope",  "$location", "$window", "$routeParams", "itemTypeService",
    function ($scope, $location, $window, $routeParams, itemTypeService) {
        if ($routeParams.itemTypeId) {
            itemTypeService.getItemType($routeParams.itemTypeId).then(function (data) {
                $scope.itemType = data.data;
                $scope.editableItemType = angular.copy($scope.itemType);
                
            }, function (data) {
                alert("An Error has occured while getting ItemType! " + data);
            });
        }
        else {
            $scope.itemType = { itemTypeId: 0 };
        }

        var getItemTypeList = function () {
            //$scope.loading = true;
            itemTypeService.getItemTypeList().then(function (data) {
                $scope.itemTypeList = data.data;
                $scope.totalItems = $scope.itemTypeList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting ItemType list! " + data);
            });
        }

        getItemTypeList();

        $scope.addNewItemType = function () {
            $location.path('/newItemType');
        };

        $scope.updateItemType = function (id) {
            $location.path('/updateItemType/' + id);
        };
        
        $scope.deleteItemType = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    itemTypeService.deleteItemType(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getItemTypeList();
                        $location.path('/itemType');
                    }, function (data) {
                        alert("An Error has occured while deleting ItemType! " + data);
                    });
                } else {
                    getItemTypeList();
                    $location.path('/itemType');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableItemType.itemTypeId == undefined) {
                itemTypeService.insertItemType($scope.editableItemType).then(function (data) {
                    alert("Added Successfully!!");
                    getItemTypeList();
                    $location.path('/itemType');
                },function (data) {
                    alert("An Error has occured while Adding ItemType! " + data);
                });
            }
            else {
                itemTypeService.updateItemType($scope.editableItemType).then(function (data) {
                    alert("Updated Successfully!!");
                    getItemTypeList();
                    $location.path('/itemType');
                }, function (data) {
                    alert("An Error has occured while updating ItemType! " + data);
                });
            }

            $scope.itemType = angular.copy($scope.editableItemType);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);