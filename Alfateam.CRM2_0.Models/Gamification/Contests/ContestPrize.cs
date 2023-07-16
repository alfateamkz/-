using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Contests
{
    /// <summary>
    /// Модель приза в конкурсе в системе геймификации
    /// </summary>
    public class ContestPrize : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }


        public double Rating { get; set; }
    }
}
