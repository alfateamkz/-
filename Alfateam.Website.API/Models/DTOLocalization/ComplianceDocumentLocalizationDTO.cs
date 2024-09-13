using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items;

namespace Alfateam.Website.API.Models.DTOLocalization
{
    public class ComplianceDocumentLocalizationDTO : DTOModel<ComplianceDocumentLocalization>
    {

        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        public long KBSize { get; set; }
        public string Title { get; set; }
        public string ImgPreviewPath { get; set; }
        public string DocumentPath { get; set; }


        public override bool IsValid()
        {
            return base.IsValid() && KBSize > 0;
        }
    }
}
