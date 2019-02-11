namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GorevlerTablosuBasariPuaniEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gorevler", "BasariPuani", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gorevler", "BasariPuani");
        }
    }
}
