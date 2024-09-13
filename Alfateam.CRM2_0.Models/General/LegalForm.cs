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
     /// Правовая форма (физ.лицо, самозанятый, ип, ооо/тоо, ао и т.п.)
     /// Для каждой страны будут свои правовые формы. 
     /// Например в Республике Кыргызстан ООО это ОсОО, а в Казахстане - ТОО
     /// </summary>
    public class LegalForm : AbsModel
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public LegalFormType Type { get; set; }
        public int CountryId { get; set; }
    }
}
