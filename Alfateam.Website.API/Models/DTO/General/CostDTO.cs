using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class CostDTO : DTOModel<Cost>
    {
        public CurrencyDTO Currency { get; set; }
        public double Value { get; set; }
    }
}
