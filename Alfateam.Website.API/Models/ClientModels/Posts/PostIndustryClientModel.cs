using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Posts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Posts
{
    public class PostIndustryClientModel : ClientModel
    {
        protected PostIndustryClientModel() { }

        public string Title { get; set; }



        public string Slug => SlugHelper.GetLatynSlug(Title);

        public static PostIndustryClientModel Create(PostIndustry item,int? langId)
        {

            var model = new PostIndustryClientModel();

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
        public static List<PostIndustryClientModel> CreateItems(IEnumerable<PostIndustry> items, int? langId)
        {
            var models = new List<PostIndustryClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
