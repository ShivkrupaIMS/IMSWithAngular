IMSApp.controller('hsnSacController',["$scope",  "$location", "$window", "$routeParams", "hsnSacService",
    function ($scope, $location, $window, $routeParams, hsnSacService) {
        if ($routeParams.hsnsacId) {
            hsnSacService.getHSNSAC($routeParams.hsnsacId).then(function (data) {
                $scope.hsnSac = data.data;
                $scope.editableHSNSAC = angular.copy($scope.hsnSac);
                
            }, function (data) {
                alert("An Error has occured while getting HSNSAC! " + data);
            });
        }
        else {
            $scope.hsnSac = { hsnsacId: 0 };
        }

        var getHSNSACList = function () {
            //$scope.loading = true;
            hsnSacService.getHSNSACList().then(function (data) {
                $scope.hsnSacList = data.data;
                $scope.totalItems = $scope.hsnSacList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting HSNSAC list! " + data);
            });
        }

        getHSNSACList();

        $scope.addNewHSNSAC = function () {
            $location.path('/newHSNSAC');
        };

        $scope.updateHSNSAC = function (id) {
            $location.path('/updateHSNSAC/' + id);
        };
        
        $scope.deleteHSNSAC = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    hsnSacService.deleteHSNSAC(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getHSNSACList();
                        $location.path('/hsnSac');
                    }, function (data) {
                        alert("An Error has occured while deleting HSNSAC! " + data);
                    });
                } else {
                    getHSNSACList();
                    $location.path('/hsnSac');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableHSNSAC.hsnsacId == undefined) {
                hsnSacService.insertHSNSAC($scope.editableHSNSAC).then(function (data) {
                    alert("Added Successfully!!");
                    getHSNSACList();
                    $location.path('/hsnSac');
                },function (data) {
                    alert("An Error has occured while Adding HSNSAC! " + data);
                });
            }
            else {
                hsnSacService.updateHSNSAC($scope.editableHSNSAC).then(function (data) {
                    alert("Updated Successfully!!");
                    getHSNSACList();
                    $location.path('/hsnSac');
                }, function (data) {
                    alert("An Error has occured while updating HSNSAC! " + data);
                });
            }

            $scope.hsnSac = angular.copy($scope.editableHSNSAC);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);