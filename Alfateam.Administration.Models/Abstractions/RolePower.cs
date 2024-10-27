using Alfateam.Administration.Models.General.RolePowers;
using Alfateam.Core;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Abstractions
{
    /// <summary>
    /// Базовая сущность полномочия роли
    /// </summary>
    [JsonConverter(typeof(JsonKnownTypesConverter<RolePower>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CertCenterRolePower), "CertCenterRolePower")]
    [JsonKnownType(typeof(CommonRolePower), "CommonRolePower")]
    public class RolePower : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
