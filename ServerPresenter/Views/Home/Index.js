angular.module('Index', [])

.controller('MainCtrl', function ($scope) {

    $scope.categories = [
            { "id": 0, "name": "Development" },
            { "id": 1, "name": "Design" },
            { "id": 3, "name": "Exercise" },
            { "id": 2, "name": "Humor" },
    ];

});
