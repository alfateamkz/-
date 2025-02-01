using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDSSigningApp.Models
{
    public class AppSettings : BindableObject
    {
        public AppSettingsProxy ProxySettings { get; set; }
    }
}
