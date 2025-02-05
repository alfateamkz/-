using Alfateam.Administration.Models.General;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.StaticTextsConstructor
{
    public class TextsSetLanguageZone : AbsModel
    {
        public Language Language { get; set; }
        public int LanguageId { get; set; }

        

        public List<StaticTextsModel> Texts { get; set; } = new List<StaticTextsModel>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int TextsSetId { get; set; }
    }
}
