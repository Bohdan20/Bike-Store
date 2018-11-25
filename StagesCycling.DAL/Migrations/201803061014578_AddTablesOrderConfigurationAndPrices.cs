namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesOrderConfigurationAndPrices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                           "dbo.BasePrices",
                           c => new
                           {
                               Id = c.Long(nullable: false, identity: true),
                               Type = c.String(),
                               Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                           })
                           .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderConfigurations",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    MinBikeQuantity = c.Int(nullable: false),
                    MaxDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    MyProperty = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.ArtworkBeltGuards", "BasePriceId", c => c.Long(nullable: false));
            AddColumn("dbo.ArtworkFlywheels", "BasePriceId", c => c.Long(nullable: false));
            AddColumn("dbo.ArtworkFrameForks", "BasePriceId", c => c.Long(nullable: false));
            AddColumn("dbo.PaintColors", "BasePriceId", c => c.Long(nullable: false));
            CreateIndex("dbo.ArtworkBeltGuards", "BasePriceId");
            CreateIndex("dbo.ArtworkFlywheels", "BasePriceId");
            CreateIndex("dbo.ArtworkFrameForks", "BasePriceId");
            CreateIndex("dbo.PaintColors", "BasePriceId");
            AddForeignKey("dbo.ArtworkBeltGuards", "BasePriceId", "dbo.BasePrices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArtworkFlywheels", "BasePriceId", "dbo.BasePrices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArtworkFrameForks", "BasePriceId", "dbo.BasePrices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaintColors", "BasePriceId", "dbo.BasePrices", "Id", cascadeDelete: true);
            DropColumn("dbo.ArtworkBeltGuards", "BasePrice");
            DropColumn("dbo.ArtworkFlywheels", "BasePrice");
            DropColumn("dbo.ArtworkFrameForks", "BasePrice");
            DropColumn("dbo.PaintColors", "BasePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaintColors", "BasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ArtworkFrameForks", "BasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ArtworkFlywheels", "BasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ArtworkBeltGuards", "BasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.PaintColors", "BasePriceId", "dbo.BasePrices");
            DropForeignKey("dbo.ArtworkFrameForks", "BasePriceId", "dbo.BasePrices");
            DropForeignKey("dbo.ArtworkFlywheels", "BasePriceId", "dbo.BasePrices");
            DropForeignKey("dbo.ArtworkBeltGuards", "BasePriceId", "dbo.BasePrices");
            DropIndex("dbo.PaintColors", new[] { "BasePriceId" });
            DropIndex("dbo.ArtworkFrameForks", new[] { "BasePriceId" });
            DropIndex("dbo.ArtworkFlywheels", new[] { "BasePriceId" });
            DropIndex("dbo.ArtworkBeltGuards", new[] { "BasePriceId" });
            DropColumn("dbo.PaintColors", "BasePriceId");
            DropColumn("dbo.ArtworkFrameForks", "BasePriceId");
            DropColumn("dbo.ArtworkFlywheels", "BasePriceId");
            DropColumn("dbo.ArtworkBeltGuards", "BasePriceId");
            DropTable("dbo.OrderConfigurations");
            DropTable("dbo.BasePrices");
        }
    }
}
