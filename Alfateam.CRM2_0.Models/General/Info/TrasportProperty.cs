using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Info
{
    /// <summary>
    /// Модель свойства транспорта
    /// Например: кол-во лошадиных сил или мест
    /// </summary>
    public class TrasportProperty : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
