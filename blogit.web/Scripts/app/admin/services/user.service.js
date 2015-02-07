/// <reference path="../../../typings/references.d.ts" />
var app;
(function (app) {
    var admin;
    (function (admin) {
        var services;
        (function (services) {
            'use strict';
            var UserService = (function () {
                function UserService($http) {
                    this.$http = $http;
                }
                UserService.$inject = ["$http"];
                return UserService;
            })();
            angular.module("blogitAdmin").service("app.admin.services.UserService", UserService);
        })(services = admin.services || (admin.services = {}));
    })(admin = app.admin || (app.admin = {}));
})(app || (app = {}));
//# sourceMappingURL=user.service.js.map