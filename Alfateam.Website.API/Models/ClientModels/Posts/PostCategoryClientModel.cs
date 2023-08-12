using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Posts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Posts
{
    public class PostCategoryClientModel : ClientModel
    {
        protected PostCategoryClientModel() { }

        public string Title { get; set; }


        public string Slug => SlugHelper.GetLatynSlug(Title);

        public static PostCategoryClientModel Create(PostCategory item, int? langId)
        {

            var model = new PostCategoryClientModel();

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
        public static List<PostCategoryClientModel> CreateItems(IEnumerable<PostCategory> items, int? langId)
        {
            var models = new List<PostCategoryClientModel>();
            foreach(var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
