var app = angular.module("MyAppSaat", []);


app.controller("saatler", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/KuaforSaatleri/Ozellestirilmis/" + x).then(function (response) {
        $scope.saat = response.data;
    });
});


$(document).on("click", "#calismasaatiguncelle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var acilis = $(".Acilis").val();
    var kapanis = $(".Kapanis").val();
    var kapanis = $(".Kapanis").val();
    var aralik = $(".Aralik").val();
    var ID = $(".dd").val();
    var ii = 1;
    //   alert(ID);
    var emp = {
        "AcilmaSaati": acilis,
        "KapanmaSaati": kapanis,
        "KuaforId": ii,
        "Aralik": aralik,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforSaatleri/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        //  if (jqXHR.status == 200) {
        //   alert("girdi");
        window.location = "http://localhost:52747/KuaforAdmin/CalismaSaatleri";

        // }
    });







});


