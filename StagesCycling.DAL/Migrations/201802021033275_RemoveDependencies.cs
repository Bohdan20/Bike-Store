namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDependencies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cycles", "HandlebarTypeId", "dbo.HandlebarTypes");
            DropForeignKey("dbo.Cycles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Cycles", "PaintColorId", "dbo.PaintColors");
            DropForeignKey("dbo.Cycles", "PlasticsColorTypeId", "dbo.PlasticsColorTypes");
            DropForeignKey("dbo.Cycles", "SprintShiftTypeId", "dbo.SprintShiftTypes");
            AddForeignKey("dbo.Cycles", "HandlebarTypeId", "dbo.HandlebarTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "PaintColorId", "dbo.PaintColors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "PlasticsColorTypeId", "dbo.PlasticsColorTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "SprintShiftTypeId", "dbo.SprintShiftTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cycles", "SprintShiftTypeId", "dbo.SprintShiftTypes");
            DropForeignKey("dbo.Cycles", "PlasticsColorTypeId", "dbo.PlasticsColorTypes");
            DropForeignKey("dbo.Cycles", "PaintColorId", "dbo.PaintColors");
            DropForeignKey("dbo.Cycles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Cycles", "HandlebarTypeId", "dbo.HandlebarTypes");
            AddForeignKey("dbo.Cycles", "SprintShiftTypeId", "dbo.SprintShiftTypes", "Id");
            AddForeignKey("dbo.Cycles", "PlasticsColorTypeId", "dbo.PlasticsColorTypes", "Id");
            AddForeignKey("dbo.Cycles", "PaintColorId", "dbo.PaintColors", "Id");
            AddForeignKey("dbo.Cycles", "ModelId", "dbo.Models", "Id");
            AddForeignKey("dbo.Cycles", "HandlebarTypeId", "dbo.HandlebarTypes", "Id");
        }
    }
}
