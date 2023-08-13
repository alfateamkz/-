using Alfateam.CRM2_0.Models.Abstractions.Roles.Financier;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Financier.Investments.Conditions;
using Alfateam.CRM2_0.Models.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.Candidates;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.HR
{

    [JsonConverter(typeof(JsonKnownTypesConverter<Candidate>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(CandidateEmployee), "CandidateEmployee")]
    [JsonKnownType(typeof(CandidateCounterparty), "CandidateCounterparty")]
    /// <summary>
    /// Базовая модель кандидата
    /// От данного класса наследуются CandidateEmployee (кандидат-работник) 
    /// и CandidateCounterparty (кандидат-контрагент)
    /// </summary>
    public abstract class Candidate : User
    {
        public CandidateStatus Status { get; set; } = CandidateStatus.Waiting;
        public List<CandidateInterview> Interviews { get; set; } = new List<CandidateInterview>();
    }
}
