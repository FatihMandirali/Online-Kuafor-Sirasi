namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeriTabaniForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.KuaforAktiflik", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforAnketCevap", name: "KuaforAnketId_Id", newName: "KuaforAnketIdi");
            RenameColumn(table: "dbo.KuaforAnketCevap", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameColumn(table: "dbo.KuaforFirsat", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforMesaj", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforPuan", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforPuan", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameColumn(table: "dbo.KuaforSaatleri", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforSira", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforSira", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameColumn(table: "dbo.KuaforTrasCesitleri", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforYorum", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KuaforYorum", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameColumn(table: "dbo.KullaniciCuzdan", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameColumn(table: "dbo.KullaniciFavorileri", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameColumn(table: "dbo.KullaniciFavorileri", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameColumn(table: "dbo.KullaniciIslemleri", name: "KuaforSiraId_Id", newName: "KuaforSiraIdi");
            RenameColumn(table: "dbo.KullaniciRozet", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameColumn(table: "dbo.KullaniciRozet", name: "RozetId_Id", newName: "RozetIdi");
            RenameColumn(table: "dbo.YeniEklenenKuaforler", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameIndex(table: "dbo.KuaforAktiflik", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforAnketCevap", name: "IX_KuaforAnketId_Id", newName: "IX_KuaforAnketIdi");
            RenameIndex(table: "dbo.KuaforAnketCevap", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
            RenameIndex(table: "dbo.KuaforFirsat", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforMesaj", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforPuan", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforPuan", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
            RenameIndex(table: "dbo.KuaforSaatleri", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforSira", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforSira", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
            RenameIndex(table: "dbo.KuaforTrasCesitleri", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforYorum", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KuaforYorum", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
            RenameIndex(table: "dbo.KullaniciCuzdan", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
            RenameIndex(table: "dbo.KullaniciFavorileri", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
            RenameIndex(table: "dbo.KullaniciFavorileri", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
            RenameIndex(table: "dbo.KullaniciIslemleri", name: "IX_KuaforSiraId_Id", newName: "IX_KuaforSiraIdi");
            RenameIndex(table: "dbo.KullaniciRozet", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
            RenameIndex(table: "dbo.KullaniciRozet", name: "IX_RozetId_Id", newName: "IX_RozetIdi");
            RenameIndex(table: "dbo.YeniEklenenKuaforler", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.YeniEklenenKuaforler", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KullaniciRozet", name: "IX_RozetIdi", newName: "IX_RozetId_Id");
            RenameIndex(table: "dbo.KullaniciRozet", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameIndex(table: "dbo.KullaniciIslemleri", name: "IX_KuaforSiraIdi", newName: "IX_KuaforSiraId_Id");
            RenameIndex(table: "dbo.KullaniciFavorileri", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KullaniciFavorileri", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameIndex(table: "dbo.KullaniciCuzdan", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameIndex(table: "dbo.KuaforYorum", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameIndex(table: "dbo.KuaforYorum", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KuaforTrasCesitleri", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KuaforSira", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameIndex(table: "dbo.KuaforSira", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KuaforSaatleri", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KuaforPuan", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameIndex(table: "dbo.KuaforPuan", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KuaforMesaj", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KuaforFirsat", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameIndex(table: "dbo.KuaforAnketCevap", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameIndex(table: "dbo.KuaforAnketCevap", name: "IX_KuaforAnketIdi", newName: "IX_KuaforAnketId_Id");
            RenameIndex(table: "dbo.KuaforAktiflik", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameColumn(table: "dbo.YeniEklenenKuaforler", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KullaniciRozet", name: "RozetIdi", newName: "RozetId_Id");
            RenameColumn(table: "dbo.KullaniciRozet", name: "KullaniciIdi", newName: "KullaniciId_Id");
            RenameColumn(table: "dbo.KullaniciIslemleri", name: "KuaforSiraIdi", newName: "KuaforSiraId_Id");
            RenameColumn(table: "dbo.KullaniciFavorileri", name: "KullaniciIdi", newName: "KullaniciId_Id");
            RenameColumn(table: "dbo.KullaniciFavorileri", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KullaniciCuzdan", name: "KullaniciIdi", newName: "KullaniciId_Id");
            RenameColumn(table: "dbo.KuaforYorum", name: "KullaniciIdi", newName: "KullaniciId_Id");
            RenameColumn(table: "dbo.KuaforYorum", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KuaforTrasCesitleri", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KuaforSira", name: "KullaniciIdi", newName: "KullaniciId_Id");
            RenameColumn(table: "dbo.KuaforSira", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KuaforSaatleri", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KuaforPuan", name: "KullaniciIdi", newName: "KullaniciId_Id");
            RenameColumn(table: "dbo.KuaforPuan", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KuaforMesaj", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KuaforFirsat", name: "KuaforIdi", newName: "KuaforId_Id");
            RenameColumn(table: "dbo.KuaforAnketCevap", name: "KullaniciIdi", newName: "KullaniciId_Id");
            RenameColumn(table: "dbo.KuaforAnketCevap", name: "KuaforAnketIdi", newName: "KuaforAnketId_Id");
            RenameColumn(table: "dbo.KuaforAktiflik", name: "KuaforIdi", newName: "KuaforId_Id");
        }
    }
}
