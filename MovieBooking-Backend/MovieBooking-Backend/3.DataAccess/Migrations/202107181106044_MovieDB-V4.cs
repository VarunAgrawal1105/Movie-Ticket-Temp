namespace _3.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDBV4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Screens", "UserId", "dbo.Users");
            DropIndex("dbo.Screens", new[] { "UserId" });
            AddColumn("dbo.Screens", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Screens", "UserId");
            DropColumn("dbo.Movies", "Price");
            DropColumn("dbo.Movies", "ShowDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ShowDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Screens", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Screens", "Price");
            CreateIndex("dbo.Screens", "UserId");
            AddForeignKey("dbo.Screens", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
