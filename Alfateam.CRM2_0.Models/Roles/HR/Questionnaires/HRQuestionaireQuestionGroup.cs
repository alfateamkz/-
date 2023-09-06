using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.Questionnaires
{
    /// <summary>
    /// Модель группы вопросов опросника для HR
    /// </summary>
    public class HRQuestionaireQuestionGroup : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public List<HRQuestionaireQuestion> Questions { get; set; } = new List<HRQuestionaireQuestion>();

        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int HRQuestionnaireId { get; set; }
    }
}
