using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDSSigningApp.Models
{
    public class AppSettingsProxy
    {
        public bool UseProxy { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }


        public bool UseProxyAuth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
