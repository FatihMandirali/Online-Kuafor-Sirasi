﻿$.getJSON("/Belgeler/ilveilce/il-bolge.json", function (sonuc) {
    $.each(sonuc, function (index, value) {
        var row = "";
        row += '<option value="' + value.il + '">' + value.il + '</option>';
        $("#ySehir").append(row);
    })
});


$("#ySehir").on("change", function () {
    var il = $(this).val();
    $("#ySemt").attr("disabled", false).html("<option value=''>Seçin..</option>");
    $.getJSON("/Belgeler/ilveilce/il-ilce-gercek.json", function (sonuc) {
        $.each(sonuc, function (index, value) {
            var row = "";
            if (value.il == il) {
                row += '<option value="' + value.ilce + '">' + value.ilce + '</option>';
                $("#ySemt").append(row);
            }
        });
    });
});