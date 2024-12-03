using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.SalesGenerators.Items
{
    public class SGCreateOrderFromOldOrder : AbsModel
    {
        public bool Create { get; set; }
        public int SetDaysAgo { get; set; }
    }
}
