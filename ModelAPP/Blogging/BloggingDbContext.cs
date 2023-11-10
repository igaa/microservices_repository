using Microsoft.EntityFrameworkCore;

namespace Web.Model.APP.Blogging
{
    public class BloggingDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
