using Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Conditions;
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

    [JsonConverter(typeof(JsonKnownTypesConverter<FranchiseSaleConditions>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(DirectorFranchiseSaleConditions), "DirectorFranchiseSaleConditions")]
    [JsonKnownType(typeof(FixedRoyaltyFranchiseSaleConditions), "FixedRoyaltyFranchiseSaleConditions")]
    [JsonKnownType(typeof(PercentRoyaltyFranchiseSaleConditions), "PercentRoyaltyFranchiseSaleConditions")]
    /// <summary>
    /// Базовая модель договоренности по конкретной продаже франшизы 
    /// </summary>
    public abstract class FranchiseSaleConditions : AbsModel
    {
    }
}
