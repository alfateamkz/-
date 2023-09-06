using Alfateam.CRM2_0.Models.Abstractions.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring.Questions;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Staff
{


    [JsonConverter(typeof(JsonKnownTypesConverter<CounterpartySubparty>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(BindedWorkerSubparty), "BindedWorkerSubparty")]
    [JsonKnownType(typeof(CompanySubparty), "CompanySubparty")]
    [JsonKnownType(typeof(EmployeeSubparty), "EmployeeSubparty")]
    /// <summary>
    /// Информация о ресурсе контрагента, который учавствует в разработке проектов
    /// </summary>
    public class CounterpartySubparty : AbsModel
    {



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        [JsonIgnore]
        public int? CandidateCounterpartyId { get; set; }


        public virtual void SetCandidateCounterpartyIdRecursively(int id)
        {
            CandidateCounterpartyId = id;
        }

    }
}
