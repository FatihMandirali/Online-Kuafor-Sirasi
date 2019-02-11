namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforMesajDurumlarEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KuaforMesaj", "YoneticiDurum", c => c.Boolean(nullable: false));
            AddColumn("dbo.KuaforMesaj", "KullaniciDurum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KuaforMesaj", "KullaniciDurum");
            DropColumn("dbo.KuaforMesaj", "YoneticiDurum");
        }
    }
}
