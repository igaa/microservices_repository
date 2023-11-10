using Microsoft.EntityFrameworkCore;
using Web.Model.APP.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAPP.Master
{
    public class MasterDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
