using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Contests
{
    /// <summary>
    /// Сущность победителя в конкурсе
    /// </summary>
    public class ContestWinner : AbsModel
    {
        public User User { get; set; }
        public int Place { get; set; }
        public ContestPrize Prize { get; set; }
    }
}
