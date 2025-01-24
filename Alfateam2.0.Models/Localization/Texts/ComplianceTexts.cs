using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    /// <summary>
    /// Сущность перевода текста страницы комплаенс
    /// </summary>
    public class ComplianceTexts :  LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Комплаенс в Alfateam";
        public string Header { get; set; } = "Комплаенс";
        public Content Content { get; set; } = new Content()
        {
            Items = new List<ContentItem>
            {
                new TextContentItem
                {
                    Guid = System.Guid.NewGuid().ToString(),
                    Content = "Текст комплаенса, задать из админки контент"
                }
            }
        };
    }
}
