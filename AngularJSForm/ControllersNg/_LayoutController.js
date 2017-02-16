"use strict";

var myApp = angular.module("sample",
[
    "ngRoute",
    "sample.userRegistration",
    "sample.welcome"
]).config([
    "$routeProvider", "$httpProvider", "$locationProvider", function($routeProvider, $httpProvider, $locationProvider) {
        $routeProvider.otherwise({ redicrectTo: "/Welcome" });
        $httpProvider.defaults.headers.common["X-Requested-With"] = "XMLHttpRequest";
        $locationProvider.html5Mode(true);


    }
]).controller("mainView",
[
    "$rootScope", "$scope", "$http", "$location", function($rootScope, $scope, $http, $location) {

    }
]);