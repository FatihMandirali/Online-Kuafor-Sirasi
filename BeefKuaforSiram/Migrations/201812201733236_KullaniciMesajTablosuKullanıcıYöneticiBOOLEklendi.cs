namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullaniciMesajTablosuKullanıcıYöneticiBOOLEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KuaforMesaj", "Kullanici", c => c.Boolean(nullable: false));
            AddColumn("dbo.KuaforMesaj", "Yonetici", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KuaforMesaj", "Yonetici");
            DropColumn("dbo.KuaforMesaj", "Kullanici");
        }
    }
}
