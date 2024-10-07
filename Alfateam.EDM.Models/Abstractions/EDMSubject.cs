using Alfateam.Core;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.Subjects;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    /// <summary>
    /// Субъект документооборота (компания\ИП(Company) или физ.лицо\самозанятый (Individual)
    /// </summary>
    [JsonConverter(typeof(JsonKnownTypesConverter<EDMSubject>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(Company), "Company")]
    [JsonKnownType(typeof(Individual), "Individual")]
    public class EDMSubject : AbsModel
    {

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string CountryCode { get; set; }


        public string? LogoPath { get; set; }
        public string? Description { get; set; }




        /// <summary>
        /// ИНН (в РФ), БИН\ИИН (в КЗ), в других странах может быть другое
        /// </summary>
        public string BusinessNumber { get; set; }


        /// <summary>
        /// Головное подразделение бизнеса\физика. Если физик, то не сможет создавать дочерние подразделения
        /// </summary>
        public Department Department { get; set; }


        public WhoCanSendDocumentsToUs WhoCanSendDocumentsToUs { get; set; } = WhoCanSendDocumentsToUs.AllExceptingBlocked;


        public List<Counterparty> Counterparties { get; set; } = new List<Counterparty>();
        public List<CounterpartyGroup> CounterpartyGroups { get; set; } = new List<CounterpartyGroup>();
        public List<BannedCounterparty> BannedCounterparties { get; set; } = new List<BannedCounterparty>();



        public List<DocumentType> CustomDocumentTypes { get; set; } = new List<DocumentType>();



        /// <summary>
        /// Подтверждена ли компания. Если нет, то она не сможет принимать участие в документообороте. 
        /// Чтобы смогла, нужно подтвердить владение компанией
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Автоматическое поле, указывающее на сущность Business, в которой находятся сущности компаний
        /// </summary>
        public int BusinessId { get; set; }
    }
}
