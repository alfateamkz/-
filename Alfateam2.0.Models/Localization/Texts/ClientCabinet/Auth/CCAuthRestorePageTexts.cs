using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth
{
    public class CCAuthRestorePageTexts : LocalizableModel
    {
        [Description("Заголовок поля E-Mail")]
        public string EmailFieldTitle { get; set; } = "E-Mail";
        [Description("Плейсхолдер поля E-Mail")]
        public string EmailFieldPlaceholder { get; set; } = "mail@alfateam.co";


        [Description("Кнопка: назад")]
        public string BtnGoBack { get; set; } = "Назад";
        [Description("Кнопка: восстановить")]
        public string BtnRestore { get; set; } = "Восстановить";
        [Description("Кнопка: я вспомнил пароль")]
        public string BtnGoLogin { get; set; } = "Я вспомнил пароль!";
    }
}
