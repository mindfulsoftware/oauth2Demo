(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('currentUser', currentUser);

    function currentUser() {

        var service = {
            username: '[not set]',
            token: '',
            setProfile: setProfile,

            get loggedIn() {
                return this.token !== '';
            }
        };

        return service;

        function setProfile(username, token) {
            this.username = username;
            this.token = token;
        }
    }
})();