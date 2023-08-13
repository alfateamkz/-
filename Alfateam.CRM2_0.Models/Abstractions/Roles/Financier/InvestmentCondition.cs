using Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.InvestProject;
using Alfateam.CRM2_0.Models.Roles.Financier.Investments.Conditions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Financier
{


    [JsonConverter(typeof(JsonKnownTypesConverter<InvestmentCondition>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(DepositInvestmentCondition), "DepositInvestmentCondition")]
    [JsonKnownType(typeof(EquityInvestmentCondition), "EquityInvestmentCondition")]
    /// <summary>
    /// Базовая модель условия по инвестиции
    /// </summary>
    public abstract class InvestmentCondition : AbsModel
    {
    }
}
