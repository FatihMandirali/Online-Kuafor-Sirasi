
$(document).ready(function () {

    $(document).on("click", "#gsss", function () {
        var tabledata = $(this).children("td").map(function () {
            return $(this).text();
        }).get();
        var tdd = tabledata[0] + ' ' + tabledata[1];
        var deger = $(this).attr('name');
        var kuafor = $("#sessiondeger").val();
        // alert(tdd + "/ " + deger);
        //   alert("deneme");
        $('#kullaniciIdsi').val(deger);
        var emp = {
            "kuaforId": kuafor,
            "kullaniciId": deger
        };

        $.ajax({
            method: "POST",
            url: "http://localhost:52747/api/KuaforMesaj/Mesajlar/",
            type: "json",
            data: emp
        }).done(function (response, statusText, jqXHR) {
            $('.msg_container_base').html('');
            for (var i = 0; i < response.length; i++) {
                if (response[i].Yonetici == true) {
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
    var kuaforId = $("#sessiondeger").val();
    var msj = $("#btn-input").val();
    var kullaniciId = $('#kullaniciIdsi').val();


    var emp = {
        "kuaforId": kuaforId,
        "mesaj": msj,
        "kullaniciId": kullaniciId
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/KuaforMesaj/PostYoneticiMessage/",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {
        //Eklendikten sonra buraya ekliyoruz.


    });



});

//<div class='row msg_container base_sent'><div class='col-md-10 col-xs-10'><div class='messages msg_sent'><p>GS</p><time datetime='2009-11-13T20:00'>Timothy • 51 min</time></div></div></div>

//<div class='row msg_container base_receive'><div class='col-md-10 col-xs-10'><div class='messages msg_receive'><p>Şampiyon</p><time datetime='2009-11-13T20:00'>Timothy • 51 min</time></div></div></div>