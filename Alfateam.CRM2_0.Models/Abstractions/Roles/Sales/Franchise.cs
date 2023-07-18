using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Franchising;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Sales
{
    /// <summary>
    /// Базовая сущность франшизы
    /// </summary>
    public abstract class Franchise : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public FranchiseStatus Status { get; set; } = FranchiseStatus.Active;
    }
}
