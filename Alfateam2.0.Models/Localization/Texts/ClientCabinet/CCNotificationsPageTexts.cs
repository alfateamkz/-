using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCNotificationsPageTexts : LocalizableModel
    {
        [Description("Заголовок: Оповещения")]
        public string Header { get; set; } = "Оповещения";

        [Description("У Вас пока что нет новых уведомлений")]
        public string NoNotificationsTitle { get; set; } = "У Вас пока что нет новых уведомлений";
    }
}
