using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth
{
    public class CCAuthSignInPageTexts : LocalizableModel
    {
        public string EmailFieldTitle { get; set; } = "E-Mail";
        public string EmailFieldPlaceholder { get; set; } = "mail@alfateam.co";


        public string PasswordFieldTitle { get; set; } = "Пароль";
        public string PasswordFieldPlaceholder { get; set; } = "****************";


        public string BtnGoBack { get; set; } = "Назад";
        public string BtnAuth { get; set; } = "Вход";
        public string BtnForgotPassword { get; set; } = "Забыли пароль?";
    }
}
