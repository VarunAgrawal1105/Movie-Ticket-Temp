namespace _3.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDBv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "MovieId" });
            CreateTable(
                "dbo.Screens",
                c => new
                    {
                        ScreenId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Tickets = c.Int(nullable: false),
                        ShowTime = c.String(),
                    })
                .PrimaryKey(t => t.ScreenId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            AddColumn("dbo.Movies", "ShowDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "NoOfTickets");
            DropTable("dbo.Bookings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Tickets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            AddColumn("dbo.Movies", "NoOfTickets", c => c.Int(nullable: false));
            DropForeignKey("dbo.Screens", "UserId", "dbo.Users");
            DropForeignKey("dbo.Screens", "MovieId", "dbo.Movies");
            DropIndex("dbo.Screens", new[] { "MovieId" });
            DropIndex("dbo.Screens", new[] { "UserId" });
            DropColumn("dbo.Movies", "ShowDate");
            DropTable("dbo.Screens");
            CreateIndex("dbo.Bookings", "MovieId");
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}
