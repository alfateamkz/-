using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Система налогообложения
    /// </summary>
    public class TaxSystem : AbsModel
    {
        public string Title { get; set; }

        /// <summary>
        /// Базовый процент (в некоторых странах есть прогрессивные системы налогообложения)
        /// </summary>
        public double BasePercent { get; set; }

        /// <summary>
        /// Лимит, до которого дейтствует налоговый режим. 
        /// Например, в России по УСН доход не должен составлять более 150 млн. 
        /// </summary>
        public double? Limit { get; set; }

        /// <summary>
        /// Может ли режим применяться для всех правовых форм
        /// </summary>
        public bool IsAllowedForAllLegalForms { get; set; } = true;

        /// <summary>
        /// Правовые формы, для которых может применяться режим. 
        /// Режим может применяться для всех, если список - пустой или IsAllowedForAllLegalForms = true
        /// </summary>
        public List<LegalForm> AllowedLegalForms { get; set; } = new List<LegalForm>();
         


        //TODO: прогрессивная система налогообложения
    }
}
