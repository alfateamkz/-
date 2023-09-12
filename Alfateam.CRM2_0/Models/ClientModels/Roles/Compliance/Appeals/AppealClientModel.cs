using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Appeals
{
    public class AppealClientModel : ClientModel<Appeal>
    {
        public AppealSource Source { get; set; }

        /// <summary>
        /// От кого поступило обращение
        /// Если From == null, то обращение анонимное
        /// </summary>
        public UserClientModel? From { get; set; }



        public AppealStatus Status { get; set; }
        public string? StatusComment { get; set; }
        public List<AppealActionClientModel> Actions { get; set; } = new List<AppealActionClientModel>();


        public AppealResultClientModel? Result { get; set; }
    }
}
