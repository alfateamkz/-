using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems
{
    public class WebsiteBaseAuthentication : AbsModel
    {
        public bool UseAuth { get; set; }
        
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
