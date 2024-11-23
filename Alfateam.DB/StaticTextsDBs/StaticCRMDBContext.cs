using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticCRMDBContext : DbContext
    {
        public StaticCRMDBContext()
        {
            Database.EnsureCreated();
        }
        public StaticCRMDBContext(DbContextOptions<StaticCRMDBContext> options) : this()
        {
            Database.EnsureCreated();
        }
    }
}
