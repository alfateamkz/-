using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.DTO.Filters.Dates;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DateFilterModelDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(LastDaysDateFilterModelDTO), "LastDaysDateFilterModel")]
    [JsonKnownType(typeof(MonthDateFilterModelDTO), "MonthDateFilterModel")]
    [JsonKnownType(typeof(PeriodDateFilterModelDTO), "PeriodDateFilterModel")]
    [JsonKnownType(typeof(QuarterDateFilterModelDTO), "QuarterDateFilterModel")]
    [JsonKnownType(typeof(YearDateFilterModelDTO), "YearDateFilterModel")]
    public class DateFilterModelDTO : DTOModelAbs<DateFilterModel>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
