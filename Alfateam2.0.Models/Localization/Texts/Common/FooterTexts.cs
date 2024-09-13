using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Common
{
    /// <summary>
    /// Сущность текстов футера
    /// </summary>
    public class FooterTexts : LocalizableModel
    {
        public string AllRightReserved { get; set; } = "All rights reserved";



        public string Team { get; set; } = "Команда";
        public string Partners { get; set; } = "Партнеры";
        public string News { get; set; } = "Новости";
        public string Contacts { get; set; } = "Контакты";


        public string LeaveRequest { get; set; } = "Оставить заявку";
        public string OurWorks { get; set; } = "Наши работы";
        public string ServicesCost { get; set; } = "Стоимость услуг";
        public string AboutUs { get; set; } = "О нас";
    } 
}
