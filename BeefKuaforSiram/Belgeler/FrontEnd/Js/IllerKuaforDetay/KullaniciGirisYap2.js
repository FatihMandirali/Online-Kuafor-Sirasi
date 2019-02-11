

$(document).on("click", "#btngirisyap", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var kadi = $("#kullaniciadi").val();
    var sifre = $("#sifre").val();

    var emp = {
        "UserName": kadi,
        "Password": sifre
    };

    $.ajax({
        method: "POST",
        url: "/Home/KullaniciLogin/",
        type: "json",
        data: emp
    }).done(function (data) {

        if (data == "Lütfen Bilgilerinizi Kontrol Ediniz..") {
            alert(data);
            window.location.reload();
        } else if (data == "Başarılı Giriş..") {
            window.location.reload();
        }




    });







});