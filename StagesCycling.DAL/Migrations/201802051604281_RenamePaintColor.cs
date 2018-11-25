namespace StagesCycling.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamePaintColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaintColors", "Title", c => c.String());
            DropColumn("dbo.PaintColors", "RALCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaintColors", "RALCode", c => c.String());
            DropColumn("dbo.PaintColors", "Title");
        }
    }
}
