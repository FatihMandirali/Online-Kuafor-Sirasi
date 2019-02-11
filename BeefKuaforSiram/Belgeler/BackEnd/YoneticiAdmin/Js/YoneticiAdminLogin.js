

$(document).on("click", "#yoneticilogin", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var kadi = $("#yoneticikullaniciadi").val();
    var sifre = $("#yoneticisifre").val();

    var emp = {
        "UserName": kadi,
        "Password": sifre
    };

    $.ajax({
        method: "POST",
        url: "/Home/YoneticiAdminLogin",
        type: "json",
        data: emp
    }).done(function (data) {

        if (data == "Lütfen Bilgilerinizi Kontrol Ediniz..") {
            alert(data);
            window.location.reload()
        } else if (data == "Başarılı Giriş..") {
            window.location = "http://localhost:52747/YoneticiAdmin/Kuaforler";
        }
    });







});