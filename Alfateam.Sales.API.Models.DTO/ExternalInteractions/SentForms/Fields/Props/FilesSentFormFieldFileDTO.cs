using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields.Props;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms.Fields.Props
{
    public class FilesSentFormFieldFileDTO : DTOModelAbs<FilesSentFormFieldFile>
    {
        [ForClientOnly]
        public string Filepath { get; set; }
        [ForClientOnly]
        public string Filename { get; set; }
        [ForClientOnly]
        public long BytesSize { get; set; }
    }
}
