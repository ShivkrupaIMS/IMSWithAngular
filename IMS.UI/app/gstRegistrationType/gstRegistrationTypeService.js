IMSApp.factory("gstRegistrationTypeService",["$http",
    function ($http) {
        var getGSTRegistrationType = function (id) {
            return $http.get('http://pihipdevweb01/api/gstRegistrationType/GetGSTRegistrationTypeById/?gstRegistrationTypeId=' + id)
        }

        var insertGSTRegistrationType = function (newGSTRegistrationType) {
            //alert(newGSTRegistrationType.gstRegistrationTypeName);
            return $http.post('http://pihipdevweb01/api/gstRegistrationType/AddGSTRegistrationType', newGSTRegistrationType);
            //return newGSTRegistrationType;
        }

        var updateGSTRegistrationType = function (gstRegistrationType) {
            return $http.post('http://pihipdevweb01/api/gstRegistrationType/EditGSTRegistrationType', gstRegistrationType );
            //return gstRegistrationType;
        }

        var getGSTRegistrationTypeList = function () {
            return $http.get('http://pihipdevweb01/api/gstRegistrationType/GetGSTRegistrationTypeList');
        }
        var deleteGSTRegistrationType = function (gstRegistrationType) {
            return $http.post('http://pihipdevweb01/api/gstRegistrationType/DeleteGSTRegistrationType', gstRegistrationType);
        }
        return {
            insertGSTRegistrationType: insertGSTRegistrationType,
            updateGSTRegistrationType: updateGSTRegistrationType,
            getGSTRegistrationType: getGSTRegistrationType,
            getGSTRegistrationTypeList: getGSTRegistrationTypeList,
            deleteGSTRegistrationType: deleteGSTRegistrationType
        }

    }]);