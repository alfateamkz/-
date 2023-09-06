using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Questionnaires
{
    public class HRQuestionnaireClientModel : ClientModel<HRQuestionnaire>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public HRQuestionnaireCategoryClientModel Category { get; set; }
    }
}
