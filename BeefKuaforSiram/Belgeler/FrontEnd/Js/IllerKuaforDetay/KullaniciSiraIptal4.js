$(document).on("click", "#siraİptal", function () {
    var id = $(this).attr('name');
    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/SiraAl/KullaniciSiraSil/" + id,
        type: "json",
        data: id
    }).done(function (response, statusText, jqXHR) {

        alert(response);

        window.location.reload();

    });


});//DeleteSira


$(document).on("click", "#kuaforSiraYorum", function () {


    var kuaforadi = $(this).attr('name');
    var output = "<input type='text' id='kullaniciYorumKuaforId' value='" + kuaforadi + "' />";
    $('#kuaforAdiGelecek').append(output);
    //$.ajax({
    //    method: "GET",
    //    url: "http://localhost:52747/api/KuaforDetayYorumlar/GetKullaniciYorumKuaforId/" + kuaforadi,
    //    type: "json",
    //}).done(function (response, statusText, jqXHR) {

    //    //alert(response);


    //});
});

$(document).on("click", "#kuaforYorumYap", function () {

    var yorumYap = $("#txtYorumYap").val();
    var hizPuan = $("#txtHizPuan").val();
    var ozenPuan = $("#txtOzenPuan").val();
    var kalitePuan = $("#txtKalitePuan").val();
    var kuaforAdi = $("#kullaniciYorumKuaforId").val();
    var pathArray = window.location.pathname.split('/');
    var kullaniciSlug = pathArray[3];


    if (yorumYap != "" && hizPuan != "" && ozenPuan != "" && kalitePuan != "") {
        if (hizPuan < 0 || hizPuan > 5 && ozenPuan < 0 || ozenPuan > 5 && kalitePuan < 0 || kalitePuan > 5) {
            alert("Lütfen 5 tek büyük ve negatif puanlar girmeyin");
        } else {
            var veri = {
                "yorum": yorumYap,
                "hizPuan": hizPuan,
                "ozenPuan": ozenPuan,
                "kalitePuan": kalitePuan,
                "kuaforAdi": kuaforAdi,
                "kullaniciSlug": kullaniciSlug
            }

            $.ajax({
                method: "POST",
                url: "http://localhost:52747/api/KuaforDetayYorumlar/GetKullaniciYorum/",
                type: "json",
                data: veri
            }).done(function (response, statusText, jqXHR) {

                alert(response);

                window.location.reload();

            });
        }

    } else {
        alert("Lütfen Formda Boş Yer Bırakmayın.");
    }

});