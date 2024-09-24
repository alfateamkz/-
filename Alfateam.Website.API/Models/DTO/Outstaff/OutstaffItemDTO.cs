using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffItemDTO : DTOModel<OutstaffItem>
    {
        public string Title { get; set; }
        [ForClientOnly]
        public List<OutstaffItemGradeDTO> Grades { get; set; } = new List<OutstaffItemGradeDTO>();


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int OutstaffMatrixId { get; set; }


        public int MainLanguageId { get; set; }




        public OutstaffItemDTO CreateDTOWithLocalization(OutstaffItem item, int langId, int countryId, int currencyId)
        {
            var dto = (OutstaffItemDTO)this.CreateDTOWithLocalization(item, langId);
            dto.Grades = new OutstaffItemGradeDTO().CreateDTOsWithLocalization(item.Grades, langId, countryId, currencyId);

            return dto;
        }
        public List<OutstaffItemDTO> CreateDTOsWithLocalization(List<OutstaffItem> items, int langId, int countryId, int currencyId)
        {
            var models = new List<OutstaffItemDTO>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, langId, countryId, currencyId));
            }
            return models;
        }
    }
}
