namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyEskiHali : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Kuaforler", name: "KuaforId", newName: "KuaforSahipId_Id");
            RenameIndex(table: "dbo.Kuaforler", name: "IX_KuaforId", newName: "IX_KuaforSahipId_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Kuaforler", name: "IX_KuaforSahipId_Id", newName: "IX_KuaforId");
            RenameColumn(table: "dbo.Kuaforler", name: "KuaforSahipId_Id", newName: "KuaforId");
        }
    }
}
