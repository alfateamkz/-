using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption.Participants
{
    public class InfoCorruptionCaseParticipantClientModel : CorruptionCaseParticipantClientModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public CountryClientModel Country { get; set; }
    }
}
