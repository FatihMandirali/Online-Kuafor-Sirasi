namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GorevlerveGorevDurumTablosuSilindi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GorevDurum", "GorevlerIdi", "dbo.Gorevler");
            DropForeignKey("dbo.GorevDurum", "KullanciciIdi", "dbo.Kullanici");
            DropIndex("dbo.GorevDurum", new[] { "KullanciciIdi" });
            DropIndex("dbo.GorevDurum", new[] { "GorevlerIdi" });
            DropTable("dbo.GorevDurum");
            DropTable("dbo.Gorevler");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Gorevler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GorevAdi = c.String(nullable: false),
                        TamamlanmaAdet = c.Int(nullable: false),
                        BasariPuani = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GorevDurum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullanciciIdi = c.Int(nullable: false),
                        GorevlerIdi = c.Int(nullable: false),
                        TamamlanmaSayisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.GorevDurum", "GorevlerIdi");
            CreateIndex("dbo.GorevDurum", "KullanciciIdi");
            AddForeignKey("dbo.GorevDurum", "KullanciciIdi", "dbo.Kullanici", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GorevDurum", "GorevlerIdi", "dbo.Gorevler", "Id", cascadeDelete: true);
        }
    }
}
