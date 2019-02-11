namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforTrasCesitleri_KuaforId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KuaforTrasCesitleri", "KuaforId_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.KuaforTrasCesitleri", "KuaforId_Id");
            AddForeignKey("dbo.KuaforTrasCesitleri", "KuaforId_Id", "dbo.Kuaforler", "Id", cascadeDelete: true);
            DropColumn("dbo.KuaforTrasCesitleri", "KuaforId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KuaforTrasCesitleri", "KuaforId", c => c.Int(nullable: false));
            DropForeignKey("dbo.KuaforTrasCesitleri", "KuaforId_Id", "dbo.Kuaforler");
            DropIndex("dbo.KuaforTrasCesitleri", new[] { "KuaforId_Id" });
            DropColumn("dbo.KuaforTrasCesitleri", "KuaforId_Id");
        }
    }
}
