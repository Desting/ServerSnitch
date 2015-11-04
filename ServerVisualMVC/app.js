


var serverMonitor = angular.module('serverMonitor', ['ngRoute']);

serverMonitor.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Pages/home',
            controller: 'mainController'
        })

        // route for the about page
        .when('/details', {
            templateUrl: 'Pages/details',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'Pages/contact',
            controller: 'contactController'
        });

    // use the HTML5 History API
    //$locationProvider.html5Mode(true);
});


serverMonitor.service("serverService", function SetSelected() {
    var server;

    return {
        getServer: function () {
            return server;
        },
        setServer: function (value) {
            server = value;
        }

    };
});

// create the controller and inject Angular's $scope
serverMonitor.controller('mainController', function ($scope, $http, $location, serverService) {
        

    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
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
    $scope.setServer = function (server) {
        serverService.setServer(server);
        $location.path("/details");
    };

});

    serverMonitor.controller('aboutController', function ($scope, serverService) {
        $scope.server = serverService.getServer();
    $scope.message = 'Look! I am an about page.';
});

serverMonitor.controller('contactController', function ($scope) {
    $scope.message = 'Nikolaj.Zimmermann.Desting@Atea.dk';
}



);

serverMonitor.controller('AccordionDemoCtrl', function ($scope) {
  $scope.oneAtATime = true;

  $scope.groups = [
    {
      title: 'Dynamic Group Header - 1',
      content: 'Dynamic Group Body - 1'
    },
    {
      title: 'Dynamic Group Header - 2',
      content: 'Dynamic Group Body - 2'
    }
  ];

  $scope.items = ['Item 1', 'Item 2', 'Item 3'];

  $scope.addItem = function() {
    var newItemNo = $scope.items.length + 1;
    $scope.items.push('Item ' + newItemNo);
  };

  $scope.status = {
    isFirstOpen: true,
    isFirstDisabled: false
  };
});