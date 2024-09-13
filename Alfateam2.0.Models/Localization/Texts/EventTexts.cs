using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    /// <summary>
    /// Сущность перевода текста страницы мероприятия
    /// </summary>
    public class EventTexts :  LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Мероприятия";
        public string Header { get; set; } = "МЕРОПРИЯТИЯ";


        public string Format { get; set; } = "Формат";
        public string Topic { get; set; } = "Тема";
        public string EventsSearch { get; set; } = "Поиск мероприятий";


        public string SearchBtn { get; set; } = "Найти";





        public string BookingFormHeader { get; set; } = "Запись на мероприятие";
        public string BookingFormInputName { get; set; } = "Ваше имя";
        public string BookingFormInputNamePlaceholder { get; set; } = "Ваше имя";

        public string BookingFormInputPhone { get; set; } = "Ваш номер телефона";
        public string BookingFormInputPhonePlaceholder { get; set; } = "Ваш номер";

        public string BookingFormInputDescription { get; set; } = "Оставьте ваше сообщение";
        public string BookingFormInputDescriptionPlaceholder { get; set; } = "Введите обращение";


        public string BookingFormBtnSend { get; set; } = "Отправить";


        public string BookingFormError { get; set; } = "Заполните все обязательные поля";
    }
}
