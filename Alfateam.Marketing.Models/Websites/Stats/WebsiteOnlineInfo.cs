using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.Stats
{
    public class WebsiteOnlineInfo : AbsModel
    {
        public DateTime PingedAt { get; set; }
        public bool IsOnline { get; set; }
        

        public TimeSpan ResponseDuration { get; set; }
    }
}
