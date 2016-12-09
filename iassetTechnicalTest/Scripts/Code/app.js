(function () {
    angular.module("app", [])
        .controller("controller", ["$scope", "$http", function ($scope, $http) {
            $scope.greeting = "iasset Technical Test";
            $scope.allcities = [];
            $scope.citis = [];
            $scope.country = ""
            $scope.cityinfo = null
            $scope.currentFilter = 'A';

            $scope.getCities = function () {
                loadCities($http, $scope, $scope.country);
            }

            $scope.filterByFirstLetter = function (filter) {
                filterByFirstLetter($scope, filter)
            }

            $scope.getCityWeatherInfo = function (city, country) {
                getCityWeatherInfo($http, $scope, city, country);
            }
        }])
})()