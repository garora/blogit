/// <reference path="../../../typings/references.d.ts" />
var app;
(function (app) {
    var admin;
    (function (admin) {
        var users;
        (function (users) {
            'use strict';
            var UserController = (function () {
                function UserController() {
                }
                return UserController;
            })();
            angular.module('blogitAdmin').controller('app.admin.users.UserController', UserController);
        })(users = admin.users || (admin.users = {}));
    })(admin = app.admin || (app.admin = {}));
})(app || (app = {}));
//# sourceMappingURL=user.controller.js.map