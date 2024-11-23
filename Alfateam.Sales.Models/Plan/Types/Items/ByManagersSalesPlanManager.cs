using Alfateam.Core;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Plan.Types.Items
{
    public class ByManagersSalesPlanManager : AbsModel
    {
        public User Manager { get; set; }
        public int ManagerId { get; set; }


        public double Value { get; set; }
    }
}
