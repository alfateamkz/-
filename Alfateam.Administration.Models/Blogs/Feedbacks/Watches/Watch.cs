using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Watches
{
    public class Watch : AbsModel
    {
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string Fingerprint { get; set; }
        public string? WatchedUserId { get; set; }



        public string? AdditionalInfo { get; set; }
    }
}
