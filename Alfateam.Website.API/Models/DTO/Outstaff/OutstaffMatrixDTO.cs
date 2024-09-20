using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffMatrixDTO : DTOModel<OutstaffMatrix>
    {
        public List<OutstaffColumnDTO> Columns { get; set; } = new List<OutstaffColumnDTO>();
        public List<OutstaffItemDTO> Items { get; set; } = new List<OutstaffItemDTO>();


        public OutstaffMatrixDTO CreateDTOWithLocalization(OutstaffMatrix item, int langId, int countryId, int currencyId)
        {
            var dto = (OutstaffMatrixDTO)this.CreateDTOWithLocalization(item,langId);
            dto.Items = new OutstaffItemDTO().CreateDTOsWithLocalization(item.Items, langId, countryId, currencyId);

            return dto;
        }
    }
}
