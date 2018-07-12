IMSApp.factory("companyService",["$http",
    function ($http) {
        var getCompany = function (id) {
            return $http.get('http://pihipdevweb01/api/company/GetcompanyById/?companyId=' + id)
        }

        var insertCompany = function (newCompany) {
            return $http.post('http://pihipdevweb01/api/company/AddCompany', newCompany);
            //return newcompany;
        }

        var updateCompany = function (company) {
            return $http.post('http://pihipdevweb01/api/company/EditCompany', company );
            //return company;
        }

        var getCompanyList = function () {
            return $http.get('http://pihipdevweb01/api/company/GetCompanyList');
        }
        var deleteCompany = function (company) {
            return $http.post('http://pihipdevweb01/api/company/DeleteCompany', company);
        }
        return {
            insertCompany: insertCompany,
            updateCompany: updateCompany,
            getCompany: getCompany,
            getCompanyList: getCompanyList,
            deleteCompany: deleteCompany
        }

    }]);