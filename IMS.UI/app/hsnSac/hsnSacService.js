IMSApp.factory("hsnSacService",["$http",
    function ($http) {
        var getHSNSAC = function (id) {
            return $http.get('http://pihipdevweb01/api/hsnSac/GetHSNSACById/?hsnSacId=' + id)
        }

        var insertHSNSAC = function (newHSNSAC) {
            //alert(newHSNSAC.hsnSacName);
            return $http.post('http://pihipdevweb01/api/hsnSac/AddHSNSAC', newHSNSAC);
            //return newHSNSAC;
        }

        var updateHSNSAC = function (hsnSac) {
            return $http.post('http://pihipdevweb01/api/hsnSac/EditHSNSAC', hsnSac );
            //return hsnSac;
        }

        var getHSNSACList = function () {
            return $http.get('http://pihipdevweb01/api/hsnSac/GetHSNSACList');
        }
        var deleteHSNSAC = function (hsnSac) {
            return $http.post('http://pihipdevweb01/api/hsnSac/DeleteHSNSAC', hsnSac);
        }
        return {
            insertHSNSAC: insertHSNSAC,
            updateHSNSAC: updateHSNSAC,
            getHSNSAC: getHSNSAC,
            getHSNSACList: getHSNSACList,
            deleteHSNSAC: deleteHSNSAC
        }

    }]);