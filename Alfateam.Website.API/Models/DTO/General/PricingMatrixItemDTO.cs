using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class PricingMatrixItemDTO : DTOModel<PricingMatrixItem>
    {


        /// <summary>
        /// Страна, для которой применяются стоимость 
        /// Если Country == null, то эти стоимости применяются для прочих стран(которые не указаны в матрице цен)
        /// </summary>
        [ForClientOnly]
        public CountryDTO? Country { get; set; }
        public int? CountryId { get; set; }


        /// <summary>
        /// Стоимости. Например, в Польше может быть две цены(в евро и в злотых)
        /// </summary>
        public List<CostDTO> Costs { get; set; } = new List<CostDTO>();
    }
}
