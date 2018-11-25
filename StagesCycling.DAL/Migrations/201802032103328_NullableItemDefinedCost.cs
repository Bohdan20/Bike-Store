namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableItemDefinedCost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aerobars", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ConsoleTypes", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.HandlebarPosts", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.HandlebarTypes", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.MediaShelves", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Models", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.PedalTypes", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.PhoneHolders", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.PlasticsColorTypes", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.PowerMeterTypes", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.SeatPosts", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.SeatTypes", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.SprintShiftTypes", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.StagesBikeNumberPlates", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.StagesDumbbellHolders", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.TabletHolders", "ItemDefinedCost", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TabletHolders", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StagesDumbbellHolders", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StagesBikeNumberPlates", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SprintShiftTypes", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SeatTypes", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SeatPosts", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PowerMeterTypes", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PlasticsColorTypes", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PhoneHolders", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PedalTypes", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Models", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MediaShelves", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HandlebarTypes", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HandlebarPosts", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ConsoleTypes", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Aerobars", "ItemDefinedCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
