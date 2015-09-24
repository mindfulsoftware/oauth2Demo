(function () {
    'use strict';

    angular
        .module('app.data')
        .factory('dataserviceAccount', dataserviceAccount);

    dataserviceAccount.$inject = ['$http', '$location', '$q', 'exception', 'logger', 'common'];

    function dataserviceAccount($http, $location, $q, exception, logger, common) {

        var service = {
            login: login,
            logoff: logoff
        };

        return service;


        function login(username, password) {

            var config = {
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                }
            };

            var data = common.formEncode({
                username: username,
                password: password,
                grant_type: 'password'
            });

            return $http.post('https://localhost:44306/api/account/login', data, config)
                .then(getloginComplete)
                .catch(function (err) {
                    exception.catcher('XHR Failed for account login')(err);
                });

            function getloginComplete(data, status, headers, config) {
                return data.data[0].data.results;
            }
        }

        function logoff(username) {

        }
    }
})();

