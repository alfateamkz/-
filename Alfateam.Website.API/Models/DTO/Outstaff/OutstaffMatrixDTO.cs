using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffMatrixDTO : DTOModel<OutstaffMatrix>
    {
        public List<OutstaffColumnDTO> Columns { get; set; } = new List<OutstaffColumnDTO>();
        public List<OutstaffItemDTO> Items { get; set; } = new List<OutstaffItemDTO>();


        public static OutstaffMatrixDTO Create(OutstaffMatrix item, int? langId, int? countryId)
        {

            var model = new OutstaffMatrixDTO();

            model.Columns = OutstaffColumnDTO.CreateItemsWithLocalization(item.Columns, langId) as List<OutstaffColumnDTO>;
            model.Items = OutstaffItemDTO.CreateItems(item.Items, langId, countryId) as List<OutstaffItemDTO>;

            return model;
        }
    }
}
