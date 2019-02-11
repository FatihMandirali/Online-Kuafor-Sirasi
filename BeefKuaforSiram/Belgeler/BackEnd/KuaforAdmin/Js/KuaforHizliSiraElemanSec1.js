$(document).on("click", "#kuaforSiraElemanSecimi", function () {
    var rdeleman = $(this).attr('name');       //Date in full format alert(new Date(this.value));
    var tarih = $("#kuaforTarihAralik").val();


    var emp = {
        "personelId": rdeleman,
        "tarih": tarih
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/SiraAl/SiraAralikLis/",
        type: "json",
        data: emp,
        success: function (data, textStatus, xhr) {
            if (data == "Lütfen Eleman Seçtikten Sonra İşleminize Devam Edin") {
                alert(data);
            } else {
                $('#siraAlAralik').html("");
                var output = "";
                for (var i = 0; i < data.length; i++) {
                    if (data[i].Durum == true) {
                        output = " <div class='col-md-6 searchable-container'> \
                    <div class='items' > \
                        <div class='info-block block-info clearfix'>\
                            <div class='square-box pull-left'>\
                                <span class='glyphicon glyphicon-tags glyphicon-lg'></span>\
                            </div>\
                            <div data-toggle='buttons' id='rdKuaforSaati' class='btn-group bizmoduleselect'>\
                                <label class='btn btn-default' id='chcHizliSiraSaatler' >\
 <input type='checkbox' style='background-color:red' name='kuafortrasaralik' value='"+ data[i].id + "'  autocomplete='off' /><br /> <span class='glyphicon glyphicon-ok glyphicon-lg'></span><b>Başlama Saati : </b>" + data[i].baslamaSaati + "<br /><b>Bitiş Saati : </b>" + data[i].bitisSaati + " \
                </label>\
                            </div>\
                        </div>\
                                    </div >\
                                </div >";
                    } else {
                        output = " <div class='col-md-6 searchable-container'> \
                    <div class='items' > \
                        <div class='info-block block-info clearfix'>\
                            <div class='square-box pull-left'>\
                                <span class='glyphicon glyphicon-tags glyphicon-lg'></span>\
                            </div>\
                            <div data-toggle='buttons' id='rdKuaforSaati' class='btn-group bizmoduleselect'>\
                                <label class='btn btn-default' id='chcHizliSiraSaatler'style='background-color:red' >\
 <input type='checkbox' disabled  name='kuafortrasaralik' value='"+ data[i].id + "'  autocomplete='off' /><br /> <span class='glyphicon glyphicon-ok glyphicon-lg'></span><b>Başlama Saati : </b>" + data[i].baslamaSaati + "<br /><b>Bitiş Saati : </b>" + data[i].bitisSaati + " \
                </label>\
                            </div>\
                        </div>\
                                    </div >\
                                </div >";
                    }
                    $('#siraAlAralik').append(output);
                }
            }



        }
    });
});