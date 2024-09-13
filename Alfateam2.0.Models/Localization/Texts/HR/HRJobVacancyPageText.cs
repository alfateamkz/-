using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.HR
{
    public class HRJobVacancyPageText : LocalizableModel
    {
        public string KeySkills { get; set; } = "Ключевые навыки";





        public string CVFormTitle { get; set; } = "Форма для обратной связи";

        public string CVFormInputName { get; set; } = "Ваше имя";
        public string CVFormInputNamePlaceholder { get; set; } = "Ваше имя";

        public string CVFormInputPhone { get; set; } = "Ваш номер телефона";
        public string CVFormInputPhonePlaceholder { get; set; } = "Ваш номер";

        public string CVFormInputDescription { get; set; } = "Оставьте ваше сообщение";
        public string CVFormInputDescriptionPlaceholder { get; set; } = "Введите обращение";


        public string CVFormBtnSend { get; set; } = "Отправить";
        public string CVFormBtnAttach{ get; set; } = "Прикрепить резюме";


        public string CVFormError { get; set; } = "Заполните все обязательные поля";
    }

}
