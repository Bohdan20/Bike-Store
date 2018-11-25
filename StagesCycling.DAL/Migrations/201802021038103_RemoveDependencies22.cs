namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDependencies22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cycles", "ArtworkBeltGuardId", "dbo.ArtworkBeltGuards");
            DropForeignKey("dbo.Cycles", "ArtworkFlywheelId", "dbo.ArtworkFlywheels");
            DropForeignKey("dbo.Cycles", "ArtworkFrameForkId", "dbo.ArtworkFrameForks");
            DropForeignKey("dbo.Cycles", "PowerMeterTypeId", "dbo.PowerMeterTypes");
            DropForeignKey("dbo.Cycles", "HandlebarTypeId", "dbo.HandlebarTypes");
            DropForeignKey("dbo.Cycles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Cycles", "PaintColorId", "dbo.PaintColors");
            DropForeignKey("dbo.Cycles", "PlasticsColorTypeId", "dbo.PlasticsColorTypes");
            DropForeignKey("dbo.Cycles", "SprintShiftTypeId", "dbo.SprintShiftTypes");
            DropIndex("dbo.Cycles", new[] { "ModelId" });
            DropIndex("dbo.Cycles", new[] { "HandlebarTypeId" });
            DropIndex("dbo.Cycles", new[] { "PlasticsColorTypeId" });
            DropIndex("dbo.Cycles", new[] { "SprintShiftTypeId" });
            DropIndex("dbo.Cycles", new[] { "PowerMeterTypeId" });
            DropIndex("dbo.Cycles", new[] { "ArtworkBeltGuardId" });
            DropIndex("dbo.Cycles", new[] { "ArtworkFlywheelId" });
            DropIndex("dbo.Cycles", new[] { "ArtworkFrameForkId" });
            DropIndex("dbo.Cycles", new[] { "PaintColorId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Cycles", "PaintColorId");
            CreateIndex("dbo.Cycles", "ArtworkFrameForkId");
            CreateIndex("dbo.Cycles", "ArtworkFlywheelId");
            CreateIndex("dbo.Cycles", "ArtworkBeltGuardId");
            CreateIndex("dbo.Cycles", "PowerMeterTypeId");
            CreateIndex("dbo.Cycles", "SprintShiftTypeId");
            CreateIndex("dbo.Cycles", "PlasticsColorTypeId");
            CreateIndex("dbo.Cycles", "HandlebarTypeId");
            CreateIndex("dbo.Cycles", "ModelId");
            AddForeignKey("dbo.Cycles", "SprintShiftTypeId", "dbo.SprintShiftTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "PlasticsColorTypeId", "dbo.PlasticsColorTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "PaintColorId", "dbo.PaintColors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "HandlebarTypeId", "dbo.HandlebarTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "PowerMeterTypeId", "dbo.PowerMeterTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "ArtworkFrameForkId", "dbo.ArtworkFrameForks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "ArtworkFlywheelId", "dbo.ArtworkFlywheels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "ArtworkBeltGuardId", "dbo.ArtworkBeltGuards", "Id", cascadeDelete: true);
        }
    }
}
