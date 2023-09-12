using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Appeals
{
    public class AppealActionCreateModel : CreateModel<AppealAction>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
