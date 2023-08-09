using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.ClientModels
{
    public class MassMediaPostClientModel : ClientModel
    {
        protected MassMediaPostClientModel() { }

        public string Title { get; set; }
        public string ShortDescription { get; set; }




        public static MassMediaPostClientModel Create(MassMediaPost item, int? langId)
        {

            var model = new MassMediaPostClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.ShortDescription = item.ShortDescription;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.ShortDescription = GetActualValue(model.ShortDescription, localization.ShortDescription);
                }
            }

            return model;
        }
        public static List<MassMediaPostClientModel> CreateItems(List<MassMediaPost> items, int? langId)
        {
            var models = new List<MassMediaPostClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
