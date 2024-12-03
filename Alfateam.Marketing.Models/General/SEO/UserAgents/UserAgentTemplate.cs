using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.General.SEO.UserAgents
{
    public class UserAgentTemplate : AbsModel
    {
        public string Title { get; set; }


        public List<UserAgentTemplate> SubTemplates { get; set; } = new List<UserAgentTemplate>();


        /// <summary>
        /// Родительский UserAgentTemplate
        /// </summary>
        public int? UserAgentTemplateId { get; set; }
    }
}
