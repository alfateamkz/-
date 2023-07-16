using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring
{
    /// <summary>
    /// Скоринговая модель
    /// </summary>
    public class ScoringModel : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; } 
        public List<ScoringQuestionGroup> QuestionGroups { get; set; } = new List<ScoringQuestionGroup>();
    }
}
