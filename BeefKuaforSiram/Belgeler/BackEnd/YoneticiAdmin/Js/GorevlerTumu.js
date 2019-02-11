$(document).on("click", "#gorevGuncelle", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var gorev = $(".GorevAdi").val();
    var tamamlanma = $(".TamamlanmaAdet").val();
    var basari = $(".BasariPuani").val();
    
    var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "gorevAdi": gorev,
        "tamamlanmaAdet": tamamlanma,
        "basariPuani":basari,
        "id": ID
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/Gorevler/PostGorevlerGuncelle/",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location.reload();

        }
    });
});

$(document).on("click", "#gorevsil", function () {




    var ID = $(this).attr('name');
    $.ajax({
        url: 'http://localhost:52747/api/Gorevler/PostGorevlerSil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            //   alert("girdi");
            //  $("#Durum").html(data); durum id li divin içine postta yazdığı yazıyı basıyor.
            //alert(data);
            location.location.reload();
        }
    });



});

$(document).on("click", "#btngorevolustur", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var gorev = $(".GorevAdi").val();
    var tamamlanma = $(".TamamlanmaAdet").val();
    var basari = $(".BasariPuani").val();
    /// var ID = $(".dd").val();
    //   alert(ID);
    var emp = {
        "gorevAdi": gorev,
        "tamamlanmaAdet": tamamlanma,
        "basariPuani": basari,
        "id": 1
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/Gorevler/PostGorevEkle",
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/YoneticiAdmin/Gorevler";

        }
    });







});