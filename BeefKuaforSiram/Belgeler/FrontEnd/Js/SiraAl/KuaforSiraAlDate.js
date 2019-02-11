function getDefaultDate() {

    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    return today;
}

function getMinDate() {

    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    return today;
}
function getMaxDate() {

    var now = new Date();
    var day = ("0" + (now.getDate()+2)).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    
    return today;
}

$(document).ready(function () {
    $("#kuaforTarihAralik").val(getDefaultDate());
    document.getElementById("kuaforTarihAralik").setAttribute("min", getMinDate()); 
    document.getElementById("kuaforTarihAralik").setAttribute("max", getMaxDate());
});