using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption.Participants
{
    public class InfoCorruptionCaseParticipantCreateModel : CorruptionCaseParticipantCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public int CountryId { get; set; }
    }
}
