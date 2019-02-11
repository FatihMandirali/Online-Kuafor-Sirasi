namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforTrasSaatiAralikGuncellendi : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.KuaforTrasSaatiAralik", name: "KuaforId_Id", newName: "KuaforIdi");
            RenameIndex(table: "dbo.KuaforTrasSaatiAralik", name: "IX_KuaforId_Id", newName: "IX_KuaforIdi");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.KuaforTrasSaatiAralik", name: "IX_KuaforIdi", newName: "IX_KuaforId_Id");
            RenameColumn(table: "dbo.KuaforTrasSaatiAralik", name: "KuaforIdi", newName: "KuaforId_Id");
        }
    }
}
