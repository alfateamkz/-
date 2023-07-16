using Alfateam.CRM2_0.Models.Abstractions.Roles.SecurityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring.Questions
{
    /// <summary>
    /// Модель вопроса скоринга, на который есть несколько вариантов ответовы
    /// </summary>
    public class ScoringOptionsQuestion : ScoringQuestion
    {
        public List<ScoringQuestionOption> Options { get; set; } = new List<ScoringQuestionOption>();
    }
}
