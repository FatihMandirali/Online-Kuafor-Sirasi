namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GorevlerTablosu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gorevler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GorevAdi = c.String(nullable: false),
                        TamamlanmaAdet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gorevler");
        }
    }
}
