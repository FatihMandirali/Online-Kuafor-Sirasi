$(document).on("click", "#kuaforsec", function () {
    //Burda kaldım isimleri düzelterek başla
    // alert("içerde");
   
    var ID = $(this).attr('name');
   
  

    $.ajax({
        method: "POST",
        url: "/KuaforAdmin/KuaforSecimSession/" + ID,
        type: "json"
    }).done(function (data) {
        
            window.location = "http://localhost:52747/KuaforAdmin/KuaforElemanlari";
        
    });







});