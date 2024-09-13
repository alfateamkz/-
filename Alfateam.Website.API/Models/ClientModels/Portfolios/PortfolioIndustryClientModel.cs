using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Posts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Portfolios
{
    public class PortfolioIndustryClientModel : ClientModel
    {
        protected PortfolioIndustryClientModel() { }

        public string Title { get; set; }



        public string Slug => SlugHelper.GetLatynSlug(Title);

        public static PortfolioIndustryClientModel Create(PortfolioIndustry item, int? langId)
        {

            var model = new PortfolioIndustryClientModel();

            model.Id = item.Id;
            model.Title = item.Title;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            return model;
        }
        public static List<PortfolioIndustryClientModel> CreateItems(IEnumerable<PortfolioIndustry> items, int? langId)
        {
            var models = new List<PortfolioIndustryClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
