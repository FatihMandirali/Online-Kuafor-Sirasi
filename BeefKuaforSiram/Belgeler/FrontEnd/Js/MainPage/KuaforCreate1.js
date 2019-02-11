$(document).on("click", ".kuaforLoginCreate", function () {
    //Burda kaldım isimleri düzelterek başla
    //  alert("içerde");
    var ad = $("#yAdi").val();
    var adres = $("#yAdres").val();
    var email = $("#yEmaili").val();
    var sehir = $("#ySehir").val();
    var semt = $("#ySemt").val();
    var telefon = $("#yTelefonu").val();
    var baybayan = $("#BayBayan").val();
    var aralik = $("#Aralik").val();
    var acilma = $("#AcilmaSaati").val();
    var kapanma = $("#KapanmaSaati").val();
    //  var puan = $(".Puan").val();
    //  var eklenmetarihi = $(".EklenmeTarihi").val();
    //  var kuaforsahibi = $("#Resim").val();//bunuda değiştir
    var ID = $(".dddd").val();
    //   alert(ID);
    var emp = {
        "Ad": ad,
        "Sehir": sehir,
        "Semt": semt,
        "Adres": adres,
        "EMail": email,
        "Aralik": aralik,
        "Telefon": telefon,
        "BayBayan": baybayan,
        "AcilmaSaati": acilma,
        "KapanmaSaati": kapanma,
        "Puan": 2,
        "KuaforSahipIdi": ID
        //  "EklenmeTarihi": eklenmetarihi,
        //   "KuaforSahipId": kuaforsahibi,
        //   "Resim": "deneme",

    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/Kuaforler/Ekle/",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {

            window.location = "http://localhost:52747/Home/KuaforAdminLogin";

        }
    });







});