using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseCreateModel : CreateModel<CorruptionCase>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CorruptionCaseInitDetailsCreateModel InitDetails { get; set; }

        public override bool IsValid()
        {
            if(InitDetails == null) return false;

            bool isValid = base.IsValid();
            isValid &= InitDetails.IsValid();

            return isValid;
        }
        public override CorruptionCase Create()
        {
            var item = base.Create();
            item.InitDetails = InitDetails.Create();

            return item;
        }
    }
}
