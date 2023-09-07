using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Checking
{
    public class SSCheckingRequestResultCreateModel : CreateModel<SSCheckingRequestResult>
    {
        public SSCheckingRequestResultType Type { get; set; }
        public string? Comment { get; set; }
    }
}
