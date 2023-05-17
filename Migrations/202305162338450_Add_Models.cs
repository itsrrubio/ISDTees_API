namespace ISDTees_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigName = c.String(),
                        ConfigValue = c.String(),
                        ConfigDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(),
                        CustomerName = c.String(),
                        AddressID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LineItemID = c.String(),
                        ProductID = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        OrderName = c.String(),
                        CustomerID = c.String(),
                        ContactName = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        OrderNotes = c.String(),
                        SubTotal = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            sku = c.String(),
            //            gtin = c.String(),
            //            skuID_Master = c.String(),
            //            styleID = c.String(),
            //            brandName = c.String(),
            //            styleName = c.String(),
            //            colorName = c.String(),
            //            colorCode = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecID = c.Int(nullable: false),
                        SizeName = c.String(),
                        SizeOrder = c.String(),
                        SpecName = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StyleID = c.Int(nullable: false),
                        PartNumber = c.String(),
                        BrandName = c.String(),
                        StyleName = c.String(),
                        UniquestyleName = c.String(),
                        Title = c.String(),
                        BaseCategory = c.String(),
                        ComparableGroup = c.Int(nullable: false),
                        CompanionGroup = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Styles");
            DropTable("dbo.Specs");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.LineItems");
            DropTable("dbo.Customers");
            DropTable("dbo.Configs");
        }
    }
}
