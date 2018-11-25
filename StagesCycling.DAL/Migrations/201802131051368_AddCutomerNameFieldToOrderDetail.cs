namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCutomerNameFieldToOrderDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "CustomerName");
        }
    }
}
