IMSApp.controller('countryController',["$scope",  "$location", "$window", "$routeParams", "countryService",
    function ($scope, $location, $window, $routeParams, countryService) {
        if ($routeParams.countryId) {
            countryService.getCountry($routeParams.countryId).then(function (data) {
                $scope.country = data.data;
                $scope.editableCountry = angular.copy($scope.country);
                
            }, function (data) {
                alert("An Error has occured while getting Country! " + data);
            });
        }
        else {
            $scope.country = { countryId: 0 };
        }

        var getCountryList = function () {
            //$scope.loading = true;
            countryService.getCountryList().then(function (data) {
                $scope.countryList = data.data;
                $scope.totalItems = $scope.countryList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting Country list! " + data);
            });
        }

        getCountryList();

        $scope.addNewCountry = function () {
            $location.path('/newCountry');
        };

        $scope.updateCountry = function (id) {
            $location.path('/updateCountry/' + id);
        };
        
        $scope.deleteCountry = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    countryService.deleteCountry(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getCountryList();
                        $location.path('/country');
                    }, function (data) {
                        alert("An Error has occured while deleting Country! " + data);
                    });
                } else {
                    getCountryList();
                    $location.path('/country');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableCountry.countryId == undefined) {
                countryService.insertCountry($scope.editableCountry).then(function (data) {
                    alert("Added Successfully!!");
                    getCountryList();
                    $location.path('/country');
                },function (data) {
                    alert("An Error has occured while Adding Country! " + data);
                });
            }
            else {
                countryService.updateCountry($scope.editableCountry).then(function (data) {
                    alert("Updated Successfully!!");
                    getCountryList();
                    $location.path('/country');
                }, function (data) {
                    alert("An Error has occured while updating Country! " + data);
                });
            }

            $scope.country = angular.copy($scope.editableCountry);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };

        //$scope.viewby = 2;
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

        //$scope.setPage = function (pageNo) {
        //    $scope.currentPage = pageNo;
        //};

        //$scope.pageChanged = function () {
        //    console.log('Page changed to: ' + $scope.currentPage);
        //};

        //$scope.setItemsPerPage = function (num) {
        //    $scope.itemsPerPage = num;
        //    $scope.currentPage = 1; //reset to first page
        //}

    }]);