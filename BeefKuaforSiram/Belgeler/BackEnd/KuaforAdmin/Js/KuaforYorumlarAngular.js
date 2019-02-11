var app = angular.module("MyAppYorumlar", []);


app.controller("yorumlar", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/KuaforYorum/GetKuaforYorumlar/" + x).then(function (response) {
        $scope.yrm = response.data;
    });
});

app.controller("yorumlarIncele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforYorum/GetKuaforYorumlarIncele/" + secondLevelLocation).then(function (response) {
        $scope.yorumlarIncele = response.data;
    });
});