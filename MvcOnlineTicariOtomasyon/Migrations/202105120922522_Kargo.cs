namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoID = c.Int(nullable: false, identity: true),
                        KargoAciklama = c.String(maxLength: 300, unicode: false),
                        KargoTakipKodu = c.String(maxLength: 10, unicode: false),
                        KargoPersonel = c.String(maxLength: 20, unicode: false),
                        KargoAlici = c.String(maxLength: 20, unicode: false),
                        KargoTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoID);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipID = c.Int(nullable: false, identity: true),
                        KargoTakipKodu = c.String(maxLength: 10, unicode: false),
                        KargoTakipAciklama = c.String(maxLength: 100, unicode: false),
                        KargoTakipTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
