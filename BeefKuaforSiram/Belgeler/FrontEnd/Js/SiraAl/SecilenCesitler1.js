$("#btnSecilenGor").click(function () {
    var chctrascesitleri = "";
    var rdeleman = "";
    var rdsaat = "";
    var tarih = $("#kuaforTarihAralik").val();
    $('#chcTrasCesileri :checked').each(function () {
        //Secilenler.push($(this).val());
        chctrascesitleri += $(this).val() + ",";

    });
    rdeleman = $("#rdKuaforElemanSec input[type='radio']:checked").val();
    rdsaat = $("#rdKuaforSaati input[type='radio']:checked").val();
    var kullaniId = $("#kullaniciSession").val();
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    var emp = {
        "kuaforSlug": secondLevelLocation,
        "trasCesitleri": chctrascesitleri,
        "elemanId": rdeleman,
        "saatId": rdsaat,
        "kullaniciId": kullaniId,
        "tarih": tarih
    };


    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/SiraAl/SiraniAl/" + secondLevelLocation,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {


        alert(response);
        window.location.reload();

    });
});