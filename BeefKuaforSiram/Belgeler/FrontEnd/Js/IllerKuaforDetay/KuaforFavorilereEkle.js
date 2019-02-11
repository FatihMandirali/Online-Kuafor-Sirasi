$(document).on("click", ".favorilereEkle", function () {

    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    var kullaniId = $("#kullaniciSession").val();
    if (kullaniId == null) {

        alert("Lütfen Giriş Yaptıktan Sonra Favorilere Ekleyin");
        window.location.reload();
    } else {
    var emp = {
        "kullaniciId": kullaniId,
        "kuaforSlug": secondLevelLocation
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/KullaniciProfilFavoriler/KullaniciFavoriEkle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {

        if (response == "Bu Kuafor Zaten Beğenildi") {
            alert(response);
        }

        window.location.reload();

    });
    }


});