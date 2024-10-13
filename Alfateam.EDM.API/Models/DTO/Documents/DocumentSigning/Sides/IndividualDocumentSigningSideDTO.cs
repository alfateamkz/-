using Alfateam.EDM.Models.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Sides
{
    public class IndividualDocumentSigningSideDTO : DocumentSigningSide
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }

        public DateTime Birthdate { get; set; }


        public string CountryCode { get; set; }

        /// <summary>
        /// ИНН (в РФ), БИН\ИИН (в КЗ), в других странах может быть другое
        /// </summary>
        public string BusinessNumber { get; set; }

        /// <summary>
        /// Паспортные данные или что-то в этом духе
        /// </summary>
        public string IdentificationDocumentData { get; set; }
    }
}
