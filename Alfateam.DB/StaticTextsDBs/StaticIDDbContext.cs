using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticIDDbContext : DbContext
    {
        public StaticIDDbContext()
        {
            Database.EnsureCreated();
        }
        public StaticIDDbContext(DbContextOptions<StaticIDDbContext> options) : this()
        {
            Database.EnsureCreated();
        }
    }
}
