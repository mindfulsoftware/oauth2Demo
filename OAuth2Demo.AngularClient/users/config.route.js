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
                url: '/claims',
                config: {
                    templateUrl: 'users/claims.html',
                    controller: 'Claims',
                    controllerAs: 'vm',
                    title: 'Claims',
                    settings: {}
                }
            }
        ];
    }
})();