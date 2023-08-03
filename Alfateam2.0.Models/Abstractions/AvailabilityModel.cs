using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{
    public abstract class AvailabilityModel : AbsModel
    {
        public Availability Availability { get; set; }
    }
}
