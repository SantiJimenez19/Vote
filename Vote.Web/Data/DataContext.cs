

using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Vote.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using Vote.Web.Data.Entities;

    public class DataContext : DbContext
    {
        public DbSet<Users> User { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
