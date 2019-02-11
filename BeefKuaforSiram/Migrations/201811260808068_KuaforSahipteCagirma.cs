namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforSahipteCagirma : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Kuaforler", name: "KuaforSahipId_Id", newName: "KuaforId");
            RenameIndex(table: "dbo.Kuaforler", name: "IX_KuaforSahipId_Id", newName: "IX_KuaforId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Kuaforler", name: "IX_KuaforId", newName: "IX_KuaforSahipId_Id");
            RenameColumn(table: "dbo.Kuaforler", name: "KuaforId", newName: "KuaforSahipId_Id");
        }
    }
}
