using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires.Questions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Litigations;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer
{


    [JsonConverter(typeof(JsonKnownTypesConverter<Litigation>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(AdministrativeLitigation), "AdministrativeLitigation")]
    [JsonKnownType(typeof(ArbitrationLitigation), "ArbitrationLitigation")]
    [JsonKnownType(typeof(CivilLitigation), "CivilLitigation")]
    [JsonKnownType(typeof(ConstitutionalLitigation), "ConstitutionalLitigation")]
    [JsonKnownType(typeof(CriminalLitigation), "CriminalLitigation")]
    /// <summary>
    /// Базовая сущность судебного разбирательства
    /// Наследуемые классы описывают конституционный, уголовный, гражданский, арбитражный и административный судебный процесс
    /// </summary>
    public abstract class Litigation : AbsModel
    {
        /// <summary>
        /// Стороны судебного процесса. Как правило две(истец и ответчик)
        /// </summary>
        public List<TrialProcessSide> Sides { get; set; } = new List<TrialProcessSide>();


        public List<TrialRequest> TrialRequests { get; set; } = new List<TrialRequest>();
        public List<TrialHearing> Hearings { get; set; } = new List<TrialHearing>();


        public TrialProcessResult? Result { get; set; }
        public int? ResultId { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int LegalCaseId { get; set; }


	}
}
