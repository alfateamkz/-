using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticMarketingDbContext : DbContext
    {
        public StaticMarketingDbContext()
        {
            Database.EnsureCreated();
        }
        public StaticMarketingDbContext(DbContextOptions<StaticMarketingDbContext> options)
        {
            Database.EnsureCreated();
        }
    }
}
