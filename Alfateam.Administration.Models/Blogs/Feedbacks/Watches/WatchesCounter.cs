using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Watches
{
    public class WatchesCounter : AbsModel
    {
        public int Counter { get; set; }
        public List<Watch> Watches { get; set; } = new List<Watch>();


        public void AddWatch(Watch watch)
        {
            Watches.Add(watch);
            Counter++;
        }
    }
}
