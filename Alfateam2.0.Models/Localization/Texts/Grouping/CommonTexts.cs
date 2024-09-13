using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping
{
    /// <summary>
    /// Сущность перевода основных фраз
    /// </summary>
    public class CommonTexts : LocalizableModel
    {

        public int WebsiteLocalizationTextsId { get; set; }


        public HeaderTexts Header { get; set; } = new HeaderTexts();
        public FooterTexts Footer { get; set; } = new FooterTexts();
        public LinksLocalization Links { get; set; } = new LinksLocalization();
        public ClientCabinetCommonTexts ClientCabinet { get; set; } = new ClientCabinetCommonTexts();




        public string MainBreadcrump { get; set; } = "Главная";
        public string MoreBtn { get; set; } = "Еще";
        public string PlaceholderAll { get; set; } = "Все";
    }
}
