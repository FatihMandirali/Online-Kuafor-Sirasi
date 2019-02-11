document.getElementById("Gerekce").disabled = true;
document.getElementById("subeac").disabled = true;
document.getElementById("subekapat").disabled = true;
$(document).on("click", ".onoffswitch2", function () {
    //Burda kaldım isimleri düzelterek başla
    var checkBox = document.getElementById("myonoffswitch2");
    // Get the output text

    //$("#Gerekce").attr("disabled", false);
    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {

        document.getElementById("Gerekce").disabled = true;
        document.getElementById("subeac").disabled = true;
    } else {

        document.getElementById("Gerekce").disabled = false;
        document.getElementById("subeac").disabled = false;
    }

});

$(document).on("click", ".onoffswitch1", function () {
    //Burda kaldım isimleri düzelterek başla
    var checkBox = document.getElementById("myonoffswitch1");
    // Get the output text

    //$("#Gerekce").attr("disabled", false);
    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {

        document.getElementById("Gerekce").disabled = true;
        document.getElementById("subekapat").disabled = true;
    } else {

        document.getElementById("Gerekce").disabled = false;
        document.getElementById("subekapat").disabled = false;
    }

});


$(document).on("click", "#subekapat", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var gerekce = $("#Gerekce").val();
    var kuafor = $("#sessiondeger").val();
    //   alert(ID);
    var emp = {
        "Aktiflik": false,
        "Sebep": gerekce,
        "KuaforId": kuafor,
        "Id": kuafor
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforAktiflik/Guncelle/" + kuafor,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/KuaforAdmin/Aktiflik";

        }
    });
});

$(document).on("click", "#subeac", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
    var gerekce = $("#Gerekce").val();
    var kuafor = $("#sessiondeger").val();
    //   alert(ID);
    var emp = {
        "Aktiflik": true,
        "Sebep": gerekce,
        "KuaforId": kuafor,
        "Id": kuafor
    };

    $.ajax({
        method: "PUT",
        url: "http://localhost:52747/api/KuaforAktiflik/Guncelle/" + kuafor,
        type: "json",
        data: emp
    }).done(function (response, statusText, jqXHR) {



        if (jqXHR.status == 200) {
            //  alert("girdi");
            window.location = "http://localhost:52747/KuaforAdmin/Aktiflik";

        }
    });
});