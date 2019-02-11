namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforSahipDeleteDogumTarihiColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.KuaforSahip", "DogumTarihi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KuaforSahip", "DogumTarihi", c => c.DateTime(nullable: false));
        }
    }
}
