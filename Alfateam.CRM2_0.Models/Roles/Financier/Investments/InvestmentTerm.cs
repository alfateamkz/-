using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Investments
{
    /// <summary>
    /// Сущность доступного фиксированного срока по инвестиции
    /// </summary>
    public class InvestmentTerm : AbsModel
    {
        public string Title { get; set; }
        public int Days { get; set; }
    }
}
