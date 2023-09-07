using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Checking
{
    public class SSCheckingResultCreateModel : CreateModel<SSCheckingResult>
    {
        public SSCheckingResultType Type { get; set; }



        public string Decision { get; set; }
        public string Comment { get; set; }
    }
}
