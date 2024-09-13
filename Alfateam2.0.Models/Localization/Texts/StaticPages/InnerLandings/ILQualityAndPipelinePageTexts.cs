using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages.InnerLandings
{
    public class ILQualityAndPipelinePageTexts : LocalizableModel
    {
        public string MainBlockHeader { get; set; } = "НАША ЗАДАЧА - КАЧЕСТВО ПРОДУКТА";
        public string MainBlockShortText { get; set; } = "У нас большой опыт в области разработки ПО для бизнеса";
        public string MainBlockGoToProjectBtn { get; set; } = "Перейти к кейсу";




        public string MetricProjectsInWork { get; set; } = "Проектов в работе";
        public string MetricProjectsInYear { get; set; } = "Проектов за год";
        public string MetricProjectsTotal { get; set; } = "Всего проектов";
        public string MetricTeammatesCount { get; set; } = "Человек в команде";



        public string OurAdvantagesHeader { get; set; } = "НАШИ ПРЕИМУЩЕСТВА";
        public string OurAdvantagesHtmlBlock1 { get; set; } = "Блок Талантливая команда дизайнеров. Заполнить из админки";
        public string OurAdvantagesHtmlBlock2 { get; set; } = "Блок Креативность и инновации. Заполнить из админки";
        public string OurAdvantagesHtmlBlock3 { get; set; } = "Блок Профессионализм и опыт. Заполнить из админки";
        public string OurAdvantagesHtmlBlock4 { get; set; } = "Блок Высокое качество. Заполнить из админки";
        public string OurAdvantagesHtmlBlock5 { get; set; } = "Блок Профессиональное обслуживание. Заполнить из админки";
        public string OurAdvantagesHtmlBlock6 { get; set; } = "Блок Развитие партнерских отношений. Заполнить из админки";




        public string ProjectDevelopmentStagesHeader { get; set; } = "Этапы создания проекта";
        public string ProjectDevelopmentStage1 { get; set; } = "Утверждение ТЗ";
        public string ProjectDevelopmentStage2 { get; set; } = "Создание прототипа";
        public string ProjectDevelopmentStage3 { get; set; } = "Разработка";
        public string ProjectDevelopmentStage4 { get; set; } = "Верстка";
        public string ProjectDevelopmentStage5 { get; set; } = "Оптимизация";



        public string LastProjectsHeader { get; set; } = "Последние работы";
        public string OurServicesHeader { get; set; } = "Наши услуги";
        public string ClientsReviewsHeader { get; set; } = "Отзывы клиентов";
    }

}
