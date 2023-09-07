using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Conditions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring.Questions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.SecurityService
{


    [JsonConverter(typeof(JsonKnownTypesConverter<ScoringQuestion>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(ScoringOptionsQuestion), "ScoringOptionsQuestion")]
    [JsonKnownType(typeof(ScoringYesNoQuestion), "ScoringYesNoQuestion")]
    /// <summary>
    /// Базовая модель вопроса скоринга
    /// </summary>
    public abstract class ScoringQuestion : AbsModel
    {

        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ScoringQuestionGroupId { get; set; }
    }
}
