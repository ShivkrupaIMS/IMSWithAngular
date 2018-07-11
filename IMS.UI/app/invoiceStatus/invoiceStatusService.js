IMSApp.factory("invoiceStatusService",["$http",
    function ($http) {
        var getInvoiceStatus = function (id) {
            return $http.get('http://pihipdevweb01/api/invoiceStatus/GetInvoiceStatusById/?invoiceStatusId=' + id)
        }

        var insertInvoiceStatus = function (newInvoiceStatus) {
            //alert(newInvoiceStatus.invoiceStatusName);
            return $http.post('http://pihipdevweb01/api/invoiceStatus/AddInvoiceStatus', newInvoiceStatus);
            //return newInvoiceStatus;
        }

        var updateInvoiceStatus = function (invoiceStatus) {
            return $http.post('http://pihipdevweb01/api/invoiceStatus/EditInvoiceStatus', invoiceStatus );
            //return invoiceStatus;
        }

        var getInvoiceStatusList = function () {
            return $http.get('http://pihipdevweb01/api/invoiceStatus/GetInvoiceStatusList');
        }
        var deleteInvoiceStatus = function (invoiceStatus) {
            return $http.post('http://pihipdevweb01/api/invoiceStatus/DeleteInvoiceStatus', invoiceStatus);
        }
        return {
            insertInvoiceStatus: insertInvoiceStatus,
            updateInvoiceStatus: updateInvoiceStatus,
            getInvoiceStatus: getInvoiceStatus,
            getInvoiceStatusList: getInvoiceStatusList,
            deleteInvoiceStatus: deleteInvoiceStatus
        }

    }]);