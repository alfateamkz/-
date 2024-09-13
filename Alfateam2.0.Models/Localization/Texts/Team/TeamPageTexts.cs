using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Team
{
    /// <summary>
    /// Сущность перевода текста страницы команда
    /// </summary>
    public class TeamPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Команда";
        public string Header { get; set; } = "КОМАНДА";
        public Content Content { get; set; } = new Content()
        {
            Items = new List<ContentItem>
            {
                new TextContentItem
                {
                    Content = "Наша команда – это сердце и душа компании, энергичная и творческая группа профессионалов, которая объединена общим стремлением к инновациям и качеству. " +
                    "Мы с гордостью можем сказать, что каждый член нашей команды является экспертом в своей области и приносит свой уникальный вклад в успех компании."
                }
            }
        };
    }
}
