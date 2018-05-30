IMSApp.factory("countryService",["$http",
    function ($http) {
        var getCountry = function (id) {
            alert(id);
            return $http.get('http://localhost:53770/api/country/GetCountryById/'+ id)
            //if (id == 1) {
            //    return {
            //        id: 1,
            //        countryName: "India",
            //        countryCode: "IN",
            //        isActive: true,
            //    }
            //}
            return undefined;
        }

        var insertCountry = function (newCountry) {
            //alert(newCountry.countryName);
            return $http.post('http://localhost:53770/api/country/AddCountry', newCountry);
        }

        var updateCountry = function (Country) {
            return true;
        }

        return {
            insertCountry: insertCountry,
            updateCountry: updateCountry,
            getCountry: getCountry
        }

    }]);