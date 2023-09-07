using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class PenaltyCreateModel : CreateModel<Penalty>
    {
        public PenaltyType Type { get; set; } = PenaltyType.PercentForTotal;
        public bool Value { get; set; }
    }
}
