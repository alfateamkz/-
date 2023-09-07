using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Events;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans.Pledges;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance
{


    [JsonConverter(typeof(JsonKnownTypesConverter<LoanObligationPledge>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(DepositLoanPledge), "DepositLoanPledge")]
    [JsonKnownType(typeof(RealEstateLoanPledge), "RealEstateLoanPledge")]
    [JsonKnownType(typeof(ThingLoanPledge), "ThingLoanPledge")]
    [JsonKnownType(typeof(TransportLoanPledge), "TransportLoanPledge")]
    /// <summary>
    /// Базовая модель залога 
    /// </summary>
    public abstract class LoanObligationPledge : AbsModel
    {


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        [JsonIgnore]
        public int LoanObligationId { get; set; }
    }
}
