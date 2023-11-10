using Microsoft.EntityFrameworkCore;
using ModelAPP.Master;

namespace MasterAPI.Models
{
    public class MasterContext : MasterDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.GetConnectionString("DefaultConnection"));
        }
    }
}
