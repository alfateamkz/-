using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DatePeriod;
using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;
using Alfateam.Sales.API.Models.DTO.ExternalInteractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DateFilterModel>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(LastDaysDateFilterModel), "LastDaysDateFilterModel")]
    [JsonKnownType(typeof(MonthDateFilterModel), "MonthDateFilterModel")]
    [JsonKnownType(typeof(PeriodDateFilterModel), "PeriodDateFilterModel")]
    [JsonKnownType(typeof(QuarterDateFilterModel), "QuarterDateFilterModel")]
    [JsonKnownType(typeof(YearDateFilterModel), "YearDateFilterModel")]
    public abstract class DateFilterModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public abstract DateFilterPeriod GetPeriod();
    }
}
