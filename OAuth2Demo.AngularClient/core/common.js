(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('common', common);

    common.$inject = ['$location', '$q', '$rootScope', '$timeout', 'logger'];

    /* @ngInject */
    function common($location, $q, $rootScope, $timeout, logger) {

        var service = {
            // common angular dependencies
            $broadcast: $broadcast,
            $q: $q,
            $timeout: $timeout,

            // generic
            formEncode: formEncode
        };

        return service;

        function $broadcast() {
            return $rootScope.$broadcast.apply($rootScope, arguments);
        }

        function formEncode (data) {
            var pairs = [];

            for (var name in data) {
                pairs.push(encodeURIComponent(name) + '=' + encodeURIComponent(data[name]));
            }

            return pairs.join('&').replace(/%20/g, '+');
        }
    }
})();