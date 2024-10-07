using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General.Subjects
{
    public class IndividualDTO : EDMSubjectDTO
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }

        public DateTime Birthdate { get; set; }


        /// <summary>
        /// Паспортные данные или что-то в этом духе
        /// </summary>
        public string IdentificationDocumentData { get; set; }


        public bool IsSelfEmployed { get; set; }
    }
}
