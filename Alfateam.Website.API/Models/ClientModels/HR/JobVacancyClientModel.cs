using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.HR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.HR
{
    public class JobVacancyClientModel : ClientModel
    {
        protected JobVacancyClientModel() { }

        public string Title { get; set; }
        public Content InnerContent { get; set; }



        public string Slug => SlugHelper.GetLatynSlug(Title);

        public static JobVacancyClientModel Create(JobVacancy item, int? langId)
        {

            var model = new JobVacancyClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.InnerContent = item.InnerContent;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.InnerContent = GetActualValue(model.InnerContent, localization.InnerContent);
                }
            }

            return model;
        }
        public static List<JobVacancyClientModel> CreateItems(List<JobVacancy> items, int? langId)
        {
            var models = new List<JobVacancyClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
