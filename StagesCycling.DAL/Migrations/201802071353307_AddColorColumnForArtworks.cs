namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorColumnForArtworks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtworkBeltGuards", "CustomColor", c => c.String());
            AddColumn("dbo.ArtworkFlywheels", "CustomColor", c => c.String());
            AddColumn("dbo.ArtworkFrameForks", "CustomColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArtworkFrameForks", "CustomColor");
            DropColumn("dbo.ArtworkFlywheels", "CustomColor");
            DropColumn("dbo.ArtworkBeltGuards", "CustomColor");
        }
    }
}
