$(document).on("click", "#btnkuaforsahipguncelle", function () {
    //Burda kaldım isimleri düzelterek başla
    //0 alert("içerde");
    var ad = $(".Ad").val();
    var soyad = $(".Soyad").val();
    var email = $(".EMail").val();
    var kullaniciadi = $(".KullaniciAdi").val();
    var sifre = $(".Sifre").val();
    var sehir = $("#Sehir").val();
    var semt = $("#Semt").val();
    var telefon = $(".Telefon").val();
    var tc = $(".Tc").val();
    var dogumtarihi = $(".DogumTarihi").val();
    var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Ad": ad,
        "Soyad": soyad,
        "EMail": email,
        "KullaniciAdi": kullaniciadi,
        "Sifre": sifre,
        "Sehir": sehir,
        "Semt": semt,
        "Telefon": telefon,
        "Tc": tc,
        "DogumTarihi": dogumtarihi,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforSahip/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            alert("girdi");
            window.location = "http://localhost:52747/YoneticiAdmin/KuaforSahip";

        }
    });







});



$(document).on("click", "#kuaforsahipsil", function () {



    var ID = $(this).attr('name');
    $.ajax({
        url: '/YoneticiAdmin/KuaforSahipSil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            //   alert("girdi");
            //  $("#Durum").html(data); durum id li divin içine postta yazdığı yazıyı basıyor.
            //alert(data);
            location.reload();
        }
    });
    location.reload();


});


