using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Appeals
{
    public class AppealResultClientModel : ClientModel<AppealResult>
    {
        public string Description { get; set; }
        public List<AppealResultActionClientModel> Actions { get; set; } = new List<AppealResultActionClientModel>();
    }
}
