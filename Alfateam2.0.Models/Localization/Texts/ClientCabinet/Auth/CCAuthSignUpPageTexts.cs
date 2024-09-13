using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth
{
    public class CCAuthSignUpPageTexts : LocalizableModel
    {
        public string EmailFieldTitle { get; set; } = "E-Mail";
        public string EmailFieldPlaceholder { get; set; } = "mail@alfateam.co";

        public string NameFieldTitle { get; set; } = "Ваше имя";
        public string NameFieldPlaceholder { get; set; } = "Артур";


        public string PasswordFieldTitle { get; set; } = "Пароль";
        public string PasswordFieldPlaceholder { get; set; } = "****************";

        public string RepeatPasswordFieldTitle { get; set; } = "Повтор пароля";
        public string RepeatPasswordFieldPlaceholder { get; set; } = "****************";


        public string BtnGoBack { get; set; } = "Назад";
        public string BtnRegister { get; set; } = "Регистрация";
        public string BtnIHaveAccount { get; set; } = "У меня есть аккаунт";
    }
}
