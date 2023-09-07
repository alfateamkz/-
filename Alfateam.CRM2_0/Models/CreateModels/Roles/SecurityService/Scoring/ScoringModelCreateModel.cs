using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Scoring
{
    public class ScoringModelCreateModel : CreateModel<ScoringModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public int CategoryId { get; set; }
    }
}
