using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Checking
{
    public class SSCheckingCreateModel : CreateModel<SSChecking>
    {
        public SSCheckingType Type { get; set; } = SSCheckingType.First;
        public int CheckedPersonId { get; set; }


        public SSCheckingDataCreateModel CheckingData { get; set; }


        public override SSChecking Create()
        {
            var checking = base.Create();
            checking.CheckingData = CheckingData.Create();

            return checking;
        }
    }
}
