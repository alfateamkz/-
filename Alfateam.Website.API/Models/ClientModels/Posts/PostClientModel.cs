using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.ClientModels.Posts
{

    /// <summary>
    /// Клиентская модель поста
    /// </summary>
    public class PostClientModel : ClientModel
    {
        protected PostClientModel() { }


       
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }


        public PostCategoryClientModel Category { get; set; }
        public PostIndustryClientModel Industry { get; set; }


        public static PostClientModel Create(Post post, int? langId)
        {
            var model = new PostClientModel();

            model.Id = post.Id;
            model.Title = post.Title;
            model.ImgPath = post.ImgPath;
            model.ShortDescription = post.ShortDescription;
            model.Content = post.Content;

            if (post.MainLanguageId != langId)
            {
                var localization = post.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.ImgPath = GetActualValue(model.Title, localization.ImgPath);
                    model.ShortDescription = GetActualValue(model.Title, localization.ShortDescription);
                    model.Content = GetActualValue(model.Content, localization.Content);
                }
            }

            model.Category = PostCategoryClientModel.Create(post.Category, langId);
            model.Industry = PostIndustryClientModel.Create(post.Industry, langId);

            return model;
        }
        public static List<PostClientModel> CreateItems(List<Post> items, int? langId)
        {
            var models = new List<PostClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
