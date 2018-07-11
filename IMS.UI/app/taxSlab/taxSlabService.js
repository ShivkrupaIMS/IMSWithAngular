IMSApp.factory("taxSlabService",["$http",
    function ($http) {
        var getTaxSlab = function (id) {
            return $http.get('http://pihipdevweb01/api/taxSlab/GetTaxSlabById/?taxSlabId=' + id)
        }

        var insertTaxSlab = function (newTaxSlab) {
            //alert(newTaxSlab.taxSlabName);
            return $http.post('http://pihipdevweb01/api/taxSlab/AddTaxSlab', newTaxSlab);
            //return newTaxSlab;
        }

        var updateTaxSlab = function (taxSlab) {
            return $http.post('http://pihipdevweb01/api/taxSlab/EditTaxSlab', taxSlab );
            //return taxSlab;
        }

        var getTaxSlabList = function () {
            return $http.get('http://pihipdevweb01/api/taxSlab/GetTaxSlabList');
        }
        var deleteTaxSlab = function (taxSlab) {
            return $http.post('http://pihipdevweb01/api/taxSlab/DeleteTaxSlab', taxSlab);
        }
        return {
            insertTaxSlab: insertTaxSlab,
            updateTaxSlab: updateTaxSlab,
            getTaxSlab: getTaxSlab,
            getTaxSlabList: getTaxSlabList,
            deleteTaxSlab: deleteTaxSlab
        }

    }]);