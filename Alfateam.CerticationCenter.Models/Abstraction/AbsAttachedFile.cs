using Alfateam.CertificationCenter.Models.Files;
using Alfateam.Core;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.Abstraction
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsAttachedFile>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AttachedImage), "AttachedImage")]
    [JsonKnownType(typeof(AttachedVideo), "AttachedVideo")]
    public class AbsAttachedFile : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string FilePath { get; set; }


    }
}
