using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Helpers
{
    internal static class ConnectionStrings
    {

        internal static string BuildConnectionString(string dbName)
        {
#if DEBUG
            return $"server=localhost;user=root;password=H2c7V7p6;port=3306;database={dbName};";
#else
            return $"server=localhost;user=usp;password=ErPvm!3;port=3306;database={dbName};";
#endif
        }


        public static string Administration => BuildConnectionString("alfateam_administration");
        public static string EDM => BuildConnectionString("alfateam_edm");
        public static string AlfateamID => BuildConnectionString("alfateam_id");
        public static string CRM => BuildConnectionString("alfateam_co_crm");
        public static string Website => BuildConnectionString("alfateam_co");
        public static string Messenger => BuildConnectionString("alfateam_messenger");
        public static string CertCenter => BuildConnectionString("alfateam_certCenter");

    }
}
