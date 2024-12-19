using Alfateam.Core;
using Alfateam.SharedModels.Filters.Dates;
using Alfateam.SharedModels.Filters.Dates.Props;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DateFilterModel>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(LastDaysDateFilterModel), "LastDaysDateFilterModel")]
    [JsonKnownType(typeof(MonthDateFilterModel), "MonthDateFilterModel")]
    [JsonKnownType(typeof(PeriodDateFilterModel), "PeriodDateFilterModel")]
    [JsonKnownType(typeof(QuarterDateFilterModel), "QuarterDateFilterModel")]
    [JsonKnownType(typeof(YearDateFilterModel), "YearDateFilterModel")]
    public class DateFilterModel : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public virtual DateFilterPeriod GetPeriod()
        {
            throw new NotSupportedException("Это абстрактный класс");
        }
    }
}
