var app = angular.module("MyAppGecmisSira", []);


app.controller("gecmisSira", function ($scope, $http) {
    var kuafor = $("#sessiondeger").val();
    var x = Number(kuafor);
    $http.get("http://localhost:52747/api/SiraAl/GetKuaforAdminGecmisSira/" + x).then(function (response) {
        $scope.gcmsSira = response.data;
    });
});

app.controller("gecmisSiraIncele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/SiraAl/GetKuaforAdminGecmisSiraIncele/" + secondLevelLocation).then(function (response) {
        $scope.gcmsSiraIncele = response.data;
    });
});

$(document).on("click", "#gecmisSiraSil", function () {

    var ID = $(this).attr('name');
    $.ajax({
        method: "POST",
        url: "http://localhost:52747/api/SiraAl/GetKuaforAdminGecmisSiraSil/" + ID,
        type: "json"
    }).done(function (response, statusText, jqXHR) {




        window.location = "http://localhost:52747/KuaforAdmin/GecmisSira";


    });
});