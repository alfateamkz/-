using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{
    /// <summary>
    /// Сущность модели с локализацией
    /// </summary>
    public abstract class LocalizableModel : AbsModel
    {
        public Language Language { get; set; }
        public int LanguageId { get; set; }


    }
}
