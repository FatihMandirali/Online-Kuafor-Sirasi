$(document).on("click", ".kuaforSahipkayit", function () {
    //Burda kaldım isimleri düzelterek başla
    var ad = $("#yAd").val();
    var sehir = $("#ySehir").val();
    var semt = $("#ySemt").val();
    var soyad = $("#ySoyad").val();
    var email = $("#yEmail").val();
    var telefon = $("#yTelefon").val();
    var kullaniciadi = $("#yKullaniciAdi").val();
    var sifre = $("#ySifre").val();
    var tc = $("#yTC").val();
   // var dogumtarihi = $("#DgmTrh").val();//bunuda değiştir
    // var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Ad": ad,
        "Sehir": sehir,
        "Semt": semt,
        "Soyad": soyad,
        "EMail": email,
        "Telefon": telefon,
        "KullaniciAdi": kullaniciadi,
        "Sifre": sifre,
        "Tc":tc,
      //  "DogumTarihi": "101010"
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/KuaforSahip/Ekle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        window.location.reload();

    });


});