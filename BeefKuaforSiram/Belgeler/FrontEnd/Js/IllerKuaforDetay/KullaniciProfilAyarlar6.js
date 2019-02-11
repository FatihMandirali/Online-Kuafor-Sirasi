$(document).on("click", ".kullaniciguncelle", function () {
    var ad = $("#Ad").val();
    var sehir = $("#Sehir").val();
    var semt = $("#Semt").val();
    var soyad = $("#Soyad").val();
    var email = $("#Email").val();
    var telefon = $("#Telefon").val();
    var kullaniciadi = $("#KullaniciAdi").val();
    var sifre = $("#Sifre").val();
    var dogumtarihi = $("#DogumTarihi").val();//bunuda değiştir

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

    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KullaniciProfilFavoriler/KullaniciGuncelle/" + secondLevelLocation,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {

        $.ajax({
            method: "POST",
            url: "/Home/CikisYap",
            type: "json"
        }).done(function (data) {


            alert(data);
            window.location = "/Home/Index";

        });

        window.location.reload();

    });

});

$(document).on("click", "#avatarImg", function () {
    var ID = $(this).attr('name');
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];

    var emp = {
        "Avatar": ID,
        "Slug": secondLevelLocation,
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KullaniciProfilFavoriler/AvatarGuncelle/" + secondLevelLocation,
        type: "json",
        data: emp
    }).done(function (data) {

        window.location.reload();

    });
});

$(document).on("click", "#btnlogincikisyap", function () {
    $.ajax({
        method: "POST",
        url: "/Home/CikisYapNormal",
        type: "json"
    }).done(function (data) {


        alert(data);
        window.location = "/Home/Index";

    });

});