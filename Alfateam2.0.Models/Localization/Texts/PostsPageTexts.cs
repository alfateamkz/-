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
    /// Сущность перевода текста страницы новостей
    /// </summary>
    public class PostsPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Новости";
        public string Header { get; set; } = "НОВОСТИ";


        public string Directions { get; set; } = "Направления";
        public string Industries { get; set; } = "Индустрии";
        public string Search { get; set; } = "Поиск";

        public string SearchTextBoxPlaceholder { get; set; } = "Поиск новостей";


        public string SearchBtn { get; set; } = "Найти";



        public string AnotherNews { get; set; } = "ДРУГИЕ НОВОСТИ";
    }
}
