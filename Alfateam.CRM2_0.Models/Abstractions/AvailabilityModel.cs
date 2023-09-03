using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions
{
    /// <summary>
    /// Базовая сущность с параметрами доступности
    /// </summary>
    public abstract class AvailabilityModel : AbsModel
    {
        public Availability Availability { get; set; }
        public int AvailabilityId { get; set; }


        //TODO: Языки в CRM - потом
        //public Language MainLanguage { get; set; }
        //public int MainLanguageId { get; set; }
    }
}
