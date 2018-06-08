IMSApp.factory("stateService",["$http",
    function ($http) {
        var getState = function (id) {
            return $http.get('http://pihipdevweb01/api/state/GetstateById/?stateId=' + id)
        }

        var insertState = function (newState) {
            return $http.post('http://pihipdevweb01/api/state/AddState', newState);
            //return newstate;
        }

        var updateState = function (state) {
            return $http.post('http://pihipdevweb01/api/state/EditState', state );
            //return state;
        }

        var getStateList = function () {
            return $http.get('http://pihipdevweb01/api/state/GetStateList');
        }
        var deleteState = function (state) {
            return $http.post('http://pihipdevweb01/api/state/DeleteState', state);
        }
        return {
            insertState: insertState,
            updateState: updateState,
            getState: getState,
            getStateList: getStateList,
            deleteState: deleteState
        }

    }]);