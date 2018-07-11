IMSApp.factory("accountingMethodService",["$http",
    function ($http) {
        var getAccountingMethod = function (id) {
            return $http.get('http://pihipdevweb01/api/accountingMethod/GetAccountingMethodById/?accountingMethodId=' + id)
        }

        var insertAccountingMethod = function (newAccountingMethod) {
            //alert(newAccountingMethod.accountingMethodName);
            return $http.post('http://pihipdevweb01/api/accountingMethod/AddAccountingMethod', newAccountingMethod);
            //return newAccountingMethod;
        }

        var updateAccountingMethod = function (accountingMethod) {
            return $http.post('http://pihipdevweb01/api/accountingMethod/EditAccountingMethod', accountingMethod );
            //return accountingMethod;
        }

        var getAccountingMethodList = function () {
            return $http.get('http://pihipdevweb01/api/accountingMethod/GetAccountingMethodList');
        }
        var deleteAccountingMethod = function (accountingMethod) {
            return $http.post('http://pihipdevweb01/api/accountingMethod/DeleteAccountingMethod', accountingMethod);
        }
        return {
            insertAccountingMethod: insertAccountingMethod,
            updateAccountingMethod: updateAccountingMethod,
            getAccountingMethod: getAccountingMethod,
            getAccountingMethodList: getAccountingMethodList,
            deleteAccountingMethod: deleteAccountingMethod
        }

    }]);