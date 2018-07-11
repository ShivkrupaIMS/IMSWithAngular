IMSApp.controller('companyTypeController',["$scope",  "$location", "$window", "$routeParams", "companyTypeService",
    function ($scope, $location, $window, $routeParams, companyTypeService) {
        if ($routeParams.companyTypeId) {
            companyTypeService.getCompanyType($routeParams.companyTypeId).then(function (data) {
                $scope.companyType = data.data;
                $scope.editableCompanyType = angular.copy($scope.companyType);
                
            }, function (data) {
                alert("An Error has occured while getting CompanyType! " + data);
            });
        }
        else {
            $scope.companyType = { companyTypeId: 0 };
        }

        var getCompanyTypeList = function () {
            //$scope.loading = true;
            companyTypeService.getCompanyTypeList().then(function (data) {
                $scope.companyTypeList = data.data;
                $scope.totalItems = $scope.companyTypeList.length;
                //$scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting CompanyType list! " + data);
            });
        }

        getCompanyTypeList();

        $scope.addNewCompanyType = function () {
            $location.path('/newCompanyType');
        };

        $scope.updateCompanyType = function (id) {
            $location.path('/updateCompanyType/' + id);
        };
        
        $scope.deleteCompanyType = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    companyTypeService.deleteCompanyType(id).then(function (data) {
                        alert("deleted Successfully!!");
                        getCompanyTypeList();
                        $location.path('/companyType');
                    }, function (data) {
                        alert("An Error has occured while deleting CompanyType! " + data);
                    });
                } else {
                    getCompanyTypeList();
                    $location.path('/companyType');
                }
               
            }
        };

        $scope.submitForm = function () {
            
            if ($scope.editableCompanyType.companyTypeId == undefined) {
                companyTypeService.insertCompanyType($scope.editableCompanyType).then(function (data) {
                    alert("Added Successfully!!");
                    getCompanyTypeList();
                    $location.path('/companyType');
                },function (data) {
                    alert("An Error has occured while Adding CompanyType! " + data);
                });
            }
            else {
                companyTypeService.updateCompanyType($scope.editableCompanyType).then(function (data) {
                    alert("Updated Successfully!!");
                    getCompanyTypeList();
                    $location.path('/companyType');
                }, function (data) {
                    alert("An Error has occured while updating CompanyType! " + data);
                });
            }

            $scope.companyType = angular.copy($scope.editableCompanyType);
            
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };
        
        $scope.currentPage = 1;
        $scope.itemsPerPage =2;
        $scope.maxSize = 5; //Number of pager buttons to show

    }]);