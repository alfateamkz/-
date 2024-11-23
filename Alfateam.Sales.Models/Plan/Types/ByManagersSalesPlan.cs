using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Plan.Types.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Plan.Types
{
    public class ByManagersSalesPlan : SalesPlan
    {
        public List<ByManagersSalesPlanManager> Managers { get; set; } = new List<ByManagersSalesPlanManager>();


        public override bool CompliesWithOtherPlan(SalesPlan other)
        {
            if (!base.CompliesWithOtherPlan(other)) return false;

            var thisManagers = Managers.Where(o => !o.Manager.IsDeleted && !o.IsDeleted);
            var otherManagers = (other as ByManagersSalesPlan).Managers.Where(o => !o.Manager.IsDeleted && !o.IsDeleted);


            if (thisManagers.Count() != otherManagers.Count()) return false;
            foreach (var funnel in thisManagers)
            {
                if (!otherManagers.Any(o => o.ManagerId == funnel.ManagerId))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
