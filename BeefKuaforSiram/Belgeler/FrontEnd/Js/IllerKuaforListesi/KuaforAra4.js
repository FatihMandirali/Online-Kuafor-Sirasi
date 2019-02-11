$(document).on("click", "#btnara", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var ilce = $("#ilce").val();

    // alert(ilce);

    var cins = $("#cinsiyet").val();
    var ilcecins = ilce + cins;
    $.ajax({
        method: "GET",
        url: "http://localhost:52747/api/Kuaforler/OzellestirilmisIlce/" + ilcecins,
        type: "json",
        success: function (data, textStatus, xhr) {

            $('.hvrbox1').html("");

            var output = "";
            for (var i = 0; i < data.length; i++) {
                output = "<div class='kuaforler mt-2 hvrbox' id='kuaforttt' ng-repeat='x in kuaforler' ng-if='x.Sehir!=@TempData['sehirad']'><a class='float-left puan'>" + data[i].Puan + "</a><b style='margin-left:20px;'><a href='/Home/Iller' id='kuaforadiA'>" + data[i].Ad + "</a></b><br /><i style='margin-left:20px;'>" + data[i].Adres + "</i><div class='hvrbox-layer_top'><div class='hvrbox-text'><a href='/Home/KuaforSiraAl/" + data[i].Slug + "' style='text-decoration:none; color:#1886c7'>Sıra Al</a><br /><a href='/Home/KuaforDetay/" + data[i].Slug + "' style='text-decoration:none; color:white'>Detay</a></div></div></div>";
                $('.hvrbox1').append(output);
            }


        }
    });


});
