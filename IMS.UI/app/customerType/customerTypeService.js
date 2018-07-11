IMSApp.factory("customerTypeService",["$http",
    function ($http) {
        var getCustomerType = function (id) {
            return $http.get('http://pihipdevweb01/api/customerType/GetCustomerTypeById/?customerTypeId=' + id)
        }

        var insertCustomerType = function (newCustomerType) {
            //alert(newCustomerType.customerTypeName);
            return $http.post('http://pihipdevweb01/api/customerType/AddCustomerType', newCustomerType);
            //return newCustomerType;
        }

        var updateCustomerType = function (customerType) {
            return $http.post('http://pihipdevweb01/api/customerType/EditCustomerType', customerType );
            //return customerType;
        }

        var getCustomerTypeList = function () {
            return $http.get('http://pihipdevweb01/api/customerType/GetCustomerTypeList');
        }
        var deleteCustomerType = function (customerType) {
            return $http.post('http://pihipdevweb01/api/customerType/DeleteCustomerType', customerType);
        }
        return {
            insertCustomerType: insertCustomerType,
            updateCustomerType: updateCustomerType,
            getCustomerType: getCustomerType,
            getCustomerTypeList: getCustomerTypeList,
            deleteCustomerType: deleteCustomerType
        }

    }]);