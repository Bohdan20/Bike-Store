namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomColorToCycle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cycles", "CustomColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cycles", "CustomColor");
        }
    }
}
