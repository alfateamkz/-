using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.General.Taxes;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions
{


    [JsonConverter(typeof(JsonKnownTypesConverter<TaxSystem>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(ProgressiveTaxSystem), "ProgressiveTaxSystem")]
    [JsonKnownType(typeof(SimpleFixedTaxSystem), "SimpleFixedTaxSystem")]
    [JsonKnownType(typeof(SimplePercentTaxSystem), "SimplePercentTaxSystem")]
    /// <summary>
    /// Базовая сущность системы налогообложения
    /// </summary>
    public abstract class TaxSystem : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        /// <summary>
        /// Может ли режим применяться для всех правовых форм
        /// </summary>
        public bool IsAllowedForAllLegalForms { get; set; } = true;

        /// <summary>
        /// Правовые формы, для которых может применяться режим. 
        /// Режим может применяться для всех, если список - пустой или IsAllowedForAllLegalForms = true
        /// </summary>
        public List<LegalForm> AllowedLegalForms { get; set; } = new List<LegalForm>();
    }
}
