using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.StaticTextsDBs
{
    public class StaticMessengerDbContext : DbContext
    {
        public StaticMessengerDbContext()
        {

        }
        public StaticMessengerDbContext(DbContextOptions<StaticMessengerDbContext> options) : this()
        {

        }
    }
}
