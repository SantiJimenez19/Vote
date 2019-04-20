

namespace Vote.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Vote.Web.Data.Entities;

    public class DataContext : IdentityDbContext<User>

    {
        public DbSet<Event> Events { get; set; }

        public DbSet<Country> Countries { get; set; }
        /*   public DbSet<Country>Countries{ get; set; }

           public DbSet<City> Cities { get; set; }

           public DbSet<User> Users { get; set; }

           public DbSet<Vote> Votes { get; set; }*/

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
