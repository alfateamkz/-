using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO
{
    public class UploadedFileDTO : DTOModelAbsGuid<UploadedFile>
    {
        [ForClientOnly]
        public string? Server { get; set; }

        [ForClientOnly]
        public string RelativePath { get; set; }

        [ForClientOnly]
        public string FullPath => Server + RelativePath;
    }
}
