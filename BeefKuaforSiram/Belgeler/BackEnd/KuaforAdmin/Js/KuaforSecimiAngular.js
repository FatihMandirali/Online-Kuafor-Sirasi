var app = angular.module("kuaorAdminKuaforSecimi", []);




app.controller("secilecekKuaforler", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/Kuaforler/KuaforSecimiList/" + x).then(function (response) {
        $scope.kuaforsecim = response.data;
    });
});