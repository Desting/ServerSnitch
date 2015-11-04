(function () {
    'use strict';

    angular
        .module('serverMonitor')



    .controller('customersCtrl', function ($scope, $http) {
        $http.get("http://www.w3schools.com/angular/customers.php")
        .success(function (response) { $scope.names = response.records; });
    })

    .controller('serverController', function ($scope, $http) {
        // Simple GET request example:
        $http({
            method: 'GET',
            url: 'http://localhost:60883/home/entities'
        }).then(function successCallback(response) {
            $scope.servers = response.data;
            // this callback will be called asynchronously
            // when the response is available
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });
    })
    ;;


    

    

})();