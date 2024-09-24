using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.DTO
{
    public class ComplianceDocumentDTO : AvailabilityDTOModel<ComplianceDocument>
    {
        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        [ForClientOnly]
        public long KBSize { get; set; }


        public string Title { get; set; }


        [ForClientOnly]
        public string ImgPreviewPath { get; set; }
        [ForClientOnly]
        public string DocumentPath { get; set; }


        public int MainLanguageId { get; set; }
    }
}
