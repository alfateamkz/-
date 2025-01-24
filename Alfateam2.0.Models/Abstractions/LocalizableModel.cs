using Alfateam.Core;
using Alfateam2._0.Models.General;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("LanguageEntityId"), SwaggerIgnore]
        public Language LanguageEntity { get; set; }

        [SwaggerIgnore]
        public int LanguageEntityId { get; set; }



        public LocalizableModel()
        {

        }
        public LocalizableModel(int languageId)
        {
            LanguageEntityId = languageId;
        }
    }
}
