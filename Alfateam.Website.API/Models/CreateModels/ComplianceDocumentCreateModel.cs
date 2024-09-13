using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;

namespace Alfateam.Website.API.Models.CreateModels
{
    public class ComplianceDocumentCreateModel : CreateModel<ComplianceDocument>
    {

        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        public long KBSize { get; set; }
        public string Title { get; set; }
        public string ImgPreviewPath { get; set; }
        public string DocumentPath { get; set; }
        

        public int MainLanguageId { get; set; }
    }
}
