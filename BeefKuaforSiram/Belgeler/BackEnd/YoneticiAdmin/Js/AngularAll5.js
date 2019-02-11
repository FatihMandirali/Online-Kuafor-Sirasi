var app = angular.module("MyApp", []);


app.controller("kuaforsahibi", function ($scope, $http) {

    $http.get("http://localhost:52747/api/KuaforSahip/Tumu").then(function (response) {
        $scope.kuaforsah = response.data;
    });
});

app.controller("kuaforsahibidetay", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforSahip/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.kuaforsa = response.data;
    });
});

app.controller("kuaforler", function ($scope, $http) {

    $http.get("http://localhost:52747/api/Kuaforler/YoneticiKuaforler").then(function (response) {
        $scope.kuafor = response.data;
    });
});


app.controller("kuaforguncelle", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/Kuaforler/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.kuaforgun = response.data;
    });
});

app.controller("anketler", function ($scope, $http) {
    $http.get("http://localhost:52747/api/Anketler/Tumu").then(function (response) {
        $scope.anket = response.data;
    });
});

app.controller("anketguncelle", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/Anketler/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.anket = response.data;
    });
});

app.controller("kullanicilar", function ($scope, $http) {

    $http.get("http://localhost:52747/api/Kullanici/Tumu").then(function (response) {
        $scope.kullanici = response.data;
    });
});

app.controller("kullaniciguncelle", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/Kullanici/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.kullan = response.data;
    });
});

app.controller("yoneticiler", function ($scope, $http) {

    $http.get("http://localhost:52747/api/Yonetici/Tumu").then(function (response) {
        $scope.yonetici = response.data;
    });
});

app.controller("yoneticiguncelle", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/Yonetici/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.yonet = response.data;
    });
});


app.controller("firsatlar", function ($scope, $http) {

    $http.get("http://localhost:52747/api/KuaforFirsatlar/TumuGenel").then(function (response) {
        $scope.firsat = response.data;
    });
})

app.controller("firsatincele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforFirsatlar/Ozellestirilmis/" + secondLevelLocation).then(function (response) {
        $scope.firsati = response.data;
    });
});

app.controller("gorevler", function ($scope, $http) {
    $http.get("http://localhost:52747/api/Gorevler/GetGorevlerList/").then(function (response) {
        $scope.grvlr = response.data;
    });
});

app.controller("gorevincele", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/Gorevler/GetGorevlerIncele/" + secondLevelLocation).then(function (response) {
        $scope.grvincele = response.data;
    });
});