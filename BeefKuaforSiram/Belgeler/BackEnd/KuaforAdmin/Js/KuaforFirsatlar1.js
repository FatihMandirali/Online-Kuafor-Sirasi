var app = angular.module("MyAppFirsat", []);


app.controller("firsatlar", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/KuaforFirsatlar/TumuOzel/" + x).then(function (response) {
        $scope.firsat = response.data;
    });
});

$(document).on("click", "#firsatekle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var icerik = $("#FirsatIcerik").val();
    var tarih = $("#FirsatYayinTarih").val();
    var kuafor = $("#sessiondeger").val();
    //   alert(ID);
    var emp = {
        "FirsatIcerik": icerik,
        "FirsatYayinTarih": tarih,
        "YoneticiOnayi": 3,
        "KuaforId": kuafor,
        "Id": kuafor
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/KuaforFirsatlar/Ekle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/KuaforAdmin/Firsatlar";

        }
    });
});

app.controller("firsatincele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforFirsatlar/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.firsati = response.data;
    });
});

$(document).on("click", "#firsatsil", function () {




    var ID = $(this).attr('name');
    $.ajax({
        url: 'http://localhost:52747/api/KuaforFirsatlar/Sil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
        type: 'DELETE',
        dataType: 'json',
        success: function (data) {
            //   alert("girdi");
            //  $("#Durum").html(data); durum id li divin içine postta yazdığı yazıyı basıyor.
            //alert(data);
            location.reload();
        }
    });



});