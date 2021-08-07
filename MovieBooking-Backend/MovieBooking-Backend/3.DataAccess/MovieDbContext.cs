using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DataAccess
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext():base("MovieBooking")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieDbContext, _3.DataAccess.Migrations.Configuration>());
        }


        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieScreen> MovieScreen { get; set; }
        //public DbSet<Booking> Booking { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
