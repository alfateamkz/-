using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral.Items
{
    public class MultiLevelReferralProgramLevel : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public double Percent { get; set; }
        public double Treshold { get; set; }

    }
}
