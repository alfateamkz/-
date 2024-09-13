using Alfateam2._0.Models.General;
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
        [ForeignKey("LanguageEntityId")]
        public Language LanguageEntity { get; set; }
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
