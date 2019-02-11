
$(document).ready(function () {

    $(document).on("click", "#kuaforAdSatir", function () {
        var tabledata = $(this).children("td").map(function () {
            return $(this).text();
        }).get();
        var tdd = tabledata[0] + ' ' + tabledata[1];
        var deger = $(this).attr('name');
        var pathArray = window.location.pathname.split('/');
        var secondLevelLocation = pathArray[3];
        // alert(tdd + "/ " + deger);
        //   alert("deneme");
        $('#kullaniciIdsi').val(deger);
        var emp = {
            "kuaforId": deger,
            "kullaniciSlug": secondLevelLocation
        };

        $.ajax({
            method: "POST",
            url: "http://localhost:52747/api/KuaforMesaj/KullaniciMesajlar/",
            type: "json",
            data: emp
        }).done(function (response, statusText, jqXHR) {
            $('.msg_container_base').html('');
            for (var i = 0; i < response.length; i++) {
                if (response[i].Yonetici == false) {
                    var mesajList = "";
                    mesajList = "<div class='row msg_container base_sent'><div class='col-md-10 col-xs-10'><div class='messages msg_sent'><p>" + response[i].Mesaj + "</p></div></div></div> ";

                } else {
                    mesajList = "<div class='row msg_container base_receive'><div class='col-md-10 col-xs-10'><div class='messages msg_receive'><p>" + response[i].Mesaj + "</p></div></div></div>";
                }
                $('.msg_container_base').append(mesajList);
            }



        });
    });

});

$(document).on("click", "#btn-chat", function () {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    var msj = $("#btn-input").val();
    var kuafoId = $('#kuaforIdsi').val();


    var emp = {
        "kuaforId": kuaforId,
        "mesaj": msj,
        "kullaniciSlug": secondLevelLocation
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/KuaforMesaj/PostKullaniciMessage/",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {
        //Eklendikten sonra buraya ekliyoruz.


    });



});