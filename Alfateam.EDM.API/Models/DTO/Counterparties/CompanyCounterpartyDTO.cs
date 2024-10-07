using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Counterparties
{
    public class CompanyCounterpartyDTO : CounterpartyDTO
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        public string CountryCode { get; set; }

        /// <summary>
        /// ИНН (в РФ), БИН\ИИН (в КЗ), в других странах может быть другое
        /// </summary>
        public string BusinessNumber { get; set; }
    }
}
