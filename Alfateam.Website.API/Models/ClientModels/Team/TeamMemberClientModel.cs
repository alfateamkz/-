using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Team;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Team
{
    public class TeamMemberClientModel : ClientModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }


        public string Position { get; set; }
        public string ShortExpierence { get; set; }
        public string Quote { get; set; }


        public string Slug => SlugHelper.GetLatynSlug($"{Surname} {Name} - {Position}");


        public Content DetailContent { get; set; }
        public string? CVFilepath { get; set; }


        public static TeamMemberClientModel Create(TeamMember item, int? langId)
        {

            var model = new TeamMemberClientModel();

            model.Id = item.Id;
            model.Name = item.Name;
            model.Surname = item.Surname;
            model.Position = item.Position;
            model.ShortExpierence = item.ShortExpierence;
            model.Quote = item.Quote;
            model.DetailContent = item.DetailContent;
            model.CVFilepath = item.CVFilepath;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Name = GetActualValue(model.Name, localization.Name);
                    model.Surname = GetActualValue(model.Surname, localization.Surname);
                    model.Position = GetActualValue(model.Position, localization.Position);
                    model.ShortExpierence = GetActualValue(model.ShortExpierence, localization.ShortExpierence);
                    model.Quote = GetActualValue(model.Quote, localization.Quote);
                    model.DetailContent = GetActualValue(model.DetailContent, localization.DetailContent);
                    model.CVFilepath = GetActualValue(model.CVFilepath, localization.CVFilepath);
                }
            }


            return model;
        }
        public static List<TeamMemberClientModel> CreateItems(List<TeamMember> items, int? langId)
        {
            var models = new List<TeamMemberClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
