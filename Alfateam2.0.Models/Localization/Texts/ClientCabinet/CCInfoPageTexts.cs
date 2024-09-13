using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCInfoPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Информация";


        public string HeaderPersonalData { get; set; } = "Личные данные";
        public string Avatar { get; set; } = "Аватар";


        public string FormInputName { get; set; } = "Имя";
        public string FormInputNamePlaceholder { get; set; } = "Артур";

        public string FormInputSurname { get; set; } = "Фамилия";
        public string FormInputSurnamePlaceholder { get; set; } = "Бондарев";

        public string FormInputPatronymic { get; set; } = "Отчество";
        public string FormInputPatronymicPlaceholder { get; set; } = "Александрович";
        public string FormBtnSave { get; set; } = "Сохранить";




        public string HeaderChangePassword { get; set; } = "Смена пароля";

        public string ChangePasswordFormOldTitle { get; set; } = "Старый пароль";
        public string ChangePasswordFormOldPlaceholder { get; set; } = "*************";


        public string ChangePasswordFormNewTitle { get; set; } = "Новый пароль";
        public string ChangePasswordFormNewPlaceholder { get; set; } = "*************";

        public string ChangePasswordFormRepeatTitle { get; set; } = "Повтор пароля";
        public string ChangePasswordFormRepeatPlaceholder { get; set; } = "*************";

        public string ChangePasswordFormBtnChangePwd { get; set; } = "Изменить пароль";



        public string ChangePasswordFormErrorInvalidPwd { get; set; } = "Неверный старый пароль";
        public string ChangePasswordFormErrorDontMatch { get; set; } = "Введенные пароли не совпадают";
        public string ChangePasswordFormErrorValidation { get; set; } = "Заполните все необходимые поля";
        public string ChangePasswordFormErrorComplexity { get; set; } = "Пароль должен быть от 8 символов и содержать в себе заглавные буквы и цифры";
    }
}
