(function () {
    'use strict';

    angular
        .module('app.claims')
        .controller('Claims', Claims);

    /* @ngInject */
    function Claims(logger, dataserviceClaims) {
        var vm = this;
        vm.title = 'Claims';
        vm.claims = [];

        activate();

        function activate() {
            return getClaims().then(function () {
                logger.info('Activated Claims View');
            });
        }

        function getClaims() {
            return dataserviceClaims.getClaimsForUser()
                .then(function (data) {
                    vm.claims = data;
                    return vm.claims;
                });
        }
    }
})();
