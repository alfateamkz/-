using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages
{
    public class CorporateCulturePageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Корпоративная этика";
        public string Header { get; set; } = "КОРПОРАТИВНАЯ ЭТИКА";
        public Content Content { get; set; } = new Content()
        {
            Items = new List<ContentItem>
            {
                new TextContentItem
                {
                    Guid = System.Guid.NewGuid().ToString(),
                    Content = "Сама корпоративная этика, задать из админки контент"
                }
            }
        };
    }
}
