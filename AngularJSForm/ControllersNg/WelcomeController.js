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
    .controller("welcomeCtrl", ["$scope","$http",
        function ($scope, $http) {
            $scope.toShow = false;
            $scope.getallData = function() {
                $http.get("/Home/GetAllCustomers").then(successGet, errorGet);
                function successGet(data) {
                    $scope.customers = data;
                    $scope.toShow = true;
                }
                function errorGet() {
                        $scope.message = "Unexpected Error while loading data!!";
                        $scope.result = "color-red";
                        console.log($scope.message);
                }
            }
        }]);
