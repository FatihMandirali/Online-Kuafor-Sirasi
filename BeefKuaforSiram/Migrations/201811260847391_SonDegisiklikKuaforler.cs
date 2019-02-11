namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SonDegisiklikKuaforler : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Kuaforler", name: "KuaforSahipId_Id", newName: "StandardRefId");
            RenameIndex(table: "dbo.Kuaforler", name: "IX_KuaforSahipId_Id", newName: "IX_StandardRefId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Kuaforler", name: "IX_StandardRefId", newName: "IX_KuaforSahipId_Id");
            RenameColumn(table: "dbo.Kuaforler", name: "StandardRefId", newName: "KuaforSahipId_Id");
        }
    }
}
