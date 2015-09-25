(function () {
    'use strict';

    var core = angular.module('app.core')

    core.factory('tokenInterceptor', tokenInterceptor);

    /* @ngInject */
    function tokenInterceptor($q, currentUser) {

        var service = {
            request: request
        }

        return service;

        function request(config) {
            if (currentUser.loggedIn) {
                config.headers.Authorization = 'Bearer ' + currentUser.token;
            }
            return $q.when(config);
        }
    }

    core.config(function ($httpProvider) {
        $httpProvider.interceptors.push('tokenInterceptor');
    });
})();