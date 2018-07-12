IMSApp.controller('companyController', ["$scope", "$location", "$window", "$routeParams", "companyService", "companyTypeService", "stateService", "countryService",
function ($scope, $location, $window, $routeParams, companyService, companyTypeService, stateService, countryService) {

    var getCompanyList = function () {
            $scope.loading = true;
            companyService.getCompanyList().then(function (data) {
                $scope.companyList = data.data;
                $scope.totalItems = $scope.companyList.length;
                 $scope.loading = false;
            }, function (data) {
                alert("An Error has occured while getting company list! " + data);
            });
        }

        var getCompanyTypeList = function () {
            companyTypeService.getCompanyTypeList().then(function (data) {
                $scope.companyTypeList = data.data;
            }, function (data) {
                alert("An Error has occured while getting CompanyType list! " + data);
            });
        }

        var getStateList = function () {
            stateService.getStateList().then(function (data) {
                $scope.stateList = data.data;
            }, function (data) {
                alert("An Error has occured while getting State list! " + data);
            });
        }

        var getCountryList = function () {
            countryService.getCountryList().then(function (data) {
                $scope.countryList = data.data;
            }, function (data) {
                alert("An Error has occured while getting Country list! " + data);
            });
        }

        getCompanyList();
        getCompanyTypeList();
        getStateList();
        getCountryList();

        //alert(JSON.stringify($scope.companyList));

        if ($routeParams.companyId) {
            companyService.getCompany($routeParams.companyId).then(function (data) {
                $scope.company = data.data;
                //$scope.customers.push(data);
                $scope.editableCompany = angular.copy($scope.company);
                $scope.companyTypeValue = angular.copy($scope.company.companyType);
            }, function (data) {
                alert("An Error has occured while getting company! " + data);
                //$scope.loading = false;
            });
        }
        else {
            $scope.company = { companyId: 0, companyType: {} };
            //$scope.companyList = getcompanyList();
            $scope.companyTypeValue = null;
        }

        $scope.addNewCompany = function () {
            $location.path('/newCompany');
        };

        $scope.updateCompany = function (id) {
            $location.path('/updateCompany/' + id);
        };
        
        $scope.deleteCompany = function (id) {
            if (id != undefined) {
                var r = confirm("Are you sure you want to delete this record?");
                if (r == true) {
                    companyService.deleteCompany(id).then(function (data) {
                        alert("deleted Successfully!!");
                        //$scope.customers.push(data);
                        getCompanyList();
                        $location.path('/company');
                    }, function (data) {
                        alert("An Error has occured while deleting company! " + data);
                        //$scope.loading = false;
                    });
                } else {
                    getCompanyList();
                    $location.path('/company');
                }
               
            }
        };

        //$scope.companyList = function () {
        //    companyService.getcompanyList().then(function (data) {
        //        return data.data;
        //    }, function (data) {
        //        alert("An Error has occured while getting company list! " + data);
        //    });
        //}
        //alert($scope.company);
        $scope.submitForm = function () {
            $scope.editableCompany.companyType = { companyTypeId: $scope.companyTypeValue.companyTypeId }; // = angular.copy($scope.companyTypeValue);// {companyTypeId : $scope.companyTypeValue.companyTypeId, companyTypeName : $scope.companyTypeValue.companyTypeName, isActive: $scope.companyTypeValue.isActive};
            if ($scope.editableCompany.companyId == undefined) {
                companyService.insertCompany($scope.editableCompany).then(function (data) {
                    alert("Added Successfully!!");
                    //$scope.customers.push(data);
                    getCompanyList();
                    $location.path('/company');
                },function (data) {
                    alert("An Error has occured while Adding company! " + data);
                    //$scope.loading = false;
                });
            }
            else {
                companyService.updateCompany($scope.editableCompany).then(function (data) {
                    alert("Updated Successfully!!");
                    getCompanyList();
                    $location.path('/company');
                    //$scope.customers.push(data);
                }, function (data) {
                    alert("An Error has occured while updating company! " + data);
                    //$scope.loading = false;
                });
            }

            $scope.company = angular.copy($scope.editableCompany);
            $scope.loading = true;
            //$window.history.back();
        };

        $scope.cancelForm = function () {
            $window.history.back();
        };

        $scope.currentPage = 1;
        $scope.itemsPerPage = 2;
        $scope.maxSize = 5;
    }]);