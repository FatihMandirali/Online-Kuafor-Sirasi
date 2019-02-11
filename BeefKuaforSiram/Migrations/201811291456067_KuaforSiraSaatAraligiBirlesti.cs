namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforSiraSaatAraligiBirlesti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KuaforSira", "KuaforSaatAralik", c => c.String(nullable: false));
            DropColumn("dbo.KuaforSira", "BaslamaSaati");
            DropColumn("dbo.KuaforSira", "BitisSaati");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KuaforSira", "BitisSaati", c => c.String(nullable: false));
            AddColumn("dbo.KuaforSira", "BaslamaSaati", c => c.String(nullable: false));
            DropColumn("dbo.KuaforSira", "KuaforSaatAralik");
        }
    }
}
