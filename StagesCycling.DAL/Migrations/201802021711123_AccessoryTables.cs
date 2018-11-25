namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessoryTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandlebarPosts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MediaShelves",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneHolders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SeatPosts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StagesDumbbellHolders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TabletHolders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Sourcing = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDefinedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        DefaultSC2 = c.Boolean(nullable: false),
                        DefaultSC3 = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "TabletHolderId", c => c.Long());
            AddColumn("dbo.Orders", "PhoneHolderId", c => c.Long());
            AddColumn("dbo.Orders", "MediaShelfId", c => c.Long());
            AddColumn("dbo.Orders", "SeatPostId", c => c.Long());
            AddColumn("dbo.Orders", "HandlebarPostId", c => c.Long());
            AddColumn("dbo.Orders", "StagesDumbbellHolderId", c => c.Long());
            DropColumn("dbo.Orders", "IsTabletHolder");
            DropColumn("dbo.Orders", "IsPhoneHolder");
            DropColumn("dbo.Orders", "IsMediaShelf");
            DropColumn("dbo.Orders", "IsSeatPost");
            DropColumn("dbo.Orders", "IsHandlebarPost");
            DropColumn("dbo.Orders", "IsStagesDumbbellHolder");
            DropColumn("dbo.Orders", "StagesBikeNumberPlateQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "StagesBikeNumberPlateQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "IsStagesDumbbellHolder", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsHandlebarPost", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsSeatPost", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsMediaShelf", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsPhoneHolder", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsTabletHolder", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "StagesDumbbellHolderId");
            DropColumn("dbo.Orders", "HandlebarPostId");
            DropColumn("dbo.Orders", "SeatPostId");
            DropColumn("dbo.Orders", "MediaShelfId");
            DropColumn("dbo.Orders", "PhoneHolderId");
            DropColumn("dbo.Orders", "TabletHolderId");
            DropTable("dbo.TabletHolders");
            DropTable("dbo.StagesDumbbellHolders");
            DropTable("dbo.SeatPosts");
            DropTable("dbo.PhoneHolders");
            DropTable("dbo.MediaShelves");
            DropTable("dbo.HandlebarPosts");
        }
    }
}
