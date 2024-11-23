using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticCertCenterDbContext : DbContext
    {
        public StaticCertCenterDbContext()
        {
            Database.EnsureCreated();
        }
        public StaticCertCenterDbContext(DbContextOptions<StaticCertCenterDbContext> options) : this()
        {
            Database.EnsureCreated();
        }
    }
}
