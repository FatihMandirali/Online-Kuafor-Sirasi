namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforSiraTarihToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KuaforSira", "Tarih", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KuaforSira", "Tarih", c => c.DateTime(nullable: false));
        }
    }
}
