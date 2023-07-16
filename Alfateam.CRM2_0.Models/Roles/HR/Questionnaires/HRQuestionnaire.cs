using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.Questionnaires
{
    /// <summary>
    /// Модель опросника для HR
    /// </summary>
    public class HRQuestionnaire : AbsModel
    {

        public string Title { get; set; }
        public string? Description { get; set; }

        public HRQuestionnaireCategory Category { get; set; }

        public List<HRQuestionaireQuestionGroup> QuestionGroups { get; set; } = new List<HRQuestionaireQuestionGroup>();
    }
}
