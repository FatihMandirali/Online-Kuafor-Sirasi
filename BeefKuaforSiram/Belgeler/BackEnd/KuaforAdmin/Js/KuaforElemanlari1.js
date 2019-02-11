var app = angular.module("MyAppEleman", []);


app.controller("kuaforelemanlar", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/KuaforElemanlari/Tumu/" + x).then(function (response) {
        $scope.eleman = response.data;
    });
});

$(document).on("click", "#kuaforelemanekle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var ad = $("#Adi").val();
    var soyad = $("#Soyadi").val();
    var tc = $("#Tc").val();
    var tel = $("#Telefon").val();
    var mail = $("#Mail").val();
    var kuafor = $("#sessiondeger").val();
    /// var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Adi": ad,
        "Soyadi": soyad,
        "Tc": tc,
        "Telefon": tel,
        "Mail": mail,
        "Id": kuafor
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/KuaforElemanlari/Ekle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/KuaforAdmin/KuaforElemanlari";

        }
    });
});


$(document).on("click", "#kuaforelemansil", function () {




    var ID = $(this).attr('name');
    $.ajax({
        url: 'http://localhost:52747/api/KuaforElemanlari/Sil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
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

app.controller("kuaforelemanincele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforElemanlari/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.elemanin = response.data;
    });
});

$(document).on("click", "#elemanguncelle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var ad = $(".Adi").val();
    var soyad = $(".Soyadi").val();
    var tc = $(".Tc").val();
    // var kuafor = $(".Kuafor").val();
    var telefon = $(".Telefon").val();
    var mail = $(".Mail").val();
    var ID = $(".dd").val();
    var ii = 1;
    //   alert(ID);
    var emp = {
        "Adi": ad,
        "Soyadi": soyad,
        "Tc": tc,
        "Telefon": telefon,
        "Mail": mail,
        "KuaforId": ii,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforElemanlari/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        //  if (jqXHR.status == 200) {
        //   alert("girdi");
        window.location = "http://localhost:52747/KuaforAdmin/KuaforElemanlari";

        // }
    });







});