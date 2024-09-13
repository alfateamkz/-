using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Contests
{
    /// <summary>
    /// Модель конкурса в системе геймификации
    /// </summary>
    public class Contest : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }


        public List<ContestPlaces> Places { get; set; } = new List<ContestPlaces>();


        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);



        public ContestResult? Result { get; set; }
        public int? ResultId { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int GamificationModelId { get; set; }
    }
}
