IMSApp.factory("itemUnitService",["$http",
    function ($http) {
        var getItemUnit = function (id) {
            return $http.get('http://pihipdevweb01/api/itemUnit/GetItemUnitById/?itemUnitId=' + id)
        }

        var insertItemUnit = function (newItemUnit) {
            //alert(newItemUnit.itemUnitName);
            return $http.post('http://pihipdevweb01/api/itemUnit/AddItemUnit', newItemUnit);
            //return newItemUnit;
        }

        var updateItemUnit = function (itemUnit) {
            return $http.post('http://pihipdevweb01/api/itemUnit/EditItemUnit', itemUnit );
            //return itemUnit;
        }

        var getItemUnitList = function () {
            return $http.get('http://pihipdevweb01/api/itemUnit/GetItemUnitList');
        }
        var deleteItemUnit = function (itemUnit) {
            return $http.post('http://pihipdevweb01/api/itemUnit/DeleteItemUnit', itemUnit);
        }
        return {
            insertItemUnit: insertItemUnit,
            updateItemUnit: updateItemUnit,
            getItemUnit: getItemUnit,
            getItemUnitList: getItemUnitList,
            deleteItemUnit: deleteItemUnit
        }

    }]);