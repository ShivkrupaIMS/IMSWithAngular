IMSApp.factory("licenseTypeService",["$http",
    function ($http) {
        var getLicenseType = function (id) {
            return $http.get('http://pihipdevweb01/api/licenseType/GetLicenseTypeById/?licenseTypeId=' + id)
        }

        var insertLicenseType = function (newLicenseType) {
            //alert(newLicenseType.licenseTypeName);
            return $http.post('http://pihipdevweb01/api/licenseType/AddLicenseType', newLicenseType);
            //return newLicenseType;
        }

        var updateLicenseType = function (licenseType) {
            return $http.post('http://pihipdevweb01/api/licenseType/EditLicenseType', licenseType );
            //return licenseType;
        }

        var getLicenseTypeList = function () {
            return $http.get('http://pihipdevweb01/api/licenseType/GetLicenseTypeList');
        }
        var deleteLicenseType = function (licenseType) {
            return $http.post('http://pihipdevweb01/api/licenseType/DeleteLicenseType', licenseType);
        }
        return {
            insertLicenseType: insertLicenseType,
            updateLicenseType: updateLicenseType,
            getLicenseType: getLicenseType,
            getLicenseTypeList: getLicenseTypeList,
            deleteLicenseType: deleteLicenseType
        }

    }]);