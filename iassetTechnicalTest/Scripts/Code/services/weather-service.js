function loadCities($http, $scope, countryName) {
    clearCurrentInfo($scope);
    $http({
        method: 'GET',
        url: '/v1/counteries/' + countryName + "/cities"
    }).then(function successCallback(response) {
        $scope.allcities = response.data;
        filterByFirstLetter($scope, 'A');
        $scope.errorMessage = "";
    }, function errorCallback(response) {
        if (response.status == 404) {
            $scope.errorMessage = "Can't find any data for " + countryName;
        } else if (response.status == 500) {
            $scope.errorMessage = "Internal server error ";
        } else {
            $scope.errorMessage = "Error ";
        }
    });
}

function getCityWeatherInfo($http, $scope, city, country) {
    $http({
        method: 'GET',
        url: '/v1/city/' + city + "/" + country + "/weather"
    }).then(function successCallback(response) {
        $scope.cityinfo = response.data;
        $scope.selectedcity = city;
        $scope.errorMessage = "";
    }, function errorCallback(response) {
        if (response.status == 404) {
            $scope.errorMessage = "Can't find any data for " + city;
        } else if (response.status == 500) {
            $scope.errorMessage = "Internal server error ";
        } else {
            $scope.errorMessage = "Error ";
        }
    });
}

function filterByFirstLetter($scope, letter) {
    $scope.currentFilter = letter;
    $scope.cities = [];
    $scope.allcities.map(function (item, index) {
        if (item.length > 0 && item[0] == letter) {
            $scope.cities.push(item);
        }
    });
}

function clearCurrentInfo($scope) {
    $scope.allcities = [];
    $scope.errorMessage = null;
    $scope.cityinfo = null;
    $scope.cities = [];
    $scope.currentFilter = 'A';
    $scope.selectedcity = "";
}
