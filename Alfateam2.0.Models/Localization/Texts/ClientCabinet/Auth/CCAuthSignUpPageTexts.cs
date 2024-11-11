using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth
{
    public class CCAuthSignUpPageTexts : LocalizableModel
    {
        [Description("Заголовок поля email")]
        public string EmailFieldTitle { get; set; } = "E-Mail";
        [Description("Плейсхолдер поля email")]
        public string EmailFieldPlaceholder { get; set; } = "mail@alfateam.co";



        [Description("Заголовок поля ваше имя")]
        public string NameFieldTitle { get; set; } = "Ваше имя";
        [Description("Плейсхолдер поля ваше имя")]
        public string NameFieldPlaceholder { get; set; } = "Артур";



        [Description("Заголовок поля пароль")]
        public string PasswordFieldTitle { get; set; } = "Пароль";
        [Description("Плейсхолдер поля пароль")]
        public string PasswordFieldPlaceholder { get; set; } = "****************";




        [Description("Заголовок поля повтор пароля")]
        public string RepeatPasswordFieldTitle { get; set; } = "Повтор пароля";
        [Description("Плейсхолдер поля повтор пароля")]
        public string RepeatPasswordFieldPlaceholder { get; set; } = "****************";


        [Description("Кнопка: назад")]
        public string BtnGoBack { get; set; } = "Назад";
        [Description("Кнопка: регистрация")]
        public string BtnRegister { get; set; } = "Регистрация";
        [Description("Кнопка: у меня есть аккаунт")]
        public string BtnIHaveAccount { get; set; } = "У меня есть аккаунт";
    }
}
