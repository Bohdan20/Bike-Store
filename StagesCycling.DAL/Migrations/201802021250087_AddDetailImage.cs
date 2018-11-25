namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aerobars", "ImageUrl", c => c.String());
            AddColumn("dbo.ArtworkBeltGuards", "CustomImageUrl", c => c.String());
            AddColumn("dbo.ArtworkFlywheels", "CustomImageUrl", c => c.String());
            AddColumn("dbo.ArtworkFrameForks", "CustomImageUrl", c => c.String());
            AddColumn("dbo.ConsoleTypes", "ImageUrl", c => c.String());
            AddColumn("dbo.HandlebarTypes", "ImageUrl", c => c.String());
            AddColumn("dbo.Models", "ImageUrl", c => c.String());
            AddColumn("dbo.PedalTypes", "ImageUrl", c => c.String());
            AddColumn("dbo.PlasticsColorTypes", "ImageUrl", c => c.String());
            AddColumn("dbo.PowerMeterTypes", "ImageUrl", c => c.String());
            AddColumn("dbo.SeatTypes", "ImageUrl", c => c.String());
            AddColumn("dbo.SprintShiftTypes", "ImageUrl", c => c.String());
            AddColumn("dbo.StagesBikeNumberPlates", "ImageUrl", c => c.String());
            DropColumn("dbo.ArtworkBeltGuards", "ImageUrl");
            DropColumn("dbo.ArtworkFlywheels", "ImageUrl");
            DropColumn("dbo.ArtworkFrameForks", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtworkFrameForks", "ImageUrl", c => c.String());
            AddColumn("dbo.ArtworkFlywheels", "ImageUrl", c => c.String());
            AddColumn("dbo.ArtworkBeltGuards", "ImageUrl", c => c.String());
            DropColumn("dbo.StagesBikeNumberPlates", "ImageUrl");
            DropColumn("dbo.SprintShiftTypes", "ImageUrl");
            DropColumn("dbo.SeatTypes", "ImageUrl");
            DropColumn("dbo.PowerMeterTypes", "ImageUrl");
            DropColumn("dbo.PlasticsColorTypes", "ImageUrl");
            DropColumn("dbo.PedalTypes", "ImageUrl");
            DropColumn("dbo.Models", "ImageUrl");
            DropColumn("dbo.HandlebarTypes", "ImageUrl");
            DropColumn("dbo.ConsoleTypes", "ImageUrl");
            DropColumn("dbo.ArtworkFrameForks", "CustomImageUrl");
            DropColumn("dbo.ArtworkFlywheels", "CustomImageUrl");
            DropColumn("dbo.ArtworkBeltGuards", "CustomImageUrl");
            DropColumn("dbo.Aerobars", "ImageUrl");
        }
    }
}
