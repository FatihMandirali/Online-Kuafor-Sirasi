

$(document).on("click", "#anketguncelle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var soru = $(".Soru").val();
    var cvpa = $(".CevapA").val();
    var cvpb = $(".CevapB").val();
    var cvpc = $(".CevapC").val();
    var cvpd = $(".CevapD").val();
    var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Soru": soru,
        "CevapA": cvpa,
        "CevapB": cvpb,
        "CevapC": cvpc,
        "CevapD": cvpd,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/Anketler/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/YoneticiAdmin/Anketler";

        }
    });







});



$(document).on("click", "#anketsil", function () {




    var ID = $(this).attr('name');
    $.ajax({
        url: '/YoneticiAdmin/AnketSil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            //   alert("girdi");
            //  $("#Durum").html(data); durum id li divin içine postta yazdığı yazıyı basıyor.
            //alert(data);
            location.reload();
        }
    });



});


$(document).on("click", "#anketekle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var soru = $("#Soru").val();
    var cvpa = $("#CevapA").val();
    var cvpb = $("#CevapB").val();
    var cvpc = $("#CevapC").val();
    var cvpd = $("#CevapD").val();
    /// var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "Soru": soru,
        "CevapA": cvpa,
        "CevapB": cvpb,
        "CevapC": cvpc,
        "CevapD": cvpd
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/Anketler/Ekle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/YoneticiAdmin/Anketler";

        }
    });







});