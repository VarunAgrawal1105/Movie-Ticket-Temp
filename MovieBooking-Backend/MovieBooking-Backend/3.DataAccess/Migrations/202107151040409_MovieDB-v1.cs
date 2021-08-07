namespace _3.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDBv1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        MovieName = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        NoOfTickets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Contact = c.Int(nullable: false),
                        Gender = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "MovieId", "dbo.Movies");
            DropIndex("dbo.Bookings", new[] { "MovieId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Movies");
            DropTable("dbo.Bookings");
        }
    }
}
