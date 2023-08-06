using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.ClientModels.Outstaff
{
    public class OutstaffItemClientModel : ClientModel
    {
        public string Title { get; set; }
        public List<OutstaffItemGradeClientModel> Grades { get; set; } = new List<OutstaffItemGradeClientModel>();



        public static OutstaffItemClientModel Create(OutstaffItem item, int? langId, int? countryId)
        {

            var model = new OutstaffItemClientModel();
            model.Id = item.Id;

            model.Grades = OutstaffItemGradeClientModel.CreateItems(item.Grades, langId, countryId);
 
            return model;
        }
        public static List<OutstaffItemClientModel> CreateItems(List<OutstaffItem> items, int? langId, int? countryId)
        {
            var models = new List<OutstaffItemClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }

    }
}
