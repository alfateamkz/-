using Alfateam.Core;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Documents.Types;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<Counterparty>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CompanyCounterparty), "CompanyCounterparty")]
    [JsonKnownType(typeof(EDMCounterparty), "EDMCounterparty")]
    [JsonKnownType(typeof(IndividualCounterparty), "IndividualCounterparty")]
    public class Counterparty : AbsModel
    {
        public CounterpartyGroup Group { get; set; }
        public int GroupId { get; set; }


        public int EDMSubjectId { get; set; }
    }
}
