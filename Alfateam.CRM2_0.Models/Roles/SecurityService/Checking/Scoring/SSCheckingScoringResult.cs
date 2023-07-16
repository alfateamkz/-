using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring
{
    /// <summary>
    /// Модель результата скоринга
    /// </summary>
    public class SSCheckingScoringResult : AbsModel
    {
        public ScoringModel ScoringModel { get; set; }
        public List<SSCheckingScoringResultQGroup> QuestionGroups { get; set; } = new List<SSCheckingScoringResultQGroup>();
    }
}
