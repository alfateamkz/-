using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.Inputs
{
    public class FileWebsiteFormInputDTO : WebsiteFormInputDTO
    {
        public int MaxFilesCount { get; set; }
        public string AllowedExtensions { get; set; }
    }
}
