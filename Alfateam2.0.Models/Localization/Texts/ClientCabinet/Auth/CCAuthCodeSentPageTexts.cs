using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth
{
    public class CCAuthCodeSentPageTexts : LocalizableModel
    {
        [Description("Заголовок")]
        public string Header { get; set; } = "На ваш e-mail отправлено письмо!";
        [Description("Описание")]
        public string Description { get; set; } = "Если письма нет, то проверьте папку спам";


        [Description("Кнопка назад")]
        public string BtnGoBack { get; set; } = "Назад";
    }
}
