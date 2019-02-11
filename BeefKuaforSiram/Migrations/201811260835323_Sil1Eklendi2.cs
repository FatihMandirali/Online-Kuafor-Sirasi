namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sil1Eklendi2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sil1",
                c => new
                    {
                        dsg = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.dsg);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sil1");
        }
    }
}
