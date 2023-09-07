using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Checking
{
    public class SSCheckingDataCreateModel : CreateModel<SSCheckingData>
    {
        public string Data { get; set; }
    }
}
