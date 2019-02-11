

$(document).on("click", "#Ykuaforlogin", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var kadi = $("#Ykuaforkullaniciadi").val();
    var sifre = $("#Ykuaforsifre").val();

    var emp = {
        "UserName": kadi,
        "Password": sifre
    };

    $.ajax({
        method: "POST",
        url: "/Home/KuaforCreateAdminLogin",
        type: "json",
        data: emp
    }).done(function (data) {

        if (data == "Lütfen Bilgilerinizi Kontrol Ediniz..") {
            alert(data);
            window.location.reload();
        } else{
            var mySessionVar = data;
            var a = mySessionVar.substring(16, mySessionVar.length);
            $('.dddd').val(a);
            $('.kuaforLoginKayitt').modal('show');
        }
    });







});