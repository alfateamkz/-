using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    /// <summary>
    /// Сущность перевода основных фраз
    /// </summary>
    public class CommonTexts : LocalizableModel
    {
        public HeaderTexts Header { get; set; }
        public FooterTexts Footer { get; set; }



        public string MainBreadcrump { get; set; }
        public string MoreBtn { get; set; }
        public string PlaceholderAll { get; set; }
    }
}
