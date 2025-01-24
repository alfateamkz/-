using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.General.WorkingDays.Changes;
using Alfateam.TicketSystem.Models.General.WorkingDays.Changes;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<WorkingDayChangeDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(WorkingDayChangeDayOffDTO), "WorkingDayChangeDayOff")]
    [JsonKnownType(typeof(WorkingDayChangeNewTimeDTO), "WorkingDayChangeNewTime")]
    public class WorkingDayChangeDTO : DTOModelAbs<WorkingDayChange>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public DateTime Day { get; set; }
    }
}
