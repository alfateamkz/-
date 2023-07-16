using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Funnel
{
    /// <summary>
    /// Модель этапа воронки продаж
    /// </summary>
    public class SalesFunnelStage : AbsModel
    {

        public string Title { get; set; }
        public string? Description { get; set; }

        public SalesFunnelStageType Type { get; set; } = SalesFunnelStageType.Awareness;
    }
}
