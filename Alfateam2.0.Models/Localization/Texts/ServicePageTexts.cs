using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    public class ServicePageTexts : LocalizableModel
    {
        public string WriteUsBtn { get; set; } = "Написать нам";
        public string MakeAnyProject { get; set; } = "Сделаем любой функционал";
        public string OurProject { get; set; } = "Наши кейсы";
        public string OurStack { get; set; } = "Наш стек";
        public string ReviewsAboutService { get; set; } = "ОТЗЫВЫ ОБ ЭТОЙ УСЛУГЕ";
        public string MaybeBeInteresting { get; set; } = "ВОЗМОЖНО БУДЕТ ИНТЕРЕСНО";
    }
}
