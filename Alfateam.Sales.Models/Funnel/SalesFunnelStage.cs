
using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Funnel
{
    /// <summary>
    /// Модель этапа воронки продаж
    /// </summary>
    public class SalesFunnelStage : AbsModel
    {

        public string Title { get; set; }
        public string? Description { get; set; }


        public SalesFunnelStageType Type { get; set; }
        public int TypeId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SalesFunnelId { get; set; }

	}
}
