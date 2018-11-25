namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveItemDefinedCost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArtworkBeltGuards", "ItemDefinedCost");
            DropColumn("dbo.ArtworkFlywheels", "ItemDefinedCost");
            DropColumn("dbo.ArtworkFrameForks", "ItemDefinedCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtworkFrameForks", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ArtworkFlywheels", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ArtworkBeltGuards", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
