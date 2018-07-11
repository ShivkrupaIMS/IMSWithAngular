IMSApp.factory("supplierTypeService",["$http",
    function ($http) {
        var getSupplierType = function (id) {
            return $http.get('http://pihipdevweb01/api/supplierType/GetSupplierTypeById/?supplierTypeId=' + id)
        }

        var insertSupplierType = function (newSupplierType) {
            //alert(newSupplierType.supplierTypeName);
            return $http.post('http://pihipdevweb01/api/supplierType/AddSupplierType', newSupplierType);
            //return newSupplierType;
        }

        var updateSupplierType = function (supplierType) {
            return $http.post('http://pihipdevweb01/api/supplierType/EditSupplierType', supplierType );
            //return supplierType;
        }

        var getSupplierTypeList = function () {
            return $http.get('http://pihipdevweb01/api/supplierType/GetSupplierTypeList');
        }
        var deleteSupplierType = function (supplierType) {
            return $http.post('http://pihipdevweb01/api/supplierType/DeleteSupplierType', supplierType);
        }
        return {
            insertSupplierType: insertSupplierType,
            updateSupplierType: updateSupplierType,
            getSupplierType: getSupplierType,
            getSupplierTypeList: getSupplierTypeList,
            deleteSupplierType: deleteSupplierType
        }

    }]);