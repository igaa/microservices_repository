using Microsoft.EntityFrameworkCore;
using Web.Model.APP.Blogging;

namespace BlogingAPI
{
    public class BlogingContext : BloggingDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.GetConnectionString("DefaultConnection"));
        }
    }
}
