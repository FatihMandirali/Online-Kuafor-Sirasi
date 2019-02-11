$(document).on("click", "#firsatsil", function () {




    var ID = $(this).attr('name');
    $.ajax({
        url: 'http://localhost:52747/api/KuaforFirsatlar/Sil/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
        type: 'DELETE',
        dataType: 'json',
        success: function (data) {
            //   alert("girdi");
            //  $("#Durum").html(data); durum id li divin içine postta yazdığı yazıyı basıyor.
            //alert(data);
            location.reload();
        }
    });



});

$(document).on("click", "#firsataktiflestir", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var icerik = $(".FirsatIcerik").val();
    var yayin = $(".FirsatYayinTarih").val();
    var kua = $(".Kuaforadi").val();
    // var kuafor = $(".Kuafor").val();

    var ID = $(".dd").val();
    var ii = 1;
    //   alert(ID);
    var emp = {
        "FirsatIcerik": icerik,
        "FirsatYayinTarih": yayin,
        "YoneticiOnayi": 2,
        "KuaforId": ii,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforFirsatlar/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        //  if (jqXHR.status == 200) {
        //   alert("girdi");
        window.location = "http://localhost:52747/YoneticiAdmin/FirsatOnay";

        // }
    });







});


$(document).on("click", "#firsataktifligikaldir", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var icerik = $(".FirsatIcerik").val();
    var yayin = $(".FirsatYayinTarih").val();
    var kua = $(".Kuaforadi").val();
    // var kuafor = $(".Kuafor").val();

    var ID = $(".dd").val();
    var ii = 1;
    //   alert(ID);
    var emp = {
        "FirsatIcerik": icerik,
        "FirsatYayinTarih": yayin,
        "YoneticiOnayi": 0,
        "KuaforId": ii,
        "Id": ID
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforFirsatlar/Guncelle/" + ID,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        //  if (jqXHR.status == 200) {
        //   alert("girdi");
        window.location = "http://localhost:52747/YoneticiAdmin/FirsatOnay";

        // }
    });







});
