using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Plan.Types.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Plan.Types
{
    public class ByFunnelsSalesPlan : SalesPlan
    {
        public List<ByFunnelsSalesPlanFunnel> Funnels { get; set; } = new List<ByFunnelsSalesPlanFunnel>();

        public override bool CompliesWithOtherPlan(SalesPlan other)
        {
            if (!base.CompliesWithOtherPlan(other)) return false;

            var thisFunnels = Funnels.Where(o => !o.Funnel.IsDeleted && !o.IsDeleted);
            var otherFunnels = (other as ByFunnelsSalesPlan).Funnels.Where(o => !o.Funnel.IsDeleted && !o.IsDeleted);


            if (thisFunnels.Count() != otherFunnels.Count()) return false;
            foreach(var funnel in thisFunnels)
            {
                if(!otherFunnels.Any(o => o.FunnelId == funnel.FunnelId))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
