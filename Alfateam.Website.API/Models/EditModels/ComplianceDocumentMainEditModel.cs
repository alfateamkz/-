using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;

namespace Alfateam.Website.API.Models.EditModels
{
    public class ComplianceDocumentMainEditModel : EditModel<ComplianceDocument>
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

        public override void Fill(ComplianceDocument item)
        {
           
            item.KBSize = KBSize;
            item.Title = Title;
            item.ImgPreviewPath = ImgPreviewPath;
            item.DocumentPath = DocumentPath;

            item.MainLanguageId = MainLanguageId;
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
