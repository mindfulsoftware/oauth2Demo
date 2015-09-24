(function () {
    'use strict';

    angular
        .module('app.layout')
        .controller('Shell', Shell);

    Shell.$inject = ['config', 'logger'];

    function Shell(config, logger) {
        /*jshint validthis: true */
        var vm = this;

        vm.title = config.appTitle;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;

        activate();

        function activate() {
            logger.success(config.appTitle + ' loaded!', null);
        }
    }
})();
