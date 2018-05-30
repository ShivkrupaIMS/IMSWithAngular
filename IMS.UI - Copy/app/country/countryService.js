IMSApp.factory("countryService",["$http",
    function ($http) {
        var getCountry = function (id) {
            if (id == 1) {
                return {
                    id: 1,
                    countryName: "India",
                    countryCode: "IN",
                    isActive: true,
                }
            }
            return undefined;
        }

        var insertCountry = function (newCountry) {
            return true;
        }

        var updateCountry = function (Country) {
            return true;
        }

        return {
            insertCountry: insertCountry,
            updateCountry: updateCountry,
            getCountry: getCountry
        }

    }]);