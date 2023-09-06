using Alfateam.CRM2_0.Models.Roles.HR.Candidates;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires.Questions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.HR
{


    [JsonConverter(typeof(JsonKnownTypesConverter<HRQuestionaireQuestion>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(HRQuestionaireOptionsQuestion), "HRQuestionaireOptionsQuestion")]
    [JsonKnownType(typeof(HRQuestionaireTextQuestion), "HRQuestionaireTextQuestion")]
    /// <summary>
    /// Базовая модель вопроса опросника для HR
    /// </summary>
    public abstract class HRQuestionaireQuestion : AbsModel
    {
        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int HRQuestionaireQuestionGroupId { get; set; }
    }
}
