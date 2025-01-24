using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Events
{
    /// <summary>
    /// Модель формата мероприятия
    /// </summary>
    public class EventFormat : AvailabilityModel
    {
        public string Title { get; set; }


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{Id}";

        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<EventFormatLocalization> Localizations { get; set; } = new List<EventFormatLocalization>();
    }
}
