using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffItemGradeColumnDTO : DTOModel<OutstaffItemGradeColumn>
    {
        public OutstaffColumnDTO Column { get; set; }
        public int ColumnId { get; set; }


        public OutstaffItemGradeDTO OutstaffItemGrade { get; set; }
        public int OutstaffItemGradeId  { get; set; }


        public PricingMatrixDTO CostPerHour { get; set; }

        [ForClientOnly]
        public CostDTO Cost { get; set; } 


       



        public OutstaffItemGradeColumnDTO CreateDTOWithLocalization(OutstaffItemGradeColumn item, int langId, int countryId, int currencyId)
        {
            var dto = (OutstaffItemGradeColumnDTO)this.CreateDTOWithLocalization(item, langId);

            var costs = GetLocalCosts(item.CostPerHour, countryId);
            var cost = costs.FirstOrDefault(o => o.CurrencyId == currencyId);

            if(cost != null)
            {
                Cost = (CostDTO)new CostDTO().CreateDTOWithLocalization(cost, langId);
            }


            return dto;
        }
        public List<OutstaffItemGradeColumnDTO> CreateDTOsWithLocalization(List<OutstaffItemGradeColumn> items, int langId, int countryId, int currencyId)
        {
            var models = new List<OutstaffItemGradeColumnDTO>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, langId, countryId, currencyId));
            }
            return models;
        }
    }
}
