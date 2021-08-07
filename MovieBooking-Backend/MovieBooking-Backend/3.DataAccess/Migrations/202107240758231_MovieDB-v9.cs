namespace _3.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDBv9 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Screens", newName: "MovieScreens");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MovieScreens", newName: "Screens");
        }
    }
}
