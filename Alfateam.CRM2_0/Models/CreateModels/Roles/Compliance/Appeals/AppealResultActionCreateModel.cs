using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Appeals
{
    public class AppealResultActionCreateModel : CreateModel<AppealResultAction>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public DateTime Deadline { get; set; }
        public DateTime? PerformedAt { get; set; }
        public AppealResultActionStatus Status { get; set; }
    }
}
