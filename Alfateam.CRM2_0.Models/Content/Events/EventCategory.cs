using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Events
{
    /// <summary>
    /// Модель категории мероприятия
    /// </summary>
    public class EventCategory : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
