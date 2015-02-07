/// <reference path="../../../typings/references.d.ts" />
module app.admin.services {
    'use strict';

    export interface IUserService {
    }

    class UserService implements IUserService {
        static $inject = ["$http"];

        constructor(private $http: ng.IHttpService) { }
    }

    angular
        .module("blogitAdmin")
        .service("app.admin.services.UserService", UserService);
} 