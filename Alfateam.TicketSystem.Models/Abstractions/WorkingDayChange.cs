using Alfateam.Core;
using Alfateam.TicketSystem.Models.General.WorkingDays.Changes;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<WorkingDayChange>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(WorkingDayChangeDayOff), "WorkingDayChangeDayOff")]
    [JsonKnownType(typeof(WorkingDayChangeNewTime), "WorkingDayChangeNewTime")]
    public class WorkingDayChange : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public DateTime Day { get; set; }
    }
}
