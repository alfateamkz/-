using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticTelephonyDbContext : DbContext
    {
        public StaticTelephonyDbContext()
        {
            Database.EnsureCreated();
        }
        public StaticTelephonyDbContext(DbContextOptions<StaticTelephonyDbContext> options)
        {
            Database.EnsureCreated();
        }
    }
}
