namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeArtworksEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtworkBeltGuards", "Sourcing", c => c.String());
            AddColumn("dbo.ArtworkBeltGuards", "SKU", c => c.String());
            AddColumn("dbo.ArtworkBeltGuards", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.ArtworkBeltGuards", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.ArtworkFlywheels", "Sourcing", c => c.String());
            AddColumn("dbo.ArtworkFlywheels", "SKU", c => c.String());
            AddColumn("dbo.ArtworkFlywheels", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.ArtworkFlywheels", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.ArtworkFrameForks", "Sourcing", c => c.String());
            AddColumn("dbo.ArtworkFrameForks", "SKU", c => c.String());
            AddColumn("dbo.ArtworkFrameForks", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.ArtworkFrameForks", "DefaultSC3", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintColors", "Sourcing", c => c.String());
            AddColumn("dbo.PaintColors", "SKU", c => c.String());
            AddColumn("dbo.PaintColors", "DefaultSC2", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaintColors", "DefaultSC3", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaintColors", "DefaultSC3");
            DropColumn("dbo.PaintColors", "DefaultSC2");
            DropColumn("dbo.PaintColors", "SKU");
            DropColumn("dbo.PaintColors", "Sourcing");
            DropColumn("dbo.ArtworkFrameForks", "DefaultSC3");
            DropColumn("dbo.ArtworkFrameForks", "DefaultSC2");
            DropColumn("dbo.ArtworkFrameForks", "SKU");
            DropColumn("dbo.ArtworkFrameForks", "Sourcing");
            DropColumn("dbo.ArtworkFlywheels", "DefaultSC3");
            DropColumn("dbo.ArtworkFlywheels", "DefaultSC2");
            DropColumn("dbo.ArtworkFlywheels", "SKU");
            DropColumn("dbo.ArtworkFlywheels", "Sourcing");
            DropColumn("dbo.ArtworkBeltGuards", "DefaultSC3");
            DropColumn("dbo.ArtworkBeltGuards", "DefaultSC2");
            DropColumn("dbo.ArtworkBeltGuards", "SKU");
            DropColumn("dbo.ArtworkBeltGuards", "Sourcing");
        }
    }
}
