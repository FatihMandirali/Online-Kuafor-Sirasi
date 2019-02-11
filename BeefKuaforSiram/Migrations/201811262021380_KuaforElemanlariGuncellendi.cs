namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforElemanlariGuncellendi : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.KuaforElemanlari", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameIndex(table: "dbo.KuaforElemanlari", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.KuaforElemanlari", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameColumn(table: "dbo.KuaforElemanlari", name: "KuaforIdi", newName: "KuaforId_Id");
        }
    }
}
