namespace BeefKuaforSiram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KuaforMesajTablosunaKullaniciIdiForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.KuaforMesaj", name: "KullaniciId_Id", newName: "KullaniciIdi");
            RenameIndex(table: "dbo.KuaforMesaj", name: "IX_KullaniciId_Id", newName: "IX_KullaniciIdi");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.KuaforMesaj", name: "IX_KullaniciIdi", newName: "IX_KullaniciId_Id");
            RenameColumn(table: "dbo.KuaforMesaj", name: "KullaniciIdi", newName: "KullaniciId_Id");
        }
    }
}
