using Alfateam.Core;
using Alfateam.Marketing.Models.Websites.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites
{
    public class Website : AbsModel
    {
        public string URL { get; set; }
        public string? Title { get; set; }


        public WebsiteGroup Group { get; set; }
        public int GroupId { get; set; }


        public List<WebsiteOnlineInfo> OnlineInfo { get; set; } = new List<WebsiteOnlineInfo>();
    }
}
