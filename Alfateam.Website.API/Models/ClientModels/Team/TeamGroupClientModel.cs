using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.ClientModels.Team
{
    public class TeamGroupClientModel : ClientModel
    {
        public string Title { get; set; }
        public List<TeamMemberClientModel> Members { get; set; } = new List<TeamMemberClientModel>();


        public static TeamGroupClientModel Create(TeamGroup item, int? langId)
        {

            var model = new TeamGroupClientModel();

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

            model.Members = TeamMemberClientModel.CreateItems(item.Members,langId);

            return model;
        }
        public static List<TeamGroupClientModel> CreateItems(List<TeamGroup> items, int? langId)
        {
            var models = new List<TeamGroupClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
