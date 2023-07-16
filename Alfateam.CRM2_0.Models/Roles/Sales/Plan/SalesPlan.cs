using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Plan
{
    /// <summary>
    /// Модель плана продаж
    /// </summary>
    public class SalesPlan : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public List<SalesPlanItem> Items { get; set; } = new List<SalesPlanItem>();
    }
}
