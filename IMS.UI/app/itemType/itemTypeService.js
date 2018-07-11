IMSApp.factory("itemTypeService",["$http",
    function ($http) {
        var getItemType = function (id) {
            return $http.get('http://pihipdevweb01/api/itemType/GetItemTypeById/?itemTypeId=' + id)
        }

        var insertItemType = function (newItemType) {
            //alert(newItemType.itemTypeName);
            return $http.post('http://pihipdevweb01/api/itemType/AddItemType', newItemType);
            //return newItemType;
        }

        var updateItemType = function (itemType) {
            return $http.post('http://pihipdevweb01/api/itemType/EditItemType', itemType );
            //return itemType;
        }

        var getItemTypeList = function () {
            return $http.get('http://pihipdevweb01/api/itemType/GetItemTypeList');
        }
        var deleteItemType = function (itemType) {
            return $http.post('http://pihipdevweb01/api/itemType/DeleteItemType', itemType);
        }
        return {
            insertItemType: insertItemType,
            updateItemType: updateItemType,
            getItemType: getItemType,
            getItemTypeList: getItemTypeList,
            deleteItemType: deleteItemType
        }

    }]);