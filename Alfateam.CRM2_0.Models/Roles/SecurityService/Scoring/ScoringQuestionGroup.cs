using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.SecurityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring
{
    /// <summary>
    /// Группа вопросов скоринг модели
    /// </summary>
    public class ScoringQuestionGroup : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public List<ScoringQuestion> Questions { get; set; } = new List<ScoringQuestion>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ScoringModelId { get; set; }
    }
}
