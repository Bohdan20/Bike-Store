namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrderPlates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PlatesOneToSixtyQuntity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PlatesOneToSixtyId", c => c.Long());
            AddColumn("dbo.Orders", "PlatesSixtyOneToHundredId", c => c.Long());
            AddColumn("dbo.Orders", "PlatesSixtyOneToHundredQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PlatesOneToEightyId", c => c.Long());
            AddColumn("dbo.Orders", "PlatesOneToEightyQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PlatesFiftyPeacesId", c => c.Long());
            AddColumn("dbo.Orders", "PlatesFiftyPeacesQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PlatesOneToThirtyId", c => c.Long());
            AddColumn("dbo.Orders", "PlatesOneToThirtyQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Aerobars", "DefaultSC2");
            DropColumn("dbo.Aerobars", "DefaultSC3");
            DropColumn("dbo.HandlebarPosts", "DefaultSC2");
            DropColumn("dbo.HandlebarPosts", "DefaultSC3");
            DropColumn("dbo.MediaShelves", "DefaultSC2");
            DropColumn("dbo.MediaShelves", "DefaultSC3");
            DropColumn("dbo.Orders", "StagesBikeNumberPlateId");
            DropColumn("dbo.PhoneHolders", "DefaultSC2");
            DropColumn("dbo.PhoneHolders", "DefaultSC3");
            DropColumn("dbo.SeatPosts", "DefaultSC2");
            DropColumn("dbo.SeatPosts", "DefaultSC3");
            DropColumn("dbo.StagesBikeNumberPlates", "DefaultSC2");
            DropColumn("dbo.StagesBikeNumberPlates", "DefaultSC3");
            DropColumn("dbo.StagesDumbbellHolders", "DefaultSC2");
            DropColumn("dbo.StagesDumbbellHolders", "DefaultSC3");
            DropColumn("dbo.TabletHolders", "DefaultSC2");
            DropColumn("dbo.TabletHolders", "DefaultSC3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TabletHolders", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.TabletHolders", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.StagesDumbbellHolders", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.StagesDumbbellHolders", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.StagesBikeNumberPlates", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.StagesBikeNumberPlates", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.SeatPosts", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.SeatPosts", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhoneHolders", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhoneHolders", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "StagesBikeNumberPlateId", c => c.Long());
            AddColumn("dbo.MediaShelves", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.MediaShelves", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.HandlebarPosts", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.HandlebarPosts", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Aerobars", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Aerobars", "DefaultSC2", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "PlatesOneToThirtyQuantity");
            DropColumn("dbo.Orders", "PlatesOneToThirtyId");
            DropColumn("dbo.Orders", "PlatesFiftyPeacesQuantity");
            DropColumn("dbo.Orders", "PlatesFiftyPeacesId");
            DropColumn("dbo.Orders", "PlatesOneToEightyQuantity");
            DropColumn("dbo.Orders", "PlatesOneToEightyId");
            DropColumn("dbo.Orders", "PlatesSixtyOneToHundredQuantity");
            DropColumn("dbo.Orders", "PlatesSixtyOneToHundredId");
            DropColumn("dbo.Orders", "PlatesOneToSixtyId");
            DropColumn("dbo.Orders", "PlatesOneToSixtyQuntity");
        }
    }
}
