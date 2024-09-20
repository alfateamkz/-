using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffItemGradeDTO : DTOModel<OutstaffItemGrade>
    {
        public string Title { get; set; }
        public List<OutstaffItemGradeColumnDTO> Prices { get; set; } = new List<OutstaffItemGradeColumnDTO>();


        public int MainLanguageId { get; set; }




        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int OutstaffItemId { get; set; }



        public OutstaffItemGradeDTO CreateDTOWithLocalization(OutstaffItemGrade item, int langId, int countryId, int currencyId)
        {
            var dto = (OutstaffItemGradeDTO)this.CreateDTOWithLocalization(item, langId);
            dto.Prices = new OutstaffItemGradeColumnDTO().CreateDTOsWithLocalization(item.Prices, langId, countryId, currencyId);

            return dto;
        }
        public List<OutstaffItemGradeDTO> CreateDTOsWithLocalization(List<OutstaffItemGrade> items, int langId, int countryId, int currencyId)
        {
            var models = new List<OutstaffItemGradeDTO>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, langId, countryId, currencyId));
            }
            return models;
        }
    }
}
