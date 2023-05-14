namespace ISDTees_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sku = c.String(),
                        gtin = c.String(),
                        skuID_Master = c.String(),
                        styleID = c.String(),
                        brandName = c.String(),
                        styleName = c.String(),
                        colorName = c.String(),
                        colorCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
