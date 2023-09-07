using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.SecurityService.Checking
{
    public class SSCheckingDataEditModel : EditModel<SSCheckingData>
    {
        public string Data { get; set; }
    }
}
