using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.ClientModels.Outstaff
{
    public class OutstaffItemGradeColumnClientModel : ClientModel
    {
        public OutstaffColumnClientModel Column { get; set; }
        public List<Cost> CostsPerHour { get; set; } = new List<Cost>();


        public static OutstaffItemGradeColumnClientModel Create(OutstaffItemGradeColumn item, int? langId, int? countryId)
        {

            var model = new OutstaffItemGradeColumnClientModel();
            model.Id = item.Id;

            model.Column = OutstaffColumnClientModel.Create(item.Column,langId);
            model.CostsPerHour = GetLocalCosts(item.CostPerHour, countryId);


            return model;
        }
        public static List<OutstaffItemGradeColumnClientModel> CreateItems(List<OutstaffItemGradeColumn> items, int? langId, int? countryId)
        {
            var models = new List<OutstaffItemGradeColumnClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
