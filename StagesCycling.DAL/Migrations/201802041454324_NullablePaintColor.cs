namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullablePaintColor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cycles", "PaintColorId", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cycles", "PaintColorId", c => c.Long(nullable: false));
        }
    }
}
