using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCNotificationsPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Оповещения";


        public string NoNotificationsTitle { get; set; } = "У Вас пока что нет новых уведомлений";
    }
}
