var app = angular.module("MyApp", []);

app.controller("kuaforlerlistesi", function ($scope, $http) {
    var ID = $("#gelenad").val();
    $http.get("http://localhost:52747/api/Kuaforler/Tumu/" + ID).then(function (response) {
        $scope.kuaforler = response.data;
    });
});

//app.controller("kuafortrascesitleri", function ($scope, $http) {
//    var ID = $(".dd").val();
//    alert(ID);
//    $http.get("http://localhost:52747/api/KuaforTrasCesitleri/TumuCesitler/" + ID).then(function (response) {
//        $scope.kuafortras = response.data;
//    });
//});

app.controller("kuaforfirsat", function ($scope, $http) {
    var ID = $("#gelenad").val();

    $http.get("http://localhost:52747/api/KuaforFirsatlar/Tumu/" + ID).then(function (response) {
        $scope.kuafir = response.data;
    });

    //$scope.kuforpuan = function () {
    //    $http.get("http://localhost:52747/api/KuaforPuan/Ozellestirilmis/1").then(function (response) {
    //        $scope.kpuan = response.data;
    //    });
    //    alert(kuforpuan.HizPuan);
    //}

});


app.controller("kuaforlerpuan", function ($scope, $http) {
    var ID = $("#gelenkua").val();

    $http.get("http://localhost:52747/api/KuaforPuan/Ozellestirilmis/" + ID).then(function (response) {
        $scope.kpuan = response.data;
    });
});

//app.controller("kuaforanket1", function ($scope, $http) {
//    // alert("İÇERDE");
//    $http.get("http://localhost:52747/api/Anketler/Tumu").then(function (response) {
//        $scope.ankett = response.data;
//    });
//});

app.controller("kuafordetaysayfasi", function ($scope, $sce) {

    $scope.hiddenbir = false;
    $scope.hiddeniki = false;
    $scope.hiddenuc = true;
    $scope.trascesit = function () {
        $scope.hiddenbir = !$scope.hiddenbir;
        if ($scope.hiddenbir == true) {
            $scope.hiddeniki = false;
            $scope.hiddenuc = false;
        }
        if ($scope.hiddenbir == false && $scope.hiddeniki == false && $scope.hiddenuc == false) {
            $scope.hiddenbir == true
        }
    }

    $scope.kubilgiler = function () {
        $scope.hiddeniki = !$scope.hiddeniki;
        if ($scope.hiddeniki == true) {
            $scope.hiddenbir = false;
            $scope.hiddenuc = false;
        }
        if ($scope.hiddenbir == false && $scope.hiddeniki == false && $scope.hiddenuc == false) {
            $scope.hiddenbir == true
        }
    }

    $scope.kuyor = function () {
        $scope.hiddenuc = !$scope.hiddenuc;
        if ($scope.hiddenuc == true) {
            $scope.hiddenbir = false;
            $scope.hiddeniki = false;
        }
        if ($scope.hiddenbir == false && $scope.hiddeniki == false && $scope.hiddenuc == false) {
            $scope.hiddenbir == true
        }
    }


});

app.controller("kuafordetaytrascesitleri", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforTrasCesitleri/DetayTrasCesitleri/" + secondLevelLocation).then(function (response) {
        $scope.trscesitleri = response.data;
    });

});

app.controller("kuafordetaybilgiler", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/Kuaforler/DetayBilgiler/" + secondLevelLocation).then(function (response) {
        $scope.trsbilgi = response.data;
    });

});

app.controller("kuafordetayyorumlar", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KuaforDetayYorumlar/DetayYorumlar/" + secondLevelLocation).then(function (response) {
        $scope.trsyorum = response.data;
    });

});

app.controller("kuafordetaysayfagenelbilgi", function ($scope, $http) {//----------
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/Kuaforler/DetayBilgiler/" + secondLevelLocation).then(function (response) {
        $scope.kuadetaybilgileri = response.data;
    });

});

