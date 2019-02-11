var app = angular.module("MyAppGelecekSira", []);


app.controller("gelecekSira", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/SiraAl/GetKuaforAdminGelecekSira/" + x).then(function (response) {
        $scope.glckSira = response.data;
    });
});


app.controller("gelecekSiraIncele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/SiraAl/GetKuaforAdminGelecekSiraIncele/" + secondLevelLocation).then(function (response) {
        $scope.glckSiraIncele = response.data;
    });
});

$(document).on("click", "#gelecekSiraTamamla", function () {

    var ID = $(this).attr('name');
    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/SiraAl/GetKuaforAdminGelecekSiraTamamla/" + ID,
        type: "json"
    }).done(function (response, statusText, jqXHR) {



        alert(response);
        window.location = "http://localhost:52747/KuaforAdmin/GelecekSira";


    });
});


app.controller("hizliSiraAlmaEleman", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/SiraAl/GetHizliSiraEleman/" + x).then(function (response) {
        $scope.hzlSiraEleman = response.data;
    });
});

app.controller("hizliSiraAlmaSure", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/SiraAl/GetHizliSiraSaat/" + x).then(function (response) {
        $scope.hzlSiraSure = response.data;
    });
});

$(document).on("click", "#btnHizliSira", function () {

    var rdeleman = $("#rdKHizliSiraElemanlar input[type='radio']:checked").val();
    var tarih = $("#kuaforTarihAralik").val();
    var chctrascesitleri = [];
    $('#chcHizliSiraSaatler :checked').each(function () {
        //Secilenler.push($(this).val());
       
        chctrascesitleri.push($(this).val());

    });
   
   
    var ID = $("#sessiondeger").val();

    var emp = {
        "id": ID,
        "tarih": tarih,
        "eleman": rdeleman,
        "saatAraligi": chctrascesitleri
    };//KuaforHizliSiraRequest Adında Model yOLLA


    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/SiraAl/HizliSiraniAl",
        type: "json",
        data: emp,
    }).done(function (response, statusText, jqXHR) {




        window.location = "http://localhost:52747/KuaforAdmin/GelecekSira";


    });
}); 