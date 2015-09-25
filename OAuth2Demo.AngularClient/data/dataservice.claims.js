(function () {
    'use strict';

    angular
        .module('app.data')
        .factory('dataserviceClaims', dataserviceClaims);

    dataserviceClaims.$inject = ['$http', '$location', '$q', 'exception', 'logger', 'common'];

    function dataserviceClaims($http, $location, $q, exception, logger, common) {

        var service = {
            getClaimsForUser: getClaimsForUser
        };

        return service;


        function getClaimsForUser() {

            return $http.get('https://localhost:44306/api/claims')
                .then(getClaimsForUserComplete)
                .catch(function (err) {
                    exception.catcher('XHR Failed for getClaimsForUser')(err);
                });

            function getClaimsForUserComplete(response, status, headers, config) {
                return response.data;
            }
        }
    }
})();

