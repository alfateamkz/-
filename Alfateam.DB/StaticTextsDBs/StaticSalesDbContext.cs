using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticSalesDbContext : DbContext
    {
        public StaticSalesDbContext()
        {
            Database.EnsureCreated();
        }
        public StaticSalesDbContext(DbContextOptions<StaticSalesDbContext> options)
        {
            Database.EnsureCreated();
        }
    }
}
