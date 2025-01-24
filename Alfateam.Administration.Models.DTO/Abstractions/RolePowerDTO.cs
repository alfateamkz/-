using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.DTO.General.RolePowers;
using Alfateam.Administration.Models.General.RolePowers;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<RolePowerDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CertCenterRolePowerDTO), "CertCenterRolePower")]
    [JsonKnownType(typeof(CommonRolePowerDTO), "CommonRolePower")]
    public class RolePowerDTO : DTOModelAbs<RolePower>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
