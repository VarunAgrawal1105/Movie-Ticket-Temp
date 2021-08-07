namespace _3.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDBv5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Screens", "ShowTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Screens", "ShowTime", c => c.String());
        }
    }
}
