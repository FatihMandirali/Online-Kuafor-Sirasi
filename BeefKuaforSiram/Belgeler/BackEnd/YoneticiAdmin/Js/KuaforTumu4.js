$(document).on("click", "#btnyorumyap", function () {
    //Burda kaldım isimleri düzelterek başla
    //  alert("içerde");
    var ad = $(".Ad").val();
    var sehir = $("#Sehir").val();
    var semt = $("#Semt").val();
    var adres = $(".Adres").val();
    var email = $(".EMail").val();
    var telefon = $(".Telefon").val();
    var baybayan = $(".BayBayan").val();
    var aralik = $(".Aralik").val();
    var acilma = $(".AcilmaSaati").val();
    var kapanma = $(".KapanmaSaati").val();
    var puan = $(".Puan").val();
    var eklenmetarihi = $(".EklenmeTarihi").val();
    var kuaforsahibi = $("#Resim").val();//bunuda değiştir
    var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Ad": ad,
        "Sehir": sehir,
        "Semt": semt,
        "Adres": adres,
        "EMail": email,
        "Aralik": aralik,
        "Telefon": telefon,
        "BayBayan": baybayan,
        "AcilmaSaati": acilma,
        "KapanmaSaati": kapanma,
        "Puan": puan,
        "EklenmeTarihi": eklenmetarihi,
        "KuaforSahipId": kuaforsahibi,
        "Resim": "deneme",
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/Kuaforler/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {

            window.location = "http://localhost:52747/YoneticiAdmin/Kuaforler";

        }
    });







});


$(document).on("click", "#kuaforsil", function () {




    var ID = $(this).attr('name');
    $.ajax({
        url: '/YoneticiAdmin/KuaforSil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            //   alert("girdi");
            //  $("#Durum").html(data); durum id li divin içine postta yazdığı yazıyı basıyor.
            //alert(data);
            location.reload();
        }
    });



});



