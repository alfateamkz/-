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
    /// Сущность перевода текста страницы новостейй
    /// </summary>
    public class PostsTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; }
        public string Header { get; set; }


        public string Directions { get; set; }
        public string Industries { get; set; }
        public string Search { get; set; }

        public string SearchTextBoxPlaceholder { get; set; }


        public string SearchBtn { get; set; }



        public string AnotherNews { get; set; }
    }
}
