using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring
{
    /// <summary>
    /// Модель группы ответов результата скоринга
    /// </summary>
    public class SSCheckingScoringResultQGroup : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; } 


        public List<SSCheckingScoringResultQuestion> Questions { get; set; } = new List<SSCheckingScoringResultQuestion>();
    }
}
