namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sil1Silindi : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.sil1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.sil1",
                c => new
                    {
                        dsg = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.dsg);
            
        }
    }
}
