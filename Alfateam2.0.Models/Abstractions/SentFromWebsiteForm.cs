using Alfateam.Core;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Forms;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Modifiers.Items;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ProductModifierItem>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ContactMeForm), "ContactMeForm")]
    [JsonKnownType(typeof(JoinEventForm), "JoinEventForm")]
    public class SentFromWebsiteForm : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public SentFromWebsiteFormHandlingStatus Status { get; set; } = SentFromWebsiteFormHandlingStatus.Waiting;



        public string UserAgent { get; set; }
        public string Fingerprint { get; set; }
        public string? IP { get; set; }


        public User? SentByUser { get; set; }
        public int? SentByUserId { get; set; }
    }
}
