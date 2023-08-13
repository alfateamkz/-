using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.Outstaff;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.ClientModels.General
{
    public class CostClientModel : ClientModel
    {
        public CurrencyClientModel Currency { get; set; }
        public double Value { get; set; }

        public static CostClientModel Create(Cost item, int? langId)
        {
            var model = new CostClientModel();
            model.Id = item.Id;
            model.Value = item.Value;
            model.Currency = CurrencyClientModel.Create(item.Currency, langId);

            return model;
        }
        public static List<CostClientModel> CreateItems(List<Cost> items, int? langId)
        {
            var models = new List<CostClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
