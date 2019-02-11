namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullanicilarTableRemoveColumnDogumTarihi : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Kullanici", "DogumTarihi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kullanici", "DogumTarihi", c => c.DateTime(nullable: false));
        }
    }
}
