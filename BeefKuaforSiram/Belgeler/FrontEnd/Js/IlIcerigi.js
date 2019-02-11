$(document).on("click", "#sehirsecbtn", function () {

    if (confirm("Şehir seçimine dönmek istediğinize emin misiniz?")) {

      

        $.ajax({
            url: '/Home/SehirSec/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                window.location = "/Home/Index";
              
               
            }
        });
    }
});