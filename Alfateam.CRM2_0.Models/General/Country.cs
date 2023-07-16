using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель государства
    /// </summary>
    public class Country : AbsModel
    {
        /// <summary>
        /// Название страны
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Название страны на официальном языке
        /// </summary>
        public string OriginalTitle { get; set; }
        /// <summary>
        /// Код страны
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Правовые формы контрагентов
        /// </summary>
        public List<LegalForm> LegalForms { get; set; } = new List<LegalForm>();
        /// <summary>
        /// Системы налогообложения
        /// </summary>
        public List<TaxSystem> TaxSystems { get; set; } = new List<TaxSystem>();
    }
}
