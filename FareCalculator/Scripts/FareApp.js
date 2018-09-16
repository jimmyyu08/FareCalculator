var app = angular.module('fareApp', [])
.controller('myCtrl', function ($scope, $http, $window) {
    $scope.ButtonClick = function () {
        var TaxiRide = {
            state: $scope.ride.state,
            miles: $scope.ride.miles,
            minutes: $scope.ride.minutes,
            RideTime: new Date(Date.UTC($scope.ride.ridedate.getFullYear(), $scope.ride.ridedate.getMonth(), $scope.ride.ridedate.getDate(), $scope.ride.ridetime.getHours(), $scope.ride.ridetime.getMinutes()))
        };
        var headers = { 'Content-Type': 'application/x-www-form-urlencoded' };
        $http.post("/api/Meter/Calculate", TaxiRide, headers).then(function (data) {
            $scope.cost = data.data.cost;
        },
        function (data) {
            console.error(data);
        });
    }
});