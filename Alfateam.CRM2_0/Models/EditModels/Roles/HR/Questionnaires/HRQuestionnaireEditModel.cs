using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.HR.Questionnaires
{
    public class HRQuestionnaireEditModel : EditModel<HRQuestionnaire>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
}
