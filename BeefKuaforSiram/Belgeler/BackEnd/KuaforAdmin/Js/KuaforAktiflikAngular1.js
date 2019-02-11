var app = angular.module("deneme", []);




app.controller("dene", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/KuaforAktiflik/Ozellestirilmis/" + x).then(function (response) {
        $scope.firsat = response.data;
    });
});