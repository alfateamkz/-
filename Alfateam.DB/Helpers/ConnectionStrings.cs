using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Helpers
{
    internal static class ConnectionStrings
    {



#if DEBUG

        public static string EDM { get; set; } = "server=localhost;" +
                                                     "user=root;" +
                                                     "password=H2c7V7p6;" +
                                                     "port=3306;" +
                                                     "database=alfateam_edm;";
        public static string AlfateamID { get; set; } = "server=localhost;" +
                                                        "user=root;" +
                                                        "password=H2c7V7p6;" +
                                                        "port=3306;" +
                                                        "database=alfateam_id;";
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
#else

      public static string EDM { get; set; } = "server=localhost;" +
                                                        "user=usp;" +
                                                        "password=ErPvm!3;" +
                                                        "port=3306;" +
                                                        "database=alfateam_edm;";

        public static string AlfateamID { get; set; } = "server=localhost;" +
                                                        "user=usp;" +
                                                        "password=ErPvm!3;" +
                                                        "port=3306;" +
                                                        "database=alfateam_id;";

        public static string Website { get; set; } = "server=localhost;" +
                                                    "user=usp;" +
                                                    "password=ErPvm!3;" +
                                                    "port=3306;" +
                                                    "database=alfateam_co;";


         public static string CRM { get; set; } = "server=localhost;" +
                                                 "user=usp;" +
                                                 "password=ErPvm!3;" +
                                                 "port=3306;" +
                                                 "database=alfateam_co_crm;";
#endif
    }
}
