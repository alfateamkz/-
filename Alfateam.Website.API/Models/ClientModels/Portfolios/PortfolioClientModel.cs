using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Portfolios;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Portfolios
{
    public class PortfolioClientModel : ClientModel
    {

        protected PortfolioClientModel() { }

        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }



        public string Slug => SlugHelper.GetLatynSlug(Title);


        public PortfolioCategoryClientModel Category { get; set; }
        public PortfolioIndustryClientModel Industry { get; set; }


        public static PortfolioClientModel Create(Portfolio item, int? langId)
        {

            var model = new PortfolioClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.ImgPath = item.ImgPath;
            model.ShortDescription = item.ShortDescription;
            model.Content = item.Content;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.ImgPath = GetActualValue(model.Title, localization.ImgPath);
                    model.ShortDescription = GetActualValue(model.Title, localization.ShortDescription);
                    model.Content = GetActualValue(model.Content, localization.Content);
                }
            }

            model.Category = PortfolioCategoryClientModel.Create(item.Category, langId);
            model.Industry = PortfolioIndustryClientModel.Create(item.Industry, langId);

            return model;
        }
        public static List<PortfolioClientModel> CreateItems(IEnumerable<Portfolio> items, int? langId)
        {
            var models = new List<PortfolioClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
