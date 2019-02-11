namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforSiraDurumEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KuaforSira", "SiraDurum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KuaforSira", "SiraDurum");
        }
    }
}
