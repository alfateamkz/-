using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Events
{
    public class EventFormatLocalization : LocalizableModel
    {
        public string Title { get; set; }


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{EventFormatId}";


        /// <summary>
        /// Автоматическое свойство
        /// Указывает на главный объект (формат события)
        /// </summary>
        public int EventFormatId { get; set; }
    }
}
