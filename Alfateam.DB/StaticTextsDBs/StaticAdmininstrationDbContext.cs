using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticAdmininstrationDbContext : DbContext
    {
        public StaticAdmininstrationDbContext()
        {

        }
        public StaticAdmininstrationDbContext(DbContextOptions<StaticAdmininstrationDbContext> options) : this()
        {

        }
    }
}
