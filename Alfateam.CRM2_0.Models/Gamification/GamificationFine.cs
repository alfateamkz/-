using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification
{
    /// <summary>
    /// Сущность штрафа в системе геймификации
    /// </summary>
    public class GamificationFine : AbsModel
    {
        public string Title { get; set; }
        public string Reason { get; set; }

        public User FinedUser { get; set; }

        public double Rating { get; set; }
        public double Coin { get; set; }
    }
}
