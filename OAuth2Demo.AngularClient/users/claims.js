(function () {
    'use strict';

    angular
        .module('app.claims')
        .controller('Claims', Claims);

    /* @ngInject */
    //Claims.$inject['logger'];

    function Claims(logger) {
        var vm = this;
        vm.title = 'Claims';

        activate();

        function activate() {
        }
    }
})();
