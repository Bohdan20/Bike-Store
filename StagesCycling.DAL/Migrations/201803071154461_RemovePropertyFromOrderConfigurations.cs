namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePropertyFromOrderConfigurations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderConfigurations", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderConfigurations", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
