using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.ClientModels.Team
{
    public class TeamStructureClientModel : ClientModel
    {
        public List<TeamGroupClientModel> Groups { get; set; } = new List<TeamGroupClientModel>();

        public static TeamStructureClientModel Create(TeamStructure item, int? langId)
        {
            var model = new TeamStructureClientModel();
            model.Groups = TeamGroupClientModel.CreateItems(item.Groups, langId);
            return model;
        }
        public static List<TeamStructureClientModel> CreateItems(IEnumerable<TeamStructure> items, int? langId)
        {
            var models = new List<TeamStructureClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
