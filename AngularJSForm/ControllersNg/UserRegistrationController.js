"use strict";


angular.module("sample.userRegistration", ["ngRoute"])
    .config([
        "$routeProvider", function($routeProvider) {
            $routeProvider.when("/userRegistration",
            {
                templateUrl: "../Views/Home/UserRegistration.cshtml",
                controller: "userRegistrationCtrl"
            });
        }
    ])
    .controller("userRegistrationCtrl",
        function($scope, $http, $location, $window) {
            $scope.cust = {};
            $scope.message = "";
            $scope.result = "color-default";
            $scope.isViewLoading = false;

            //get called when user submits the form
            $scope.submitForm = function() {
                $scope.isViewLoading = true;
                console.log("Form is submitted with:", $scope.cust);

                //$http service that send or receive data from the remote server
                $http({
                    method: "POST",
                    url: "/Home/CreateCustomer",
                    data: $scope.cust
                }).then(successCallback, errorCallback);

                function successCallback(data) {
                    $scope.errors = [];
                    if (data.data.success) {
                        $scope.cust = {};
                        $scope.message = "Form data Submitted!";
                        $scope.result = "color-green";
                        $location.path(data.data.redirectUrl);
                        $window.location.href = data.data.redirectUrl;
                    } 
                }

                function errorCallback() {
                    $scope.errors = [];
                    $scope.message = "Unexpected Error while saving data!!";
                }

                $scope.isViewLoading = false;
            }
        });

