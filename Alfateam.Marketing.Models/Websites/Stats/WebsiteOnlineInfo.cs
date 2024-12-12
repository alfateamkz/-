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
        public DateTime PingedAt { get; set; } = DateTime.UtcNow;
        public bool IsOnline { get; set; }
        

        public TimeSpan ResponseDuration { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int WebsiteId { get; set; }
    }
}
