using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Appeals
{
    public class AppealActionClientModel : ClientModel<AppealAction>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
