namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GorevDurumTablosuEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GorevDurum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullanciciIdi = c.Int(nullable: false),
                        GorevlerIdi = c.Int(nullable: false),
                        TamamlanmaSayisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gorevler", t => t.GorevlerIdi, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullanciciIdi, cascadeDelete: true)
                .Index(t => t.KullanciciIdi)
                .Index(t => t.GorevlerIdi);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GorevDurum", "KullanciciIdi", "dbo.Kullanici");
            DropForeignKey("dbo.GorevDurum", "GorevlerIdi", "dbo.Gorevler");
            DropIndex("dbo.GorevDurum", new[] { "GorevlerIdi" });
            DropIndex("dbo.GorevDurum", new[] { "KullanciciIdi" });
            DropTable("dbo.GorevDurum");
        }
    }
}
