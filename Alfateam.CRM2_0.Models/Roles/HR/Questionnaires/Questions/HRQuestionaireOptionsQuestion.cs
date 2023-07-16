using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.Questionnaires.Questions
{
    /// <summary>
    /// Модель вопроса опросника для HR, где нужно выбрать один или несколько вариантов ответа
    /// </summary>
    public class HRQuestionaireOptionsQuestion : HRQuestionaireQuestion
    {
        public string Title { get; set; }
        public bool AllowMultipleAnswers { get; set; }
        public List<HRQuestionaireQuestionOption> Options { get; set; } = new List<HRQuestionaireQuestionOption>();
    }
}
