using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Funnel
{
    public class SalesFunnelStageType : AbsModel
    {
        public string Title { get; set; }
        public string HexBGColor { get; set; }
        public string HexTitleColor { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
