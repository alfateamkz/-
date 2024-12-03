using Alfateam.Core;
using Alfateam.Marketing.Models.General.SEO.UserAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems
{
    public class UserAgentSettings : AbsModel
    {

        public UserAgentCategory Category { get; set; }
        public int CategoryId { get; set; }


        public UserAgentTemplate Template { get; set; }
        public int TemplateId { get; set; }



        public string HTTPUserAgent { get; set; }
        public string RobotsUserAgent { get; set; }


        public bool IsDefault { get; set; }
    }
}
