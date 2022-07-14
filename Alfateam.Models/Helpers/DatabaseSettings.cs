using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Helpers
{
    public static class DatabaseSettings
    {
        public static string ConnectionString { get; set; } = "server=localhost;" +
                       "user=root;" +
                       "password=H2c7V7p6;" +
                       "port=3306;" +
                       "database=alfateam;";
    }
}
