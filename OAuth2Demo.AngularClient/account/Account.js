(function () {
    'use strict';

    angular
        .module('app.account')
        .controller('Account', Account);

    /* @ngInject */
    //Account.$inject['logger'];

    function Account(logger, dataserviceAccount) {
        var vm = this;
        vm.title = 'Account';
        vm.username = 'kirk';
        vm.password = 'password';

        vm.login = login;


        function login() {

            var result = dataserviceAccount.login(vm.username, vm.password);

        }
    }
})();
