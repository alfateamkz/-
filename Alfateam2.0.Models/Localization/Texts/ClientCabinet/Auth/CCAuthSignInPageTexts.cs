using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth
{
    public class CCAuthSignInPageTexts : LocalizableModel
    {
        [Description("Заголовок поля email")]
        public string EmailFieldTitle { get; set; } = "E-Mail";
        [Description("Плейсхолдер поля email")]
        public string EmailFieldPlaceholder { get; set; } = "mail@alfateam.co";



        [Description("Заголовок поля пароль")]
        public string PasswordFieldTitle { get; set; } = "Пароль";
        [Description("Плейсхолдер поля пароль")]
        public string PasswordFieldPlaceholder { get; set; } = "****************";




        [Description("Кнопка: назад")]
        public string BtnGoBack { get; set; } = "Назад";
        [Description("Кнопка: вход")]
        public string BtnAuth { get; set; } = "Вход";
        [Description("Кнопка: забыли пароль")]
        public string BtnForgotPassword { get; set; } = "Забыли пароль?";
    }
}
