(function () {
    'use strict';

    angular
        .module('app.account')
        .controller('Account', Account);

    /* @ngInject */
    function Account(logger, dataserviceAccount, common, currentUser) {
        var vm = this;
        vm.title = 'Account';
        vm.username = 'kirk';
        vm.password = 'password';
        vm.currentUser = currentUser

        vm.login = login;


        function login() {
            dataserviceAccount.login(vm.username, vm.password);
        }
    }
})();
