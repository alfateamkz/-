using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Appeals
{
    public class AppealResultCreateModel : CreateModel<AppealResult>
    {
        public string Description { get; set; }
    }
}
