(function () {
    'use strict';

    angular
        .module('app.account')
        .run(appRun);

    // appRun.$inject = ['routehelper']

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/account',
                config: {
                    templateUrl: 'account/account.html',
                    controller: 'Account',
                    controllerAs: 'vm',
                    title: 'Account',
                    settings: { }
                }
            }
        ];
    }
})();