app.controller("kullaniciprofilsayfasi", function ($scope, $sce) {

    $scope.hiddensiralarim = false;
    $scope.hiddenfavorilerim = false;
    $scope.hiddenprofilim = true;
    $scope.hiddenayarlarim = false; 
    $scope.hiddenmesajlarim = false; 


    $scope.ksiralarim = function () {
        $scope.hiddensiralarim = !$scope.hiddensiralarim;
        if ($scope.hiddensiralarim == true) {
            $scope.hiddenfavorilerim = false;
            $scope.hiddenprofilim = false;
            $scope.hiddenayarlarim = false;
            $scope.hiddenmesajlarim == false;
        }
        if ($scope.hiddensiralarim == false && $scope.hiddenfavorilerim == false && $scope.hiddenprofilim == false && $scope.hiddenayarlarim == false) {
            $scope.hiddensiralarim == true
        }
    }
    $scope.kmesajkutusu = function () {
        $scope.hiddensiralarim = !$scope.hiddensiralarim;
        if ($scope.hiddenmesajlarim == true) {
            $scope.hiddenfavorilerim = false;
            $scope.hiddenprofilim = false;
            $scope.hiddenayarlarim = false;
            $scope.hiddensiralarim == false;
        }
        if ($scope.hiddensiralarim == false && $scope.hiddenfavorilerim == false && $scope.hiddenprofilim == false && $scope.hiddenayarlarim == false) {
            $scope.hiddensiralarim == true
        }
    }
    $scope.kfavorilerim = function () {
        $scope.hiddenfavorilerim = !$scope.hiddenfavorilerim;
        if ($scope.hiddenfavorilerim == true) {
            $scope.hiddensiralarim = false;
            $scope.hiddenprofilim = false;
            $scope.hiddenayarlarim = false;
            $scope.hiddenmesajlarim == false;
        }
        if ($scope.hiddensiralarim == false && $scope.hiddenfavorilerim == false && $scope.hiddenprofilim == false && $scope.hiddenayarlarim == false) {
            $scope.hiddenfavorilerim == true
        }
    }

    $scope.kprofilim = function () {
        $scope.hiddenprofilim = !$scope.hiddenprofilim;
        if ($scope.hiddenprofilim == true) {
            $scope.hiddensiralarim = false;
            $scope.hiddenfavorilerim = false;
            $scope.hiddenayarlarim = false;
            $scope.hiddenmesajlarim == false;
        }
        if ($scope.hiddensiralarim == false && $scope.hiddenfavorilerim == false && $scope.hiddenprofilim == false && $scope.hiddenayarlarim == false) {
            $scope.hiddenprofilim == true
        }
    }

    $scope.kayarlarim = function () {
        $scope.hiddenayarlarim = !$scope.hiddenayarlarim;
        if ($scope.hiddenayarlarim == true) {
            $scope.hiddensiralarim = false;
            $scope.hiddenfavorilerim = false;
            $scope.hiddenprofilim = false;
            $scope.hiddenmesajlarim == false;
        }
        if ($scope.hiddensiralarim == false && $scope.hiddenfavorilerim == false && $scope.hiddenprofilim == false && $scope.hiddenayarlarim == false) {
            $scope.hiddenayarlarim == true
        }
    }


});

app.controller("kullanicicuzdansayfasi", function ($scope, $sce) {

    $scope.hiddenkontrol = true;
});

app.controller("_kullaniciprofilfavoriler", function ($scope, $http) {//----------
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KullaniciProfilFavoriler/Tumu/" + secondLevelLocation).then(function (response) {
        $scope.pfavo = response.data;
    });

});

app.controller("_kullaniciprofilprofil", function ($scope, $http) {//----------
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KullaniciProfilFavoriler/Profil/" + secondLevelLocation).then(function (response) {
        $scope.pprof = response.data;
    });

});

app.controller("_kullaniciprofilayarlarim", function ($scope, $http) {//----------
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KullaniciProfilFavoriler/Ayarlarim/" + secondLevelLocation).then(function (response) {
        $scope.payar = response.data;
    });

});

//Kuafor Sıra Alma 

app.controller("kuaforsiraal", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/SiraAl/TrasCesitleri/" + secondLevelLocation).then(function (response) {
        $scope.trascesit = response.data;
    });

});

//app.controller("kuaforaralik", function ($scope, $http) {
//    var pathArray = window.location.pathname.split('/');
//    var secondLevelLocation = pathArray[3];
//    $http.get("http://localhost:52747/api/SiraAl/SiraAralik/" + secondLevelLocation).then(function (response) {
//        $scope.trasaralik = response.data;
//    });

//});

app.controller("kuafortraseleman", function ($scope, $http) {
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/SiraAl/KuaforElemanlari/" + secondLevelLocation).then(function (response) {
        $scope.traseleman = response.data;
    });

});

app.controller("kuaforlerProfilAlinanSiralar", function ($scope, $http) {
    var kullaniId = $("#kullaniciSession").val();
    $http.get("http://localhost:52747/api/SiraAl/KullaniciAlinanSiralar/" + kullaniId).then(function (response) {
        $scope.kuaforAldigimSiralar = response.data;
    });

});


app.controller("_kullaniciCuzdanKontrol", function ($scope, $http) {//----------
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    $http.get("http://localhost:52747/api/KullaniciCuzdan/GetCuzdanKontrol/" + secondLevelLocation).then(function (response) {
        $scope.kullaniciCuzdanKntrl = response.data;
    });

});







