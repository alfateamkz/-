using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.EditModels.General
{
    public class PenaltyEditModel : EditModel<Penalty>
    {
        public PenaltyType Type { get; set; }
        public bool Value { get; set; }
    }
}
