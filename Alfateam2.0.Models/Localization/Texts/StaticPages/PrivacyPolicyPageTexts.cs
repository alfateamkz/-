using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages
{
    /// <summary>
    /// Сущность перевода политики конфедициальности
    /// </summary>
    public class PrivacyPolicyPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Политика конфиденциальности";
        public Content Content { get; set; } = new Content()
        {
            Items = new List<ContentItem>
            {
                new TextContentItem
                {
                    Content = "Текст политики конфиденциальности, задать из админки контент"
                }
            }
        };
    }
}
