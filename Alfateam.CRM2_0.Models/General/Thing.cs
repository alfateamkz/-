using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель сущности вещевого объекта
    /// </summary>
    public class Thing : AbsModel
    {
        public ThingType Type { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
