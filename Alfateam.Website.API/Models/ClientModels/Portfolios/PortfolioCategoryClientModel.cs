using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.ClientModels.Portfolios
{
    public class PortfolioCategoryClientModel : ClientModel
    {
        protected PortfolioCategoryClientModel() { }

        public string Title { get; set; }

        public static PortfolioCategoryClientModel Create(PortfolioCategory item, int? langId)
        {

            var model = new PortfolioCategoryClientModel();

            model.Id = item.Id;
            model.Title = item.Title;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            return model;
        }
        public static List<PortfolioCategoryClientModel> CreateItems(List<PortfolioCategory> items, int? langId)
        {
            var models = new List<PortfolioCategoryClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
