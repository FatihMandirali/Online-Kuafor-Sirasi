$(document).on("click", ".kullanicikayit", function () {
    //Burda kaldım isimleri düzelterek başla
    var ad = $("#Ad").val();
    var sehir = $("#Sehir").val();
    var semt = $("#Semt").val();
    var soyad = $("#Soyad").val();
    var email = $("#Email").val();
    var telefon = $("#Telefon").val();
    var kullaniciadi = $("#KullaniciAdi").val();
    var sifre = $("#Sifre").val();
    var dogumtarihi = $("#DogumTarihii").val();//bunuda değiştir
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
        "DogumTarihi": dogumtarihi
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/Kullanici/Ekle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        window.location.reload();

    });


});