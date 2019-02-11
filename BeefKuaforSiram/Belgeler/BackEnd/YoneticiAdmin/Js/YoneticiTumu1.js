$(document).on("click", "#btnyoneticiguncelle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var ad = $(".Ad").val();
    var soyad = $(".Soyad").val();
    var kullaniciadi = $(".KullaniciAdi").val();
    var sifre = $(".Sifre").val();
    var sehir = $("#Sehir").val();
    var semt = $("#Semt").val();
    var email = $(".EMail").val();
    var telefon = $(".Telefon").val();
    var dogumtarihi = $(".DogumTarihi").val();
    var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Ad": ad,
        "Soyad": soyad,
        "KullaniciAdi": kullaniciadi,
        "Sifre": sifre,
        "Sehir": sehir,
        "Semt": semt,
        "EMail": email,
        "Telefon": telefon,
        "DogumTarihi": dogumtarihi,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/Yonetici/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/YoneticiAdmin/Yoneticiler";

        }
    });







});



$(document).on("click", "#yoneticisil", function () {



    var ID = $(this).attr('name');
    $.ajax({
        url: 'http://localhost:52747/api/Yonetici/Sil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
        type: 'DELETE',
        dataType: 'json',
        success: function (data) {

            window.location = "http://localhost:52747/YoneticiAdmin/Yoneticiler"; //sayfa yenilemede sıkıntı var
        }
    });



});








$(document).on("click", "#btnyoneticiolustur", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
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
    //    var ID = $(".dd").val();
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
        "DogumTarihi": dogumtarihi
        //   "Id": ID
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/Yonetici/Ekle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/YoneticiAdmin/Yoneticiler";

        }
    });







});