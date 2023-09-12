using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Corruption.Participants
{
    public class InfoCorruptionCaseParticipantEditModel : CorruptionCaseParticipantEditModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public int CountryId { get; set; }
    }
}
