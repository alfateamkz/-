using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items
{
    public class PartnerLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public Content Content { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (партнера)
        /// </summary>
        public int PartnerId { get; set; }
    }
}
