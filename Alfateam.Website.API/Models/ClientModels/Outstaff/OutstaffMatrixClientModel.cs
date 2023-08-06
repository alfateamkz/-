using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.ClientModels.Outstaff
{
    public class OutstaffMatrixClientModel : ClientModel
    {
        public List<OutstaffColumnClientModel> Columns { get; set; } = new List<OutstaffColumnClientModel>();
        public List<OutstaffItemClientModel> Items { get; set; } = new List<OutstaffItemClientModel>();



        public static OutstaffMatrixClientModel Create(OutstaffMatrix item, int? langId, int? countryId)
        {

            var model = new OutstaffMatrixClientModel();

            model.Columns = OutstaffColumnClientModel.CreateItems(item.Columns, langId);
            model.Items = OutstaffItemClientModel.CreateItems(item.Items, langId, countryId);

            return model;
        }
        public static List<OutstaffMatrixClientModel> CreateItems(List<OutstaffMatrix> items, int? langId, int? countryId)
        {
            var models = new List<OutstaffMatrixClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
