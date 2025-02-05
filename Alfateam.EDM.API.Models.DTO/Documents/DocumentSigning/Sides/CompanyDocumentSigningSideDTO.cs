using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Sides
{
    public class CompanyDocumentSigningSideDTO : DocumentSigningSideDTO
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        public string BusinessNumber { get; set; }
    }
}
