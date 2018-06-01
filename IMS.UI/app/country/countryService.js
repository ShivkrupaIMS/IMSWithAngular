IMSApp.factory("countryService",["$http",
    function ($http) {
        var getCountry = function (id) {
            return $http.get('http://pihipdevweb01/api/country/GetCountryById/?countryId=' + id)
        }

        var insertCountry = function (newCountry) {
            //alert(newCountry.countryName);
            return $http.post('http://pihipdevweb01/api/country/AddCountry', newCountry);
            //return newCountry;
        }

        var updateCountry = function (country) {
            return $http.post('http://pihipdevweb01/api/country/EditCountry', country );
            //return country;
        }

        var getCountryList = function () {
            return $http.get('http://pihipdevweb01/api/country/GetCountryList');
        }
        var deleteCountry = function (country) {
            return $http.post('http://pihipdevweb01/api/country/DeleteCountry', country);
        }
        return {
            insertCountry: insertCountry,
            updateCountry: updateCountry,
            getCountry: getCountry,
            getCountryList: getCountryList,
            deleteCountry: deleteCountry
        }

    }]);