namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameArtworkColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtworkBeltGuards", "Title", c => c.String());
            AddColumn("dbo.ArtworkFlywheels", "Title", c => c.String());
            AddColumn("dbo.ArtworkFrameForks", "Title", c => c.String());
            DropColumn("dbo.ArtworkBeltGuards", "Color");
            DropColumn("dbo.ArtworkFlywheels", "Color");
            DropColumn("dbo.ArtworkFrameForks", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtworkFrameForks", "Color", c => c.String());
            AddColumn("dbo.ArtworkFlywheels", "Color", c => c.String());
            AddColumn("dbo.ArtworkBeltGuards", "Color", c => c.String());
            DropColumn("dbo.ArtworkFrameForks", "Title");
            DropColumn("dbo.ArtworkFlywheels", "Title");
            DropColumn("dbo.ArtworkBeltGuards", "Title");
        }
    }
}
