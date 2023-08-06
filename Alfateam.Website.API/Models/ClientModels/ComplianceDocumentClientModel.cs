using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;

namespace Alfateam.Website.API.Models.ClientModels
{
    public class ComplianceDocumentClientModel : ClientModel
    {
        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        public int KBSize { get; set; }
        public string Title { get; set; }
        public string ImgPreviewPath { get; set; }
        public string DocumentPath { get; set; }


        public static ComplianceDocumentClientModel Create(ComplianceDocument item, int? langId)
        {

            var model = new ComplianceDocumentClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.ImgPreviewPath = item.ImgPreviewPath;
            model.DocumentPath = item.DocumentPath;
            model.KBSize = item.KBSize;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.ImgPreviewPath = GetActualValue(model.ImgPreviewPath, localization.ImgPreviewPath);
                    model.DocumentPath = GetActualValue(model.DocumentPath, localization.DocumentPath);
                    model.KBSize = localization.KBSize;
                }
            }

            return model;
        }
        public static List<ComplianceDocumentClientModel> CreateItems(List<ComplianceDocument> items, int? langId)
        {
            var models = new List<ComplianceDocumentClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
