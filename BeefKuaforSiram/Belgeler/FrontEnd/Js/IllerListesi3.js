var iller = ['Adana', 'Adıyaman', 'Afyon', 'Ağrıı', 'Amasya', 'Ankara', 'Antalya', 'Artvin',
'Aydın', 'Balıkesir', 'Bilecik', 'Bingöl', 'Bitlis', 'Bolu', 'Burdur', 'Bursa', 'Çanakkale',
'Çankırı', 'Çorum', 'Denizli', 'Diyarbakır', 'Edirne', 'Elazığ', 'Erzincan', 'Erzurum', 'Eskişehir',
'Gaziantep', 'Giresun', 'Gümüşhane', 'Hakkari', 'Hatay', 'Isparta', 'Mersin', 'İstanbul', 'İzmir',
'Kars', 'Kastamonu', 'Kayseri', 'Kırklareli', 'Kırşehir', 'Kocaeli', 'Konya', 'Kütahya', 'Malatya',
'Manisa', 'Maraş', 'Mardin', 'Muğla', 'Muş', 'Nevşehir', 'Niğde', 'Ordu', 'Rize', 'Sakarya',
'Samsun', 'Siirt', 'Sinop', 'Sivas', 'Tekirdağ', 'Tokat', 'Trabzon', 'Tunceli', 'Şanlıurfa', 'Uşak',
'Van', 'Yozgat', 'Zonguldak', 'Aksaray', 'Bayburt', 'Karaman', 'Kırıkkale', 'Batman', 'Şırnak',
'Bartın', 'Ardahan', 'Iğdır', 'Yalova', 'Karabük', 'Kilis', 'Osmaniye', 'Düzce'];

var illering = ['adana', 'adiyaman', 'afyon', 'agri', 'amasya', 'ankara', 'antalya', 'artvin',
'aydin', 'balikesir', 'bilecik', 'bingol', 'bitlis', 'bolu', 'burdur', 'bursa', 'canakkale',
'cankiri', 'corum', 'denizli', 'diyarbakir', 'edirne', 'elazig', 'erzincan', 'erzurum', 'eskisehir',
'gaziantep', 'giresun', 'gümüshane', 'hakkari', 'hatay', 'isparta', 'mersin', 'istanbul', 'izmir',
'kars', 'kastamonu', 'kayseri', 'kirklareli', 'kirsehir', 'kocaeli', 'konya', 'kutahya', 'malatya',
'manisa', 'maras', 'mardin', 'mugla', 'mus', 'nevsehir', 'nigde', 'ordu', 'rize', 'sakarya',
'samsun', 'siirt', 'sinop', 'sivas', 'tekirdag', 'tokat', 'trabzon', 'tunceli', 'sanliurfa', 'usak',
'van', 'yozgat', 'zonguldak', 'aksaray', 'bayburt', 'karaman', 'kirikkale', 'batman', 'sirnak',
'bartin', 'ardahan', 'igdir', 'yalova', 'karabuk', 'kilis', 'osmaniye', 'duzce'];



//for (var i = 0; i < iller.length; i++) {
//    $(".illerlistesi").append("<div class='col-md-1 mt-2 sehirlerborder'><div class='btn btn-outline-primary d-block text-center kutucuk'>" + (i + 1) + "</div><div class='d-block text-center'><a href='/Home/Sehir/" + iller[i] + "'>" + iller[i] + "</div></div>");
//}

for (var i = 0; i < iller.length; i++) {
    $(".illerlistesi").append("<div class='col-md-1 mt-2 sehirlerborder'><a href='/Home/Iller/" + illering[i] + "'><div class='btn btn-outline-primary d-block text-center kutucuk'>" + (i + 1) + "</div><div class='d-block text-center'>" + iller[i] + "</div></a></div>");
}


