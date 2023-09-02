using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Helpers
{
    internal static class ConnectionStrings
    {
        public static string Website { get; set; } = "server=localhost;" +
                                                     "user=root;" +
                                                     "password=H2c7V7p6;" +
                                                     "port=3306;" +
                                                     "database=alfateam_co;";

        public static string CRM { get; set; } = "server=localhost;" +
                                                 "user=root;" +
                                                 "password=H2c7V7p6;" +
                                                 "port=3306;" +
                                                 "database=alfateam_co_crm;";
    }
}
