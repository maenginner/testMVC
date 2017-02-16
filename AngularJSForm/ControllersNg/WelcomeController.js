"use strict";


angular.module("sample.welcome", ["ngRoute"])
    .config([
        "$routeProvider", function($routeProvider) {
            $routeProvider.when("/Welcome",
            {
                templateUrl: "../Views/Home/Welcome.cshtml",
                controller: "welcomeCtrl"
            });
        }
    ])
    .controller("welcomeCtrl",
        function($scope, $http, $location, $window) {
            console.log("ALL RIGHT");
        });
