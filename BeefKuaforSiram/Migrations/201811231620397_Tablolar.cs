namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablolar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KuaforAktiflik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aktiflik = c.Boolean(nullable: false),
                        Sebep = c.String(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id);
            
            CreateTable(
                "dbo.Kuaforler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Sehir = c.String(nullable: false),
                        Semt = c.String(nullable: false),
                        Adres = c.String(nullable: false),
                        EMail = c.String(nullable: false),
                        Resim = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Puan = c.Int(nullable: false),
                        BayBayan = c.Int(nullable: false),
                        Slug = c.String(nullable: false),
                        AcilmaSaati = c.String(nullable: false),
                        KapanmaSaati = c.String(nullable: false),
                        Aralik = c.String(nullable: false),
                        KuaforSahipId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KuaforSahip", t => t.KuaforSahipId_Id, cascadeDelete: true)
                .Index(t => t.KuaforSahipId_Id);
            
            CreateTable(
                "dbo.KuaforSahip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        KullaniciAdi = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                        Sehir = c.String(nullable: false),
                        Semt = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        Tc = c.String(nullable: false),
                        DogumTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KuaforAnket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Soru = c.String(nullable: false),
                        CevapA = c.String(nullable: false),
                        CevapB = c.String(nullable: false),
                        CevapC = c.String(nullable: false),
                        CevapD = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KuaforAnketCevap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cevap = c.String(nullable: false),
                        KuaforAnketId_Id = c.Int(nullable: false),
                        KullaniciId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KuaforAnket", t => t.KuaforAnketId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .Index(t => t.KuaforAnketId_Id)
                .Index(t => t.KullaniciId_Id);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        KullaniciAdi = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                        Sehir = c.String(nullable: false),
                        Semt = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        DogumTarihi = c.DateTime(nullable: false),
                        Slug = c.String(nullable: false),
                        Avatar = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KuaforElemanlari",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false),
                        Soyadi = c.String(nullable: false),
                        Tc = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id);
            
            CreateTable(
                "dbo.KuaforFirsat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirsatIcerik = c.String(nullable: false),
                        FirsatYayinTarih = c.DateTime(nullable: false),
                        YoneticiOnayi = c.Int(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id);
            
            CreateTable(
                "dbo.KuaforMesaj",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mesaj = c.String(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                        KullaniciId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id)
                .Index(t => t.KullaniciId_Id);
            
            CreateTable(
                "dbo.KuaforPuan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HizPuan = c.Int(nullable: false),
                        OzenPuan = c.Int(nullable: false),
                        KalitePuan = c.Int(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                        KullaniciId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id)
                .Index(t => t.KullaniciId_Id);
            
            CreateTable(
                "dbo.KuaforSaatleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcilmaSaati = c.String(nullable: false),
                        KapanmaSaati = c.String(nullable: false),
                        Aralik = c.String(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id);
            
            CreateTable(
                "dbo.KuaforSira",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KuaforCesitAdi = c.String(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        BaslamaSaati = c.String(nullable: false),
                        BitisSaati = c.String(nullable: false),
                        KuaforElemanlariAdiSoyadi = c.String(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                        KullaniciId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id)
                .Index(t => t.KullaniciId_Id);
            
            CreateTable(
                "dbo.KuaforTrasCesitleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KuaforId = c.Int(nullable: false),
                        Cesit = c.String(nullable: false),
                        Fiyat = c.Int(nullable: false),
                        Dk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KuaforTrasSaatiAralik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaslamaSaati = c.String(nullable: false),
                        BitisSaati = c.String(nullable: false),
                        ElemanId = c.Int(nullable: false),
                        Dolu = c.Boolean(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id);
            
            CreateTable(
                "dbo.KuaforYorum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Yorum = c.String(nullable: false),
                        HizPuan = c.Int(nullable: false),
                        OzenPuan = c.Int(nullable: false),
                        KalitePuan = c.Int(nullable: false),
                        KuaforId_Id = c.Int(nullable: false),
                        KullaniciId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id)
                .Index(t => t.KullaniciId_Id);
            
            CreateTable(
                "dbo.KullaniciCuzdan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Puan = c.Int(nullable: false),
                        KullaniciId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .Index(t => t.KullaniciId_Id);
            
            CreateTable(
                "dbo.KullaniciFavorileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KuaforId_Id = c.Int(nullable: false),
                        KullaniciId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id)
                .Index(t => t.KullaniciId_Id);
            
            CreateTable(
                "dbo.KullaniciIslemleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdSoyad = c.String(),
                        Aktiflik = c.Boolean(nullable: false),
                        KuaforSiraId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KuaforSira", t => t.KuaforSiraId_Id, cascadeDelete: true)
                .Index(t => t.KuaforSiraId_Id);
            
            CreateTable(
                "dbo.KullaniciRozet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciId_Id = c.Int(nullable: false),
                        RozetId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rozetler", t => t.RozetId_Id, cascadeDelete: true)
                .Index(t => t.KullaniciId_Id)
                .Index(t => t.RozetId_Id);
            
            CreateTable(
                "dbo.Rozetler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RozetAdi = c.String(nullable: false),
                        Resim = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YeniEklenenKuaforler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KuaforId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kuaforler", t => t.KuaforId_Id, cascadeDelete: true)
                .Index(t => t.KuaforId_Id);
            
            CreateTable(
                "dbo.Yonetici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        KullaniciAdi = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                        Sehir = c.String(nullable: false),
                        Semt = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        DogumTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YeniEklenenKuaforler", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KullaniciRozet", "RozetId_Id", "dbo.Rozetler");
            DropForeignKey("dbo.KullaniciRozet", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KullaniciIslemleri", "KuaforSiraId_Id", "dbo.KuaforSira");
            DropForeignKey("dbo.KullaniciFavorileri", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KullaniciFavorileri", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KullaniciCuzdan", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KuaforYorum", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KuaforYorum", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforTrasSaatiAralik", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforSira", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KuaforSira", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforSaatleri", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforPuan", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KuaforPuan", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforMesaj", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KuaforMesaj", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforFirsat", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforElemanlari", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.KuaforAnketCevap", "KullaniciId_Id", "dbo.Kullanici");
            DropForeignKey("dbo.KuaforAnketCevap", "KuaforAnketId_Id", "dbo.KuaforAnket");
            DropForeignKey("dbo.KuaforAktiflik", "KuaforId_Id", "dbo.Kuaforler");
            DropForeignKey("dbo.Kuaforler", "KuaforSahipId_Id", "dbo.KuaforSahip");
            DropIndex("dbo.YeniEklenenKuaforler", new[] { "KuaforId_Id" });
            DropIndex("dbo.KullaniciRozet", new[] { "RozetId_Id" });
            DropIndex("dbo.KullaniciRozet", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KullaniciIslemleri", new[] { "KuaforSiraId_Id" });
            DropIndex("dbo.KullaniciFavorileri", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KullaniciFavorileri", new[] { "KuaforId_Id" });
            DropIndex("dbo.KullaniciCuzdan", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KuaforYorum", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KuaforYorum", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforTrasSaatiAralik", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforSira", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KuaforSira", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforSaatleri", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforPuan", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KuaforPuan", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforMesaj", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KuaforMesaj", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforFirsat", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforElemanlari", new[] { "KuaforId_Id" });
            DropIndex("dbo.KuaforAnketCevap", new[] { "KullaniciId_Id" });
            DropIndex("dbo.KuaforAnketCevap", new[] { "KuaforAnketId_Id" });
            DropIndex("dbo.Kuaforler", new[] { "KuaforSahipId_Id" });
            DropIndex("dbo.KuaforAktiflik", new[] { "KuaforId_Id" });
            DropTable("dbo.Yonetici");
            DropTable("dbo.YeniEklenenKuaforler");
            DropTable("dbo.Rozetler");
            DropTable("dbo.KullaniciRozet");
            DropTable("dbo.KullaniciIslemleri");
            DropTable("dbo.KullaniciFavorileri");
            DropTable("dbo.KullaniciCuzdan");
            DropTable("dbo.KuaforYorum");
            DropTable("dbo.KuaforTrasSaatiAralik");
            DropTable("dbo.KuaforTrasCesitleri");
            DropTable("dbo.KuaforSira");
            DropTable("dbo.KuaforSaatleri");
            DropTable("dbo.KuaforPuan");
            DropTable("dbo.KuaforMesaj");
            DropTable("dbo.KuaforFirsat");
            DropTable("dbo.KuaforElemanlari");
            DropTable("dbo.Kullanici");
            DropTable("dbo.KuaforAnketCevap");
            DropTable("dbo.KuaforAnket");
            DropTable("dbo.KuaforSahip");
            DropTable("dbo.Kuaforler");
            DropTable("dbo.KuaforAktiflik");
        }
    }
}
