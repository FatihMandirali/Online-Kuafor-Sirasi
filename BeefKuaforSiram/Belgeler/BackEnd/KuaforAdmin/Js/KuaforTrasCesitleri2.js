var app = angular.module("MyApp1", []);


app.controller("trascesitleri", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/KuaforTrasCesitleri/Tumu/" + x).then(function (response) {
        $scope.tras = response.data;
    });
});


$(document).on("click", "#trascesitsil", function () {




    var ID = $(this).attr('name');
    $.ajax({
        url: 'http://localhost:52747/api/KuaforTrasCesitleri/Sil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
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





$(document).on("click", "#kuaforcesitekle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var cesit = $("#Cesit").val();
    var fiyat = $("#Fiyat").val();
    var dk = $("#Dk").val();
    var kuafor = $("#sessiondeger").val();
    /// var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Cesit": cesit,
        "Fiyat": fiyat,
        "Dk": dk,
        "Kuafor": kuafor,
        "Id": kuafor
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/KuaforTrasCesitleri/Ekle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/KuaforAdmin/TrasCesitleri";

        }
    });
});


