IMSApp.factory("companyTypeService",["$http",
    function ($http) {
        var getCompanyType = function (id) {
            return $http.get('http://pihipdevweb01/api/companyType/GetCompanyTypeById/?companyTypeId=' + id)
        }

        var insertCompanyType = function (newCompanyType) {
            //alert(newCompanyType.companyTypeName);
            return $http.post('http://pihipdevweb01/api/companyType/AddCompanyType', newCompanyType);
            //return newCompanyType;
        }

        var updateCompanyType = function (companyType) {
            return $http.post('http://pihipdevweb01/api/companyType/EditCompanyType', companyType );
            //return companyType;
        }

        var getCompanyTypeList = function () {
            return $http.get('http://pihipdevweb01/api/companyType/GetCompanyTypeList');
        }
        var deleteCompanyType = function (companyType) {
            return $http.post('http://pihipdevweb01/api/companyType/DeleteCompanyType', companyType);
        }
        return {
            insertCompanyType: insertCompanyType,
            updateCompanyType: updateCompanyType,
            getCompanyType: getCompanyType,
            getCompanyTypeList: getCompanyTypeList,
            deleteCompanyType: deleteCompanyType
        }

    }]);