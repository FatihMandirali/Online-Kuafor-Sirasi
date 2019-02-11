var app = angular.module("MyAppMesajlar", []);


app.controller("mesajlarKullaniciKutusu", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    //alert(kuafor);
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/KuaforMesaj/GETMesajKutusuKullanicilar/" + x).then(function (response) {
        $scope.mesajlarKullaniciKutusu1 = response.data;
    });
});


