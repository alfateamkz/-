using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;
using Alfateam2._0.Models.ContentItems;

namespace Alfateam.Website.API.Models.ClientModels
{
    public class PartnerClientModel : ClientModel
    {
        public string Title { get; set; }
        public string LogoPath { get; set; }

        public Content Content { get; set; }


        public static PartnerClientModel Create(Partner item, int? langId)
        {

            var model = new PartnerClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.LogoPath = item.LogoPath;
            model.Content = item.Content;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.Content = GetActualValue(model.Content, localization.Content);
                }
            }

            return model;
        }
        public static List<PartnerClientModel> CreateItems(IEnumerable<Partner> items, int? langId)
        {
            var models = new List<PartnerClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
