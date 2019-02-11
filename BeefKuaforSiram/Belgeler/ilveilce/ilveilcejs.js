
$.getJSON("/Belgeler/ilveilce/il-bolge.json", function (sonuc) {
  
    $.each(sonuc, function (Iller, value) {
        var row = "";
        row += '<option value="' + value.il + '">' + value.il + '</option>';
        $("#il").append(row);
    })
});


//$("#il").on("change", function () {
    var il = $("#gelenad").val();
  //  alert(il);
    //$("#ilce").attr("disabled", false).html("<option value=''>Seçin..</option>");
    $.getJSON("/Belgeler/ilveilce/il-ilce.json", function (sonuc) {
        $.each(sonuc, function (Iller, value) {
            var row = "";
            if (value.il == il) {
                row += '<option value="' + value.ilce + '">' + value.ilce + '</option>';
                $("#ilce").append(row);
           }
        });
    });
//});