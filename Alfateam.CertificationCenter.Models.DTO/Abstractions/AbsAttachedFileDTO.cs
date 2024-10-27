using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DTO.Files;
using Alfateam.CertificationCenter.Models.Files;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.CertificationCenter.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsAttachedFileDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AttachedImageDTO), "AttachedImage")]
    [JsonKnownType(typeof(AttachedVideoDTO), "AttachedVideo")]
    public class AbsAttachedFileDTO : DTOModelAbs<AbsAttachedFile>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public string FilePath { get; set; }
    }
}
