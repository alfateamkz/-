using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth
{
    public class CCAuthRestorePageTexts : LocalizableModel
    {
        public string EmailFieldTitle { get; set; } = "E-Mail";
        public string EmailFieldPlaceholder { get; set; } = "mail@alfateam.co";



        public string BtnGoBack { get; set; } = "Назад";
        public string BtnRestore { get; set; } = "Восстановить";
        public string BtnGoLogin { get; set; } = "Я вспомнил пароль!";
    }
}
