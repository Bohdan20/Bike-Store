namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableFlyweel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cycles", "ArtworkFlywheelId", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cycles", "ArtworkFlywheelId", c => c.Long(nullable: false));
        }
    }
}
