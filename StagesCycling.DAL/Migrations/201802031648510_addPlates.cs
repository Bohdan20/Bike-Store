namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlates : DbMigration
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
            DropColumn("dbo.Orders", "StagesBikeNumberPlateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "StagesBikeNumberPlateId", c => c.Long());
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
