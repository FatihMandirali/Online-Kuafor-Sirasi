var app = angular.module("MyApp12", []);




app.controller("trascesitleriincele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforTrasCesitleri/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.trascesit = response.data;
    });
});




$(document).on("click", "#trascesitguncelle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var cesit = $(".Cesit").val();
    var fiyat = $(".Fiyat").val();
    var dk = $(".Dk").val();
    // var kuafor = $(".Kuafor").val();
    var resim = $("#Resim").val();
    var ID = $(".dd").val();
    var ii = 1;
    //   alert(ID);
    var emp = {
        "Cesit": cesit,
        "Fiyat": fiyat,
        "Dk": dk,
        "KuaforId": ii,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforTrasCesitleri/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        //  if (jqXHR.status == 200) {
        //   alert("girdi");
        window.location = "http://localhost:52747/KuaforAdmin/TrasCesitleri";

        // }
    });







});

