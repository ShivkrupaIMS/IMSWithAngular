IMSApp.factory("manufacturerService",["$http",
    function ($http) {
        var getManufacturer = function (id) {
            return $http.get('http://pihipdevweb01/api/manufacturer/GetManufacturerById/?manufacturerId=' + id)
        }

        var insertManufacturer = function (newManufacturer) {
            //alert(newManufacturer.manufacturerName);
            return $http.post('http://pihipdevweb01/api/manufacturer/AddManufacturer', newManufacturer);
            //return newManufacturer;
        }

        var updateManufacturer = function (manufacturer) {
            return $http.post('http://pihipdevweb01/api/manufacturer/EditManufacturer', manufacturer );
            //return manufacturer;
        }

        var getManufacturerList = function () {
            return $http.get('http://pihipdevweb01/api/manufacturer/GetManufacturerList');
        }
        var deleteManufacturer = function (manufacturer) {
            return $http.post('http://pihipdevweb01/api/manufacturer/DeleteManufacturer', manufacturer);
        }
        return {
            insertManufacturer: insertManufacturer,
            updateManufacturer: updateManufacturer,
            getManufacturer: getManufacturer,
            getManufacturerList: getManufacturerList,
            deleteManufacturer: deleteManufacturer
        }

    }]);