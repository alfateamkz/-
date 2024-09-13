using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffItemGradeColumnDTO : DTOModel<OutstaffItemGradeColumn>
    {
        public OutstaffColumnDTO Column { get; set; }
        public List<CostDTO> CostsPerHour { get; set; } = new List<CostDTO>();


        public int ColumnId { get; set; }



        public static OutstaffItemGradeColumnDTO Create(OutstaffItemGradeColumn item, int? langId, int? countryId)
        {

            var model = new OutstaffItemGradeColumnDTO();
            model.Id = item.Id;

            model.Column = OutstaffColumnDTO.CreateWithLocalization(item.Column, langId) as OutstaffColumnDTO;

            var costs = GetLocalCosts(item.CostPerHour, countryId);
            model.CostsPerHour = CostDTO.CreateItemsWithLocalization(costs, langId) as List<CostDTO>;

            return model;
        }
        public static List<OutstaffItemGradeColumnDTO> CreateItems(List<OutstaffItemGradeColumn> items, int? langId, int? countryId)
        {
            var models = new List<OutstaffItemGradeColumnDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
