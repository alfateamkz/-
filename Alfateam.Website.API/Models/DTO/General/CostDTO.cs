using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class CostDTO : DTOModel<Cost>
    {
        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        public int CurrencyId { get; set; }

        public double Value { get; set; }
    }
}
