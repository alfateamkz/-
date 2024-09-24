using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Feedback
{
    /// <summary>
    /// Сущность заявки с формы
    /// </summary>
    public class OrderRequest : AbsModel
    {
        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public string Description { get; set; }
        public string Contacts { get; set; }



        public double Budget { get; set; }
        public Currency BudgetCurrency { get; set; }
    }
}
