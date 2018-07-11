IMSApp.factory("invoiceTermService",["$http",
    function ($http) {
        var getInvoiceTerm = function (id) {
            return $http.get('http://pihipdevweb01/api/invoiceTerm/GetInvoiceTermById/?invoiceTermId=' + id)
        }

        var insertInvoiceTerm = function (newInvoiceTerm) {
            //alert(newInvoiceTerm.invoiceTermName);
            return $http.post('http://pihipdevweb01/api/invoiceTerm/AddInvoiceTerm', newInvoiceTerm);
            //return newInvoiceTerm;
        }

        var updateInvoiceTerm = function (invoiceTerm) {
            return $http.post('http://pihipdevweb01/api/invoiceTerm/EditInvoiceTerm', invoiceTerm );
            //return invoiceTerm;
        }

        var getInvoiceTermList = function () {
            return $http.get('http://pihipdevweb01/api/invoiceTerm/GetInvoiceTermList');
        }
        var deleteInvoiceTerm = function (invoiceTerm) {
            return $http.post('http://pihipdevweb01/api/invoiceTerm/DeleteInvoiceTerm', invoiceTerm);
        }
        return {
            insertInvoiceTerm: insertInvoiceTerm,
            updateInvoiceTerm: updateInvoiceTerm,
            getInvoiceTerm: getInvoiceTerm,
            getInvoiceTermList: getInvoiceTermList,
            deleteInvoiceTerm: deleteInvoiceTerm
        }

    }]);