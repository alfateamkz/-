using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Franchising;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Programs;
using Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Franchises;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Sales
{


    [JsonConverter(typeof(JsonKnownTypesConverter<Franchise>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(DirectorFranchise), "DirectorFranchise")]
    [JsonKnownType(typeof(FixedRoyaltyFranchise), "FixedRoyaltyFranchise")]
    [JsonKnownType(typeof(PercentRoyaltyFranchise), "PercentRoyaltyFranchise")]
    /// <summary>
    /// Базовая сущность франшизы
    /// </summary>
    public abstract class Franchise : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public FranchiseStatus Status { get; set; } = FranchiseStatus.Active;
    }
}
