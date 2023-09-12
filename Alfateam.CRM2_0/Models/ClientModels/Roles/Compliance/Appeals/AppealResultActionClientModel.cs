using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Appeals
{
    public class AppealResultActionClientModel : ClientModel<AppealResultAction>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public DateTime Deadline { get; set; }
        public DateTime? PerformedAt { get; set; }
        public AppealResultActionStatus Status { get; set; }
    }
}
