using Alfateam.Core;
using Alfateam.Marketing.Models.SalesGenerators;
using Alfateam.Marketing.Models.SalesGenerators.Items;
using Alfateam.Marketing.Models.Segments;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<SalesGenerator>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(RepeatLeadsSalesGenerator), "RepeatLeadsSalesGenerator")]
    [JsonKnownType(typeof(RepeatOrdersSalesGenerator), "RepeatOrdersSalesGenerator")]
    public class SalesGenerator : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }

        public List<Segment> IncludedSegments { get; set; } = new List<Segment>();
        public List<Segment> ExcludedSegments { get; set; } = new List<Segment>();

        public SalesGeneratorStartOptions StartOptions { get; set; }




        public List<SGResponsibleCRMUserItem> ResponsibleCRMUsersQueue { get; set; } = new List<SGResponsibleCRMUserItem>();
        public string TaskForManagerText { get; set; }








        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }

    }
}
