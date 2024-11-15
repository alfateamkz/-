using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;
using Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms.Fields.Props;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields.Props;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms.Fields
{
    public class FilesSentFormFieldDTO : SentWebsiteFormFieldDTO
    {
        public List<FilesSentFormFieldFileDTO> Files { get; set; } = new List<FilesSentFormFieldFileDTO>();
    }
}
