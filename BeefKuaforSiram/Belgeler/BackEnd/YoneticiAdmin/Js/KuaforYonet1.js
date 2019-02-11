
$(document).on("click", "#kuaforYonet", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var kadi = $(this).attr('name');

    var emp = {
        "id": kadi
    };

    $.ajax({
        method: "POST",
        url: "/YoneticiAdmin/YoneticiAdminLogin",
        type: "json",
        data: emp
    }).done(function (data) {

        if (data == "Lütfen Bilgilerinizi Kontrol Ediniz..") {
            alert(data);
            window.location.reload()
        } else if (data == "Başarılı Giriş..") {
            window.location = "http://localhost:52747/KuaforAdmin/Yorumlar";
        }
    });







});