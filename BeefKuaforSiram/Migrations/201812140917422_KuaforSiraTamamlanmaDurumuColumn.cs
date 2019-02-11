namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforSiraTamamlanmaDurumuColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KuaforSira", "TamamlanmaDurum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KuaforSira", "TamamlanmaDurum");
        }
    }
}
