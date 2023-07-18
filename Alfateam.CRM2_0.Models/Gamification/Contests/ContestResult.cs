using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Contests
{
    /// <summary>
    /// Сущность результата проведения конкурса
    /// </summary>
    public class ContestResult : AbsModel
    {
        public string Comment { get; set; }
        public List<ContestWinner> Winners { get; set; } = new List<ContestWinner>();
    }
}
