module app.admin.users {
    'use strict';

    export interface IUserController {
    }

    class UserController {

    }

    angular
        .module('blogitAdmin')
        .controller('app.admin.users.UserController',
        UserController);

}