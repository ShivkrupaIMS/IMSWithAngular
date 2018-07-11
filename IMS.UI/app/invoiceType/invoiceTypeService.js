IMSApp.factory("invoiceTypeService",["$http",
    function ($http) {
        var getInvoiceType = function (id) {
            return $http.get('http://pihipdevweb01/api/invoiceType/GetInvoiceTypeById/?invoiceTypeId=' + id)
        }

        var insertInvoiceType = function (newInvoiceType) {
            //alert(newInvoiceType.invoiceTypeName);
            return $http.post('http://pihipdevweb01/api/invoiceType/AddInvoiceType', newInvoiceType);
            //return newInvoiceType;
        }

        var updateInvoiceType = function (invoiceType) {
            return $http.post('http://pihipdevweb01/api/invoiceType/EditInvoiceType', invoiceType );
            //return invoiceType;
        }

        var getInvoiceTypeList = function () {
            return $http.get('http://pihipdevweb01/api/invoiceType/GetInvoiceTypeList');
        }
        var deleteInvoiceType = function (invoiceType) {
            return $http.post('http://pihipdevweb01/api/invoiceType/DeleteInvoiceType', invoiceType);
        }
        return {
            insertInvoiceType: insertInvoiceType,
            updateInvoiceType: updateInvoiceType,
            getInvoiceType: getInvoiceType,
            getInvoiceTypeList: getInvoiceTypeList,
            deleteInvoiceType: deleteInvoiceType
        }

    }]);