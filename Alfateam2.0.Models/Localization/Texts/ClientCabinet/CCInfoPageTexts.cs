using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCInfoPageTexts : LocalizableModel
    {

        [Description("Заголовок: Информация")]
        public string Header { get; set; } = "Информация";


        [Description("Личные данные")]
        public string HeaderPersonalData { get; set; } = "Личные данные";
        [Description("Аватар")]
        public string Avatar { get; set; } = "Аватар";


        [Description("Имя")]
        public string FormInputName { get; set; } = "Имя";
        [Description("Артур")]
        public string FormInputNamePlaceholder { get; set; } = "Артур";


        [Description("Фамилия")]
        public string FormInputSurname { get; set; } = "Фамилия";
        [Description("Бондарев")]
        public string FormInputSurnamePlaceholder { get; set; } = "Бондарев";


        [Description("Отчество")]
        public string FormInputPatronymic { get; set; } = "Отчество";
        [Description("Александрович")]
        public string FormInputPatronymicPlaceholder { get; set; } = "Александрович";
        [Description("Сохранить")]
        public string FormBtnSave { get; set; } = "Сохранить";



        [Description("Смена пароля")]
        public string HeaderChangePassword { get; set; } = "Смена пароля";


        [Description("Старый пароль")]
        public string ChangePasswordFormOldTitle { get; set; } = "Старый пароль";
        [Description("*************")]
        public string ChangePasswordFormOldPlaceholder { get; set; } = "*************";


        [Description("Новый пароль")]
        public string ChangePasswordFormNewTitle { get; set; } = "Новый пароль";
        [Description("*************")]
        public string ChangePasswordFormNewPlaceholder { get; set; } = "*************";


        [Description("Повтор пароля")]
        public string ChangePasswordFormRepeatTitle { get; set; } = "Повтор пароля";
        [Description("*************")]
        public string ChangePasswordFormRepeatPlaceholder { get; set; } = "*************";


        [Description("Изменить пароль")]
        public string ChangePasswordFormBtnChangePwd { get; set; } = "Изменить пароль";





        [Description("Неверный старый пароль")]
        public string ChangePasswordFormErrorInvalidPwd { get; set; } = "Неверный старый пароль";

        [Description("Введенные пароли не совпадают")]
        public string ChangePasswordFormErrorDontMatch { get; set; } = "Введенные пароли не совпадают";

        [Description("Заполните все необходимые поля")]
        public string ChangePasswordFormErrorValidation { get; set; } = "Заполните все необходимые поля";

        [Description("Пароль должен быть от 8 символов и содержать в себе заглавные буквы и цифры")]
        public string ChangePasswordFormErrorComplexity { get; set; } = "Пароль должен быть от 8 символов и содержать в себе заглавные буквы и цифры";
    }
}
