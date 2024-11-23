
using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Enums.Statuses;
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
        public string BGHexColor { get; set; }
        public string TextHexColor { get; set; }


        public SalesFunnelStageStatus Status { get; set; }
        public bool IsSystemStage { get; set; }
        public int Order { get; set; }







        /// <summary>
        /// Информация о туннеле продаж, если задана
        /// </summary>
        public SalesFunnelTunnel? Tunnel { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SalesFunnelId { get; set; }

	}
}
