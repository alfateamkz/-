using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages
{
    public class FraudCounteractionPageTexts : LocalizableModel
    {
        public string MainBlockHeader { get; set; } = "ВАША БЕЗОПАСНОСТЬ - НАША ЗАБОТА!";
        public string MainBlockShortText { get; set; } = "Во время звонка мошенники представляются менеджерами компаний. " +
            "Также рассылают электронные письма с недостоверной информацией, опасными ссылками и выдают себя за сотрудников Alfateam";


        public Content Content { get; set; } = new Content()
        {
            Items = new List<ContentItem>
            {
                new TextContentItem
                {
                    Guid = System.Guid.NewGuid().ToString(),
                    Content = "Сама текст противодействия мошенничеству, задать из админки контент"
                }
            }
        };
    }
}
