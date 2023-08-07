using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items;

namespace Alfateam.Website.API.Models.LocalizationEditModels
{
    public class ComplianceDocumentLocalizationEditModel : LocalizationEditModel<ComplianceDocumentLocalization>
    {

        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        public long KBSize { get; set; }
        public string Title { get; set; }
        public string ImgPreviewPath { get; set; }
        public string DocumentPath { get; set; }


        public override void Fill(ComplianceDocumentLocalization item)
        {
            item.KBSize = KBSize;
            item.Title = Title;
            item.ImgPreviewPath = ImgPreviewPath;
            item.DocumentPath = DocumentPath;
        }

        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= KBSize > 0;
            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ImgPreviewPath);
            isValid &= !string.IsNullOrEmpty(DocumentPath);

            return isValid;
        }
    }
}
