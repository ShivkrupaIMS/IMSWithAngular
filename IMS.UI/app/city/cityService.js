IMSApp.factory("cityService",["$http",
    function ($http) {
        var getCity = function (id) {
            return $http.get('http://pihipdevweb01/api/city/GetcityById/?cityId=' + id)
        }

        var insertCity = function (newCity) {
            return $http.post('http://pihipdevweb01/api/city/AddCity', newCity);
            //return newcity;
        }

        var updateCity = function (city) {
            return $http.post('http://pihipdevweb01/api/city/EditCity', city );
            //return city;
        }

        var getCityList = function () {
            return $http.get('http://pihipdevweb01/api/city/GetCityList');
        }
        var deleteCity = function (city) {
            return $http.post('http://pihipdevweb01/api/city/DeleteCity', city);
        }
        return {
            insertCity: insertCity,
            updateCity: updateCity,
            getCity: getCity,
            getCityList: getCityList,
            deleteCity: deleteCity
        }

    }]);