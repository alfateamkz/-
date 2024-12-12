using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.ExternalInteractions;
using Alfateam.Marketing.Models.Lettering;
using Alfateam.Marketing.Models.Lettering.Items;
using Alfateam.Marketing.Models.Segments;
using Alfateam.SharedModels.Filters;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<LetteringCampaign>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(NotSMSLetteringCampaign), "NotSMSLetteringCampaign")]
    [JsonKnownType(typeof(SMSLetteringCampaign), "SMSLetteringCampaign")]
    public class LetteringCampaign : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public LetteringStatus Status { get; set; }

        public string Title { get; set; }

        public List<Segment> IncludedSegments { get; set; } = new List<Segment>();
        public List<Segment> ExcludedSegments { get; set; } = new List<Segment>();



        public TimePeriod? SendOnlyBetweenTime { get; set; }





        public List<LetteringSentResult> LetteringSentResults { get; set; } = new List<LetteringSentResult>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
