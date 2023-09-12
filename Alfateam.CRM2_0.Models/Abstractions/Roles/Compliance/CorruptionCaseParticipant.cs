using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Financier;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption.Participants;
using Alfateam.CRM2_0.Models.Roles.Financier.Investments.Conditions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance
{

    [JsonConverter(typeof(JsonKnownTypesConverter<CorruptionCaseParticipant>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(CRMBindedCorruptionCaseParticipant), "CRMBindedCorruptionCaseParticipant")]
    [JsonKnownType(typeof(InfoCorruptionCaseParticipant), "InfoCorruptionCaseParticipant")]
    /// <summary>
    /// Участник коррупционного инцидента
    /// </summary>
    public class CorruptionCaseParticipant : AbsModel
    {
        public string Comment { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int CorruptionCaseSideId { get; set; }
    }
}
