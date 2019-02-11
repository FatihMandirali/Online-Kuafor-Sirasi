namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforSahiptenSildim : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Kuaforler", name: "StandardRefId", newName: "KuaforSahipIdi");
            RenameIndex(table: "dbo.Kuaforler", name: "IX_StandardRefId", newName: "IX_KuaforSahipIdi");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Kuaforler", name: "IX_KuaforSahipIdi", newName: "IX_StandardRefId");
            RenameColumn(table: "dbo.Kuaforler", name: "KuaforSahipIdi", newName: "StandardRefId");
        }
    }
}